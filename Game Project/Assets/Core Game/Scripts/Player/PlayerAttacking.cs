using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerAttacking : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        PlayerManager playerManager;
        PlayerStats playerStats;
        PlayerInventory playerInventory;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponent<AnimatorHandler>();
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

    }
}

