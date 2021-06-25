using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class LookForTargetState : State
    {
        public CombatStanceState combatStanceState;

        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager, EnemyFXManager enemyFXManager)
        {
            enemyAnimatorManager.anim.SetFloat("Vertical", 0);
            enemyAnimatorManager.anim.SetFloat("Horizontal", 0);

            Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
            float viewableAngle = Vector3.SignedAngle(targetDirection, enemyManager.transform.forward, Vector3.up);

            if (enemyManager.isInteracting)
                return this; // when we enter the state we will still be interacting from the attack animation so we pause here until it has finished

            //these if conditions values can tune up
            if(viewableAngle >= 100 && viewableAngle <=180 && !enemyManager.isInteracting)
            {
                enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Behind", true);
                Debug.Log("Turn 180");
                return combatStanceState;
            }
            else if( viewableAngle <= -101 && viewableAngle >= -180 && !enemyManager.isInteracting)
            {
                enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Behind", true);
                Debug.Log("Turn 180");
                return combatStanceState;
            }            
            else if( viewableAngle <= -45 && viewableAngle >= -100 && !enemyManager.isInteracting)
            {
                enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Right", true);
                Debug.Log("Turn Right");
                return combatStanceState;
            }
            else if( viewableAngle >= 45 && viewableAngle <= 100 && !enemyManager.isInteracting)
            {
                enemyAnimatorManager.PlayTargetAnimationWithRootRotation("Turn Left", true);
                Debug.Log("Turn Left");
                return combatStanceState;
            }

            return combatStanceState;
        }

    }

}
