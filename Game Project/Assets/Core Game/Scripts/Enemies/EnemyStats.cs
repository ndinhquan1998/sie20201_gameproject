using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class EnemyStats : CharacterStats
    {
        //private int healthLevel = 10;
        public Stats _stats;
        EnemyAnimatorManager enemyAnimatorManager;
        public UIEnemyHealthBar enemyHealthBar;
        
        public int coinsDrop = 50;

        private void Awake()
        {
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
  
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            CurrentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = _stats.healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamageNoAnimation(int damage)
        {
            enemyHealthBar.SetHealth(CurrentHealth);
            CurrentHealth = CurrentHealth - damage;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                isDead = true;
            }
        }

        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            base.TakeDamage(damage, damageAnimation = "Damage_01");


            enemyHealthBar.SetHealth(CurrentHealth);

            enemyAnimatorManager.PlayTargetAnimation(damageAnimation, true);

            if (CurrentHealth <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            CurrentHealth = 0;
            enemyAnimatorManager.PlayTargetAnimation("Death_01", true);
            //Handler death 
            isDead = true;
            //StartCoroutine(RemoveAfterSeconds(60, this.gameObject));

        }

        IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
    }
}

