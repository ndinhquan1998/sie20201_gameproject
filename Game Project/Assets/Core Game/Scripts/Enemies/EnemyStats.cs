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
        EnemyBossManager enemyBossManager;
        public UIEnemyHealthBar enemyHealthBar;

        public int coinsDrop = 50;
        public int exp = 50;

        public bool isBoss;

        private void Awake()
        {
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            maxHealth = SetMaxHealthFromHealthLevel();
            CurrentHealth = maxHealth;

        }

        void Start()
        {
            if (!isBoss)
            {
                enemyHealthBar.SetMaxHealth(maxHealth);
            }
            
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
                enemyHealthBar.SetHealth(CurrentHealth);
                isDead = true;
            }
        }

        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            base.TakeDamage(damage, damageAnimation = "Damage_01");

            if (!isBoss)
            {
                enemyHealthBar.SetHealth(CurrentHealth);
            }
            /*else if(isBoss && enemyBossManager != null)
            {
                
            }*/
            

            enemyAnimatorManager.PlayTargetAnimation(damageAnimation, true);

            if (CurrentHealth <= 0)
            {
                HandleDeath();
            }
        }

        public void RestoreHP(int healthAmount)
        {            
            CurrentHealth = CurrentHealth + healthAmount;

            if (CurrentHealth > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
            enemyHealthBar.SetHealth(CurrentHealth);
        }

        private void HandleDeath()
        {
            CurrentHealth = 0;
            enemyAnimatorManager.PlayTargetAnimation("Death_01", true);
            //Handler death 
            isDead = true;
            //StartCoroutine(RemoveAfterSeconds(60, this.gameObject));

        }
    }
}

