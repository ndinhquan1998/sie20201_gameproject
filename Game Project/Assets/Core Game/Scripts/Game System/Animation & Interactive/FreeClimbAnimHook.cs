using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class FreeClimbAnimHook : MonoBehaviour
    {
        Animator animator;


        IKSnapshot ikBase;
        IKSnapshot current = new IKSnapshot();
        IKSnapshot next = new IKSnapshot();

        public float weight_RH;
        public float weight_LH;
        public float weight_RF;
        public float weight_LF;

        Vector3 rh, lh, rf, lf;
        Transform h;
        public void Init(ClimbingLogic c, Transform helper)
        {
            animator = c.anim;
            ikBase = c.baseIKsnapshot;
            h = helper;
        }

        public void CreatePositions(Vector3 origin)
        {
            IKSnapshot ik = CreateSnapshot(origin);
            CopySnapshot(ref current, ik);

            UpdateIKPosition(AvatarIKGoal.LeftFoot, current.lf);
            UpdateIKPosition(AvatarIKGoal.RightFoot, current.rf);
            UpdateIKPosition(AvatarIKGoal.LeftHand, current.lh);
            UpdateIKPosition(AvatarIKGoal.RightHand, current.rh);

            UpdateIKWeight(AvatarIKGoal.RightHand, 1);
            UpdateIKWeight(AvatarIKGoal.LeftHand, 1);
            UpdateIKWeight(AvatarIKGoal.RightFoot, 1);
            UpdateIKWeight(AvatarIKGoal.LeftFoot, 1);
        }

        public IKSnapshot CreateSnapshot(Vector3 o)
        {
            IKSnapshot r = new IKSnapshot();


            Vector3 _lh = LocalToWorld(ikBase.lh);
            r.lh = GetPosActual(_lh);


            Vector3 _rh = LocalToWorld(ikBase.rh);
            r.rh = GetPosActual(_rh);


            Vector3 _lf = LocalToWorld(ikBase.lf);
            r.lf = GetPosActual(_lf);

  
            Vector3 _rf = LocalToWorld(ikBase.rf);
            r.rh = GetPosActual(_rf);

            return r;

        }

        public float wallOffset = 0;
        Vector3 GetPosActual(Vector3 o)
        {
            Vector3 r = o;
            Vector3 origin = o;
            Vector3 dir = h.forward;
            origin += -(dir * 0.2f);
            RaycastHit hit;
            if(Physics.Raycast(origin, dir, out hit, 1.5f))
            {
                Vector3 _r = hit.point + (hit.normal * wallOffset);
                r = _r;
            }
            return r;
        }

        Vector3 LocalToWorld(Vector3 p)
        {
            Vector3 r = h.position;
            r += h.right * p.x;
            r += h.forward * p.z;
            r += h.up * p.y;
            return r;
        }

        public void CopySnapshot(ref IKSnapshot to , IKSnapshot from)
        {
            to.lh = from.lh;
            to.rh = from.rh;
            to.lf = from.lf;
            to.rf = from.rf;
        }

        public void UpdateIKPosition(AvatarIKGoal goal, Vector3 pos)
        {
            switch (goal)
            {
                case AvatarIKGoal.LeftFoot:
                    lf = pos;
                    break;                
                case AvatarIKGoal.RightFoot:
                    rf = pos;
                    break;                
                case AvatarIKGoal.LeftHand:
                    lh = pos;
                    break;                
                case AvatarIKGoal.RightHand:
                    rh = pos;
                    break;
                default:
                    break;
            }
        }        
        
        public void UpdateIKWeight(AvatarIKGoal goal, float weight)
        {
            switch (goal)
            {
                case AvatarIKGoal.LeftFoot:
                    weight_LF = weight;
                    break;                
                case AvatarIKGoal.RightFoot:
                    weight_RF = weight;
                    break;                
                case AvatarIKGoal.LeftHand:
                    weight_LH = weight;
                    break;                
                case AvatarIKGoal.RightHand:
                    weight_RH = weight;
                    break;
                default:
                    break;
            }
        }
        private void OnAnimatorIK(int layerIndex)
        {
            SetIKPos(AvatarIKGoal.LeftHand, lh, weight_LH);
            SetIKPos(AvatarIKGoal.RightHand, rh, weight_RH);
            SetIKPos(AvatarIKGoal.LeftFoot, lf, weight_LF);
            SetIKPos(AvatarIKGoal.RightFoot, rf, weight_RF);
        }

        void SetIKPos(AvatarIKGoal goal, Vector3 tp, float w)
        {
            animator.SetIKPositionWeight(goal, w);
            animator.SetIKPosition(goal, tp);
        }
    }

}
