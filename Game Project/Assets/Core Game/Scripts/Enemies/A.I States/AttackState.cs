using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class AttackState : State
    {
        public LookForTargetState lookForTargetState;
        public CombatStanceState combatStanceState;
        public PursueTargetState pursueTargetState;

        //public EnemyAttackAction[] enemyAttacks;
        //public EnemyAttackAction currentAttack;
        private bool comboOnNextAttack = false;

        //public ShamanSpell currentMagicAttack;

        protected int rageCount = 0;
        protected int phaseLimit;

        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
        {
            Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
            float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
            float viewableAngle = Vector3.Angle(targetDirection, enemyManager.transform.forward);
            phaseLimit = enemyStats.MaxHealth / 2;
            HandleRotateTowardsTarget(enemyManager);

            if (enemyManager.isInteracting && enemyManager.canDoCombo == false)
            {
                return this;
            }
            else if (enemyManager.isInteracting && enemyManager.canDoCombo)
            {
                if (comboOnNextAttack)
                {
                    comboOnNextAttack = false;
                    //CUSTOM
                    if (enemyManager.currentAttack.usingWeapon)
                    {
                        enemyAnimatorManager.anim.SetBool("isUsingWeapon", true);
                    }
                    if (!enemyManager.currentAttack.isLeft)
                    {
                        enemyAnimatorManager.anim.SetBool("isUsingRightHand", true);
                    }
                    else if (enemyManager.currentAttack.isLeft)
                    {
                        enemyAnimatorManager.anim.SetBool("isUsingLeftHand", true);
                    }

                    //
                    enemyAnimatorManager.PlayTargetAnimation(enemyManager.currentAttack.actionAnimation, true);

                }
            }



            if (enemyManager.isPerformingAction)
            {
                return lookForTargetState;
            }
            if (gameObject.tag == "Enemy")
            {
                if (enemyStats.CurrentHealth < phaseLimit && rageCount < 1)
                {
                    enemyAnimatorManager.PlayTargetAnimation("Rage", true);
                    enemyStats.RestoreHP(phaseLimit / 2);
                    rageCount++;
                }
            }
            

            if (enemyManager.currentAttack != null)
            {
                //CUSTOM
                if (enemyManager.currentAttack.usingWeapon)
                {
                    enemyAnimatorManager.anim.SetBool("isUsingWeapon", true);
                }
                if (!enemyManager.currentAttack.isLeft)
                {
                    enemyAnimatorManager.anim.SetBool("isUsingRightHand", true);
                } 
                else if (enemyManager.currentAttack.isLeft)
                {
                    enemyAnimatorManager.anim.SetBool("isUsingLeftHand", true);
                }

                //
                //if we are too close to the enemy to perform current attack , get a new attack
                if (distanceFromTarget < enemyManager.currentAttack.minimumDistanceNeededToAttack)
                {
                    return this;
                }
                //if we are close enough to attack , then proceed
                else if (distanceFromTarget < enemyManager.currentAttack.maximumDistanceNeededToAttack)
                {
                    //if our enemy is within our attacks viewable angle, we attack
                    if (viewableAngle <= enemyManager.currentAttack.maximumAttackAngle && viewableAngle >= enemyManager.currentAttack.minimumAttackAngle)
                    {
                        if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false)
                        {
                            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);

                            enemyAnimatorManager.PlayTargetAnimation(enemyManager.currentAttack.actionAnimation, true);
                            enemyManager.isPerformingAction = true;
                            RollForComboChance(enemyManager);

                            if (enemyManager.currentAttack.canDoCombo && comboOnNextAttack)
                            {
                                enemyManager.currentAttack = enemyManager.currentAttack.comboAction;
                                return this;
                            }
                            else
                            {
                                enemyManager.currentRecoveryTime = enemyManager.currentAttack.recoveryTime;
                                enemyManager.currentAttack = null;
                                return lookForTargetState;
                            }
                        }
                    }
                }
            }

            else if (enemyManager.currentMagicAttack != null)
            {
                 if (distanceFromTarget < enemyManager.currentMagicAttack.maximumDistanceNeededToAttack)
                    {
                    //if our enemy is within our attacks viewable angle, we attack
                    if (viewableAngle <= enemyManager.currentMagicAttack.maximumAttackAngle && viewableAngle >= enemyManager.currentMagicAttack.minimumAttackAngle)
                    {
                        if (enemyManager.currentRecoveryTime <= 0 && enemyManager.isPerformingAction == false)
                        {
                            enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                            enemyAnimatorManager.anim.SetFloat("Horizontal", 0, 0.1f, Time.deltaTime);

                            enemyManager.currentMagicAttack.AttemptToCastSpell(enemyAnimatorManager);
                            enemyManager.isPerformingAction = true;

                            enemyManager.currentRecoveryTime = enemyManager.currentMagicAttack.recoveryTime;
                            //enemyManager.currentMagicAttack = null;
                            return lookForTargetState;

                        }
                        else if (enemyManager.currentRecoveryTime > 0 && distanceFromTarget <= enemyManager.maximumAttackRange)
                        {
                            return lookForTargetState;
                        }
                    }
                }
            }
            else
            {
                GetNewAttack(enemyManager);
            }

            return lookForTargetState;

        }

        private void GetNewAttack(EnemyManager enemyManager)
        {

            Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
            float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

            int maxScore = 0;

            for (int i = 0; i < enemyManager.enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyManager.enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack && distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                    {
                        maxScore += enemyAttackAction.attackScore;
                    }
                }
            }
            int randomValue = Random.Range(0, maxScore);
            int temporaryScore = 0;

            for (int i = 0; i < enemyManager.enemyAttacks.Length; i++)
            {
                EnemyAttackAction enemyAttackAction = enemyManager.enemyAttacks[i];

                if (distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack && distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
                {
                    if (viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
                    {
                        if (enemyManager.currentAttack != null)
                            return;

                        temporaryScore += enemyAttackAction.attackScore;

                        if (temporaryScore > randomValue)
                        {
                            enemyManager.currentAttack = enemyAttackAction;
                        }

                    }
                }
            }

        }

        private void HandleRotateTowardsTarget(EnemyManager enemyManager)
        {
            //rotate manually
            //if (enemyManager.isPerformingAction)
            if (enemyManager.isInteracting && enemyManager.canRotate)
            {
                Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();

                if (direction == Vector3.zero)
                {
                    direction = transform.forward;
                }
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
            }
            //rotate with pathfinding (navmesh)
            /*else
            {
                Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
                Vector3 targetVelocity = enemyManager.enemyRigidbody.velocity;

                enemyManager.navMeshAgent.enabled = true;
                enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
                enemyManager.enemyRigidbody.velocity = targetVelocity;
                enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
                //control rotation of enemy include the model underneath in the hierarchy 
            }*/

        }

        private void RollForComboChance(EnemyManager enemyManager)
        {
            float comboChance = Random.Range(0, 100);

            if (enemyManager.allowAIToPerformCombos && comboChance <= enemyManager.comboLikelyHood)
            {
                comboOnNextAttack = true;
            }
        }
    }
}

