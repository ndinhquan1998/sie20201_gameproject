using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DQ
{
    public class PlayerStats : CharacterStats
    {
        public Stats _stats;

        public HealthBar healthBar;
        public StaminaBar staminaBar;
        public MPBar manaBar;
        PlayerManager playerManager;
        PlayerAnimatorManager animatorHandler;
        GameManager gameManager;
        

        public float staminaRegenerationAmount = 1;
        public float staminaRegenTimer = 0;
        private void Awake()
        {            
            playerManager = GetComponent<PlayerManager>();
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            manaBar = FindObjectOfType<MPBar>();
            gameManager = FindObjectOfType<GameManager>();
            animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();            
        }

        void Start()
        {
            Spawn();           
        }

        public void Spawn()
        {
            isDead = false;
            maxHealth = SetMaxHealthFromHealthLevel();
            CurrentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(CurrentHealth);

            maxStamina = SetMaxStaminaFromLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
            staminaBar.SetCurrentStamina(currentStamina);

            maxMP_Points = SetMaxManaPointFromLevel();
            currentMP_Points = maxMP_Points;
            manaBar.SetMaxManaPoints(maxMP_Points);
            manaBar.SetCurrentManaPoints(currentMP_Points);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = _stats.healthLevel * 10;
            return maxHealth;
        }        
        
        private float SetMaxStaminaFromLevel()
        {
            maxStamina = _stats.staminaLevel * 10;
            return maxStamina;
        }        
        
        private float SetMaxManaPointFromLevel()
        {
            maxMP_Points = _stats.MP_level * 10;
            return maxMP_Points;
        }

        public void TakeDamageNoAnimation(int damage)
        {
            CurrentHealth = CurrentHealth - damage;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                isDead = true;
            }
        }

        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            if (playerManager.isInvulnerable)
                return;

            base.TakeDamage(damage, damageAnimation = "Damage_01");
            healthBar.SetCurrentHealth(CurrentHealth);
            animatorHandler.PlayTargetAnimation(damageAnimation, true);

            if(CurrentHealth <= 0)
            {
                CurrentHealth = 0;                
                isDead = true;
                animatorHandler.PlayTargetAnimation("Death_01", true);
                //Handle respawn 

                gameManager.Respawn();
            }

        }
        public void TakeStamina(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void AddHealth()
        {
            CurrentHealth += 20;
            healthBar.SetCurrentHealth(CurrentHealth);
        }

        public void RegenerateStamina()
        {
            if (playerManager.isInteracting)
            {
                staminaRegenTimer = 0;
            }
            else 
            {
                staminaRegenTimer += Time.deltaTime;

                if (currentStamina < maxStamina && staminaRegenTimer >1f)
                {
                    currentStamina += staminaRegenerationAmount * Time.deltaTime;
                    staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
                }
            }
        }

        public void RestoreHP(int healthAmount)
        {
            CurrentHealth = CurrentHealth + healthAmount;

            if(CurrentHealth > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
            healthBar.SetCurrentHealth(CurrentHealth);
        }

        public void DeductFocusPoints(int focusPoints)
        {
            currentMP_Points = currentMP_Points - focusPoints;

            if(currentMP_Points < 0)
            {
                currentMP_Points = 0;
            }
            manaBar.SetCurrentManaPoints(currentMP_Points);
        }

        public void AddCoins(int coins)
        {
            coinCount += coins;
        }

    }
}

