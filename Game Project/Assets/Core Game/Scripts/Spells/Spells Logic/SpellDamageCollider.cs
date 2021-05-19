using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class SpellDamageCollider : DamageCollider
    {
        public GameObject impactParticles;
        public GameObject projectileParticles;
        public GameObject muzzleParticles;

        Rigidbody rigidbody;

        bool hasCollided = false;

        CharacterStats spellTarget;

        //rotate the impact particles
        Vector3 impactNormal;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            projectileParticles = Instantiate(projectileParticles, transform.position, transform.rotation);
            projectileParticles.transform.parent = transform;

            if (muzzleParticles)
            {
                muzzleParticles = Instantiate(muzzleParticles, transform.position, transform.rotation);
                Destroy(muzzleParticles, 1f); 
            }
        }
 
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Attack Spell Collided");
            if (!hasCollided)
            {
                spellTarget = collision.transform.GetComponent<CharacterStats>();

                if (spellTarget != null)
                {
                    spellTarget.TakeDamage(currentWeaponDamage);
                }
                hasCollided = true;

                impactParticles = Instantiate(impactParticles, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal));

                Destroy(projectileParticles);
                Destroy(impactParticles, 3f);
                Destroy(gameObject, 3f);
            }
        }
    }
}
