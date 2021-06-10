using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class ClimbingLogic : MonoBehaviour
    {
        PlayerManager playerManager;
        public Animator anim;
        //public bool isClimbing; // refactor to player controller

        bool inPosition;
        bool isLerping;
        private float posT;
        private float delta;
        Vector3 startPos;
        Vector3 targetPos;
        Quaternion startRotation;
        Quaternion targetRotation;
        public float positionOffset;
        public float offsetFromWall = 0.3f;
        public float speedMultiplier = 0.2f;
        public float climbSpeed = 3;
        public float rotateSpeed = 5;
        public float angleDistance = 1;

        public float horizontal;
        public float vertical;

        public IKSnapshot baseIKsnapshot;

        public FreeClimbAnimHook a_hook;

        Transform helper;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        bool CanMoveWhenClimbing(Vector3 moveDir)
        {
            Vector3 origin = transform.position;
            float distance = positionOffset;
            Vector3 dir = moveDir;
            Debug.DrawRay(origin , dir * distance, Color.red);
            RaycastHit hit;

            if(Physics.Raycast(origin,dir, out hit, distance))
            {
                return false; //temporary disable

            }
            //
            origin += moveDir * distance;
            dir = helper.forward;
            float distance_2 = angleDistance;

            Debug.DrawRay(origin, dir * distance_2, Color.blue);//blue , distance frombody to surface
            if (Physics.Raycast(origin, dir, out hit, distance))
            {
                helper.position = PosWithOffset(origin, hit.point);
                helper.rotation = Quaternion.LookRotation(-hit.normal);
                return true;
            }
            //checking Corner
            origin += moveDir * distance_2;
            dir = -Vector3.up;
            Debug.DrawRay(origin, dir, Color.yellow);//yellow height position 
            if (Physics.Raycast(origin, dir, out hit, distance_2))
            {
                float angle = Vector3.Angle(helper.up, hit.normal);
                if(angle < 40)
                {
                    helper.position = PosWithOffset(origin, hit.point);
                    helper.rotation = Quaternion.LookRotation(-hit.normal);
                    return true;
                }

            }

            return false;
        }
        void Start()
        {
            Init();
        }

        /*void Update()
        {
            delta = Time.deltaTime;
            Tick(delta);//refactor pass delta from controller
        }*/

        public void Init()
        {
            helper = new GameObject().transform;
            helper.name = "climb helper";
            a_hook.Init(this, helper);
            CheckForClimb();
        }
        public void Tick(float delta)
        {
            if (!inPosition)
            {
                GetInPosition();
                return;
            }

            if (!isLerping)
            {

                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

                Vector3 h = helper.right * horizontal;
                Vector3 v = helper.right * vertical;
                Vector3 moveDir = (h + v).normalized;

                bool canMove = CanMoveWhenClimbing(moveDir);
                if (!canMove || moveDir == Vector3.zero)
                return;

                posT = 0;
                isLerping = true;
                startPos = transform.position;
                //Vector3 tp = helper.position - transform.position;
                targetPos = helper.position;

                a_hook.CreatePositions(targetPos);
            }
            else
            {
                posT += delta * climbSpeed;
                if(posT > 1)
                {
                    posT = 1;
                    isLerping = false;

                }

                Vector3 cp = Vector3.Lerp(startPos, targetPos, posT);
                transform.position = cp;
                transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
            }
        }

        void GetInPosition()
        {
            posT += delta;

            if( posT >1)
            {
                posT = 1;
                inPosition = true;

                //enable IK
                a_hook.CreatePositions(targetPos);
            }
            Vector3 tp = Vector3.Lerp(startPos, targetPos, posT); //tp - target position
            transform.position = tp;
            transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
        }

        public void CheckForClimb()
        {
            Vector3 origin = transform.position;
            origin.y += 1.4f; // somewhere at waist's position
            Vector3 dir = transform.forward;
            RaycastHit hit;
            if(Physics.Raycast(origin, dir, out hit, 5))
            {
                helper.position = PosWithOffset(origin, hit.point);
                InitForClimb(hit);
            }
        }
        Vector3 PosWithOffset(Vector3 origin, Vector3 target)
        {
            Vector3 direction = origin - target;
            direction.Normalize();
            Vector3 offset = direction * offsetFromWall;
            return target + offset;
        }
        void InitForClimb(RaycastHit hit)
        {
            playerManager.isClimbing = true;
            helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
            startPos = transform.position;
            targetPos = hit.point + (hit.normal * offsetFromWall);
            posT = 0;
            inPosition = false;
            anim.CrossFade("Climb_Idle", 2);
        }
    }

    [System.Serializable]
    public class IKSnapshot
    {
        public Vector3 rh, lh, rf, lf;
    }
}
