using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerAttacking : MonoBehaviour
    {
        LayerMask backStabLayer = 1 << 14; // backstab layer is on layer 14

        PlayerAnimatorManager animatorHandler;
        PlayerManager playerManager;
        PlayerStats playerStats;
        PlayerInventory playerInventory;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponent<PlayerAnimatorManager>();
            playerManager = GetComponentInParent<PlayerManager>();
            playerStats = GetComponentInParent<PlayerStats>();
            playerInventory = GetComponentInParent<PlayerInventory>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
            inputHandler = GetComponentInParent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);
                if (lastAttack == weapon.OH_Light_Attack_1)
                {
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                } 
                else if (lastAttack == weapon.TH_Light_Attack_1)
                {
                    animatorHandler.PlayTargetAnimation(weapon.TH_Light_Attack_2, true);
                }
             }

        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {
                animatorHandler.PlayTargetAnimation(weapon.TH_Light_Attack_1, true);
                lastAttack = weapon.TH_Light_Attack_1;
            }
            else
            {
                
                animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
                lastAttack = weapon.OH_Light_Attack_1;
            }

        }        
        public void HandleHeavyAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;
            if (inputHandler.twoHandFlag)
            {
                //place heavy TH animation
                animatorHandler.PlayTargetAnimation(weapon.TH_Heavy_Attack_1, true);
                lastAttack = weapon.TH_Heavy_Attack_1;
            }
            else
            {
                
                animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
                lastAttack = weapon.OH_Heavy_Attack_1;
            }

        }

        public void HandleRBAction()
        {
            if (playerInventory.rightWeapon.isMeleeWeapon)
            {
                PerformRB_MeleeAction();
            } 
            else if (playerInventory.rightWeapon.isSpellCaster || playerInventory.rightWeapon.isHolyCaster || playerInventory.rightWeapon.isPyroCaster)
            {
                PerformRB_MagicAction(playerInventory.rightWeapon);
            }

        }

        #region Attack Actions
        private void PerformRB_MeleeAction()
        {
           if (playerManager.canDoCombo)
            {
                inputHandler.comboFlag = true;
                HandleWeaponCombo(playerInventory.rightWeapon);
                inputHandler.comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;
                if (playerManager.canDoCombo)
                    return;
                
                    animatorHandler.anim.SetBool("isUsingRightHand", true);
                    HandleLightAttack(playerInventory.rightWeapon);

/*                animatorHandler.anim.SetBool("isUsingRightHand", true);
                HandleLightAttack(playerInventory.rightWeapon);*/
            }
        }

        private void PerformRB_MagicAction( WeaponItem weapon)
        {
            if (playerManager.isInteracting) 
                return;
            if (weapon.isHolyCaster)
            {
                //check for FP stat
                if (playerInventory.currentSpell != null && playerInventory.currentSpell.isHolySpell)
                {
                    if (playerStats.currentFP_Points >= playerInventory.currentSpell.focusPointCost)
                    {
                        playerInventory.currentSpell.AttempToCastSpell(animatorHandler, playerStats);
                        //cast spell
                    }
                    else
                    {
                        animatorHandler.PlayTargetAnimation("Failed_Attempt", true);
                        //play animation failed to cast spell
                    }

                }
            }
        }

        private void SuccessfullyCastSpell()
        {
            //call on animation event 
            //choose which frame of the animation to successfully cast a spell
            playerInventory.currentSpell.SuccessfullyCastSpell(animatorHandler, playerStats);
        }

        #endregion

        public void AttemptBackStabOrParry()
        {
            RaycastHit hit;

            // start point - going out to transforms direction forward - out hit variable - distance 0.5f - scan on layer 
            if(Physics.Raycast(inputHandler.criticalAttackRayCastStartPoint.position, transform.TransformDirection(Vector3.forward), out hit, 0.5f, backStabLayer))
            {
                CharacterManager enemyCharacterManager = hit.transform.gameObject.GetComponentInParent<CharacterManager>();
                DamageCollider rightWeapon = weaponSlotManager.rightHandDamageCollider;

                if (enemyCharacterManager != null)
                {
                    //check id ( so you cant stab ally )

                    //pull is into a transform behind the enemy so backstab looks clean
                    playerManager.transform.position = enemyCharacterManager.backStabCollider.backStabStandPoint.position;


                    //rotate us towards that transform

                    Vector3 rotationDirection = playerManager.transform.root.eulerAngles;
                    rotationDirection = hit.transform.position - playerManager.transform.position;
                    rotationDirection.y = 0;
                    rotationDirection.Normalize();
                    Quaternion tr = Quaternion.LookRotation(rotationDirection);
                    Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 500 * Time.deltaTime);
                    playerManager.transform.rotation = targetRotation;


                    int criticalDamage = playerInventory.rightWeapon.criticalDamageMultiplier * rightWeapon.currentWeaponDamage;
                    enemyCharacterManager.pendingCriticalDamage = criticalDamage;

                    //play animation
                    animatorHandler.PlayTargetAnimation("Back Stab", true);
                    //make enemy play animation
                    enemyCharacterManager.GetComponentInChildren<AnimatorManager>().PlayTargetAnimation("Back Stabbed", true);
                    
                    
                    //do damage

                }
            }
        }
    }
}

