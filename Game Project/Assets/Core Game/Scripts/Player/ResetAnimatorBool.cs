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


    public string targetBool;
    public bool status;    

    public string targetBool_1;
    public bool status_1;    

    public string targetBool_2;
    public bool status_2;    

    public string targetBool_3;
    public bool status_3;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(targetBool, status);
        animator.SetBool(targetBool_1, status_1);
        animator.SetBool(targetBool_2, status_2);
        animator.SetBool(targetBool_3, status_3);


    }

}
