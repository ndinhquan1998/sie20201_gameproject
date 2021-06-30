using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class EnemyBossManager : MonoBehaviour
    {
        public string bossTitle;

        public UIBossHealthBar bossHealthBar;
        UIManager ui;


        EnemyStats enemyStats;
        private void Awake()
        {
            //bossHealthBar = FindObjectOfType<UIBossHealthBar>();
            ui = FindObjectOfType<UIManager>();
            enemyStats = GetComponent<EnemyStats>();
        }



        private void Start()
        {
            bossHealthBar.SetBossTitle(bossTitle);
            bossHealthBar.SetBossMaxHealth(enemyStats.MaxHealth);           
        }

        private void FixedUpdate()
        {
            bossHealthBar.SetBossCurrentHealth(enemyStats.CurrentHealth);
            if(enemyStats.CurrentHealth <= 0)
            {
                bossHealthBar.SetUIHealthBarToInactive();
            }
        }

        public void EnableBar()
        {
            bossHealthBar.SetUIHealthBarToActive();
        }
    }
}
