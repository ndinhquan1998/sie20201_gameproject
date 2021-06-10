using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimatorBool : StateMachineBehaviour
{
    /*
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isInteracting", true);
        }
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isInteracting", false);
        }*/


    public string targetBool = "isInteracting";
    public bool status = false;    

    public string targetBool_1 = "canDoCombo";
    public bool status_1 = false;    

    public string targetBool_2 = "isUsingRightHand";
    public bool status_2 = false;    

    public string targetBool_3 = "isUsingLeftHand";
    public bool status_3 = false;    
    
    public string targetBool_4 = "isInvulnerable";
    public bool status_4 = false;    
    
    public string targetBool_5 = "canRotate";
    public bool status_5 = true;
    
    public string targetBool_6 = "isFiringSpell";
    public bool status_6 = false;    
    
    public string targetBool_7 = "isRotatingWithRootMotion";
    public bool status_7 = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(targetBool, status);
        animator.SetBool(targetBool_1, status_1);
        animator.SetBool(targetBool_2, status_2);
        animator.SetBool(targetBool_3, status_3);
        animator.SetBool(targetBool_4, status_4);
        animator.SetBool(targetBool_5, status_5);
        animator.SetBool(targetBool_6, status_6);
        animator.SetBool(targetBool_7, status_7);
    }

}
