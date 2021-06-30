using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    [CreateAssetMenu(menuName = "Spells/Enemy Spell")]
    public class ShamanSpell : EnemyAttackAction
    {
        public GameObject spellWarmUpFX;
        public GameObject spellCastFX;

        [Header("Projectile Damage")]
        public float baseDamage;

        [Header("Projectile Physics")]
        public float projectileForwardVelocity;
        public float projectileUpwardVelocity;
        public float projectileMass;
        public bool isEffectedByGravity; // add gravity on specific spells ( shooting straight or curve down)
        Rigidbody rigidbody;

        public void AttemptToCastSpell(
            EnemyAnimatorManager animationHandler)
        {
            animationHandler.PlayTargetAnimation(actionAnimation, true);
        }

        public void SuccessfullyCastSpell(
            EnemyAnimatorManager animationHandler,
            EnemyManager enemyManager,
            EnemyWeaponSlotManager weaponSlotManager)
        {

            GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponSlotManager.rightHandSlot.transform.position,
              Quaternion.identity);

            rigidbody = instantiatedSpellFX.GetComponent<Rigidbody>();

            //aiming spell angle w/ or w/o lock on
            if (enemyManager.currentTarget != null)
            {
                instantiatedSpellFX.transform.LookAt(enemyManager.currentTarget.transform);
            }
            else
            {
                instantiatedSpellFX.transform.rotation = Quaternion.Euler(enemyManager.transform.eulerAngles.x, enemyManager.transform.eulerAngles.y, 0);
            }

            rigidbody.AddForce(instantiatedSpellFX.transform.forward * projectileForwardVelocity);
            rigidbody.AddForce(instantiatedSpellFX.transform.up * projectileUpwardVelocity);
            rigidbody.useGravity = isEffectedByGravity;
            rigidbody.mass = projectileMass;
            instantiatedSpellFX.transform.parent = null;

        }

        public void Healing(EnemyStats enemyStats)
        {
            //GameObject instantiatedSpellFX = Instantiate(spellCastFX, animationHandler.transform);
            enemyStats.RestoreHP(50);

            Debug.Log("Heal Successful");
        }
    }
}

