using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class EnemyAnimatorManager : AnimatorManager
    {
        EnemyManager enemyManager;
        EnemyStats enemyStats;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            enemyManager = GetComponentInParent<EnemyManager>();
            enemyStats = GetComponentInParent<EnemyStats>();
        }

        public override void TakeCriticalDamageAnimationEvent()
        {
            enemyStats.TakeDamageNoAnimation(enemyManager.pendingCriticalDamage);
            enemyManager.pendingCriticalDamage = 0;
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            enemyManager.enemyRigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            enemyManager.enemyRigidbody.velocity = velocity;
        }

        public void DroppingCoinOnDeath()
        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            CurrencyCounter currencyCounter = FindObjectOfType<CurrencyCounter>();

            if (playerStats != null)
            {
                playerStats.AddCoins(enemyStats.coinsDrop);
                if (currencyCounter != null)
                {
                    currencyCounter.SetCoinText(playerStats.coinCount);
                }
            }
        }
    }
}