using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class CombatStanceState : State
    {
        public AttackState attackState;
        public PursueTargetState pursueTargetState;

        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            // Check for attack range

            //walk around target
   
            enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

            if(enemyManager.currentRecoveryTime <= 0 && enemyManager.distanceFromTarget <= enemyManager.maximumAttackRange)
            {
                return attackState;
                // if still in the atk range , return atk state
            }
            else if(enemyManager.distanceFromTarget > enemyManager.maximumAttackRange)
            {
                return pursueTargetState;
                //in cooldown attacking , return this state and continue focus player
            }
            else
            {
                return this;
                //fail safe
            }

             
        }
    }

}
