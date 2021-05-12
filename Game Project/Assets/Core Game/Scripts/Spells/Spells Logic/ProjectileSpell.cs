using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    [CreateAssetMenu(menuName = "Spells/Projectile Spell")]
    public class ProjectileSpell : SpellItems
    {
        [Header("Projectile Damage")]
        public float baseDamage;

        [Header("Projectile Physics")]
        public float projectileForwardVelocity;
        public float projectileUpwardVelocity;
        public float projectileMass;
        public bool isEffectedByGravity; // add gravity on specific spells ( shooting straight or curve down)
        Rigidbody rigidbody;

        public override void AttemptToCastSpell(
            PlayerAnimatorManager animationHandler,
            PlayerStats playerStats,
            WeaponSlotManager weaponSlotManager)
        {
            base.AttemptToCastSpell(animationHandler, playerStats, weaponSlotManager);

            //instantiate the spell in the player's hand 
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, weaponSlotManager.rightHandSlot.transform);

            //The scale changes depends on preference
            instantiatedWarmUpSpellFX.gameObject.transform.localScale = new Vector3(1, 1, 1);

            //play animation
            animationHandler.PlayTargetAnimation(spellAnimation, true);
            
        }

        public override void SuccessfullyCastSpell(
            PlayerAnimatorManager animationHandler,
            PlayerStats playerStats,
            CameraHandler cameraHandler,
            WeaponSlotManager weaponSlotManager)
        {
            base.SuccessfullyCastSpell(animationHandler, playerStats, cameraHandler, weaponSlotManager);

            GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponSlotManager.rightHandSlot.transform.position,
              cameraHandler.cameraPivotTransform.rotation);

            rigidbody = instantiatedSpellFX.GetComponent<Rigidbody>();
            // spell dmg collider
            //spellDamageCollider = instatiatedSpellFX.GetComponent<SpellDamageCollider>();


            //aiming spell angle w/ or w/o lock on
            if(cameraHandler.currentLockOnTarget != null)
            {
                instantiatedSpellFX.transform.LookAt(cameraHandler.currentLockOnTarget.transform);
            }
            else
            {
                instantiatedSpellFX.transform.rotation = Quaternion.Euler(cameraHandler.cameraPivotTransform.eulerAngles.x, playerStats.transform.eulerAngles.y, 0);
            }

            rigidbody.AddForce(instantiatedSpellFX.transform.forward * projectileForwardVelocity);
            rigidbody.AddForce(instantiatedSpellFX.transform.up * projectileUpwardVelocity);
            rigidbody.useGravity = isEffectedByGravity;
            rigidbody.mass = projectileMass;
            instantiatedSpellFX.transform.parent = null;

        }
    }
}
