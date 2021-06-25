using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class IdleState : State
    {
        public PursueTargetState pursueTargetState;
        public LayerMask detectionLayer;
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager, EnemyFXManager enemyFXManager)
        {
            // Look for target
            #region Target Detection

            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

                for (int i = 0; i < colliders.Length; i++)
                {
                    CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

                    if (characterStats != null)
                    {
                        //check ID

                        Vector3 targetDirection = characterStats.transform.position - transform.position;
                        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                        if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                        {
                            enemyManager.currentTarget = characterStats;
                        }
                    }
                }
            #endregion

            #region Switch State
            if (enemyManager.currentTarget != null)
            {
                //Switch state when found the target
                return pursueTargetState;
            }
            else 
            {
                //if not , return to this state
                return this;
            }
            #endregion
        }
    }
}

