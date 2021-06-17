using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class CharacterStats : MonoBehaviour
    {

        //public int healthLevel = 10;
        [SerializeField]
        protected int maxHealth;
        [SerializeField]
        private int currentHealth;

        // public int staminaLevel = 10;
        [SerializeField]
        protected float maxStamina;
        [SerializeField]
        protected float currentStamina;

        //public int MP_level = 10;
        [SerializeField]
        protected float maxMP_Points;
        [SerializeField]
        protected float currentMP_Points;

        [Header("Armor Damage Absorptions")]

        public float physicalDmgAbsorbtion_Head;

        public float physicalDmgAbsorbtion_BodyArmor;

        public float physicalDmgAbsorbtion_BottomArmor;

        #region Getter Setter
        public float CurrentStamina
        {
            get => currentStamina;
            protected set => currentStamina = value;
        }
        public float CurrentMP_Points
        {
            get => currentMP_Points;
            protected set => currentMP_Points = value;
        }
        public int CurrentHealth
        {
            get => currentHealth;
            protected set => currentHealth = value;
        }
        public int MaxHealth
        {
            get => maxHealth;
            protected set => maxHealth = value;
        }
        #endregion

        //Magic Absorbtion


        

        public bool isDead;

        public virtual void TakeDamage(int physicalDamage, string damageAnimation = "Damage_01")
        {
            if (isDead)
                return;
            float totalPhysicalDamageAbsorption = 1 -
                (1 - physicalDmgAbsorbtion_Head / 100) *
                (1 - physicalDmgAbsorbtion_BodyArmor / 100) *
                (1 - physicalDmgAbsorbtion_BottomArmor / 100);

            physicalDamage = Mathf.RoundToInt(physicalDamage - (physicalDamage * totalPhysicalDamageAbsorption));

            Debug.Log("Total %def: " + totalPhysicalDamageAbsorption);

            float finalDamageTaken = physicalDamage; // +magicDmg

            currentHealth = Mathf.RoundToInt(currentHealth - finalDamageTaken);

            Debug.Log("Total Damage taken: " + finalDamageTaken);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;

            }
        }


    }
}

