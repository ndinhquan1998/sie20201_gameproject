﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class EnemyStats : CharacterStats
    {

        Animator animator;
        public EnemyHealthBar healthBar;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            healthBar = FindObjectOfType<EnemyHealthBar>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            animator.Play("Damage_01");

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Death_01");
                //Handler death 
            }
        }
    }
}

