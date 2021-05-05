using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DQ
{
    public class PlayerStats : CharacterStats
    {


        public HealthBar healthBar;
        public StaminaBar staminaBar;
        public FPBar focusPointBar;
        PlayerManager playerManager;
        PlayerAnimatorManager animatorHandler;


        public float staminaRegenerationAmount = 1;
        public float staminaRegenTimer = 0;
        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            focusPointBar = FindObjectOfType<FPBar>();
            animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);

            maxStamina = SetMaxStaminaFromLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
            staminaBar.SetCurrentStamina(currentStamina);

            maxFP_Points = SetMaxFocusPointFromLevel();
            currentFP_Points = maxFP_Points;
            focusPointBar.SetMaxFocusPoints(maxFP_Points);
            focusPointBar.SetCurrentFocusPoints(currentFP_Points);
            
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }        
        
        private float SetMaxStaminaFromLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }        
        
        private float SetMaxFocusPointFromLevel()
        {
            maxFP_Points = FP_level * 10;
            return maxFP_Points;
        }

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
            }
        }

        public void TakeDamage(int damage)
        {
            if (playerManager.isInvulnerable)
                return;
            if (isDead)
                return;

            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Death_01", true);
                isDead = true;
                //Handler death 
                //Handle respawn 
                StartCoroutine(Restart(4, this.gameObject));
            }

        }
        IEnumerator Restart(int seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void TakeStamina(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void AddHealth()
        {
            currentHealth += 20;
            healthBar.SetCurrentHealth(currentHealth);
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

        public void healPlayer(int healthAmount)
        {
            currentHealth = currentHealth + healthAmount;

            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetCurrentHealth(currentHealth);
        }

        public void DeductFocusPoints(int focusPoints)
        {
            currentFP_Points = currentFP_Points - focusPoints;

            if(currentFP_Points < 0)
            {
                currentFP_Points = 0;
            }
            focusPointBar.SetCurrentFocusPoints(currentFP_Points);
        }
    }
}

