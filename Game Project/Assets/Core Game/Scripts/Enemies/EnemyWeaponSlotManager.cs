using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class EnemyWeaponSlotManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimatorManager enemyAnimator;
        EnemyStats enemyStats;

        public Weapon rightHandWeapon;
        public Weapon leftHandWeapon;

        public WeaponHolderSlot rightHandSlot;
        public WeaponHolderSlot leftHandSlot;

        

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;
        public DamageCollider bodypartCollider_1;
        public DamageCollider bodypartCollider_2;

        private void Awake()
        {
            enemyManager = GetComponentInParent<EnemyManager>();
            enemyStats = GetComponentInParent<EnemyStats>();
            enemyAnimator = GetComponent<EnemyAnimatorManager>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        private void Start()
        {
            LoadWeaponsOnBothHands();
        }

        public void LoadWeaponOnSlot(Weapon weapon, bool isleft)
        {
            if (isleft)
            {
                leftHandSlot.currentWeapon = weapon;
                leftHandSlot.LoadWeaponModel(weapon);
                //load weapon damage collider
                LoadWeaponDamageCollider(true);
            }
            else
            {
                rightHandSlot.currentWeapon = weapon;
                rightHandSlot.LoadWeaponModel(weapon);
                //load weapon damage collider
                LoadWeaponDamageCollider(false);
            }
        }

        public void LoadWeaponsOnBothHands()
        {
            if (rightHandWeapon != null)
            {
                LoadWeaponOnSlot(rightHandWeapon, false);

            }
            if (leftHandWeapon != null)
            {
                LoadWeaponOnSlot(leftHandWeapon, true);
            }
        }

        public void LoadWeaponDamageCollider(bool isLeft)
        {
            if (isLeft)
            {
                if (leftHandWeapon != null)
                {
                    leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
                    leftHandDamageCollider.currentWeaponDamage = leftHandWeapon.baseDamage;
                    leftHandDamageCollider.characterManager = GetComponentInParent<CharacterManager>();
                }

            }
            else
            {                               
                if(rightHandWeapon != null)
                {
                    rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
                    rightHandDamageCollider.currentWeaponDamage = rightHandWeapon.baseDamage;
                    rightHandDamageCollider.characterManager = GetComponentInParent<CharacterManager>();
                }
                else if(bodypartCollider_1 != null)
                {
                    bodypartCollider_1.currentWeaponDamage = leftHandWeapon.baseDamage;
                }
                else if (bodypartCollider_2 != null)
                {
                    bodypartCollider_2.currentWeaponDamage = rightHandWeapon.baseDamage;
                }              
                
            }
        }

        public void OpenDamageCollider()
        {
            if (enemyManager.isUsingWeapon)
            {
                rightHandDamageCollider.EnableDamageCollider();
            }
            else
            {
                if (enemyManager.isUsingRightHand)
                {
                    bodypartCollider_2.EnableDamageCollider();
                }
                else if (enemyManager.isUsingLeftHand)
                {
                    bodypartCollider_1.EnableDamageCollider();
                }
                
            }               
        }        
        public void CloseDamageCollider()
        {
            if (enemyManager.isUsingWeapon)
            {
                rightHandDamageCollider.DisableDamageCollider();
            }
            else if (enemyManager.isUsingRightHand)
            {
                bodypartCollider_2.DisableDamageCollider();
            }
            else if (enemyManager.isUsingLeftHand)
            {
                bodypartCollider_1.DisableDamageCollider();
            }
            //leftHandDamageCollider.DisableDamageCollider();
        }

        public void DrainStaminaLightAttack()
        {

        }
        public void DrainStaminaHeavyAttack()
        {
 
        }
        public void EnableCombo()
        {
      
        }
        public void DisableCombo()
        {
           
        }

        public void SuccessfullyCastSpell()
        {
            enemyManager.currentMagicAttack.SuccessfullyCastSpell(enemyAnimator,enemyManager,this);
        }
    }
}
