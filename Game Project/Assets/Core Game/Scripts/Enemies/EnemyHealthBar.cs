using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DQ
{
    public class EnemyHealthBar : MonoBehaviour
    {
        public Slider slider;
 
        //EnemyStats enemy = null;
        //  initialization
        void Start()
        {
            slider = GetComponent<Slider>();
            //enemy = GetComponentInParent<EnemyStats>(); // Different to way player's health bar finds player
        }

 
         public void SetMaxHealth(int maxHealth) 
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }
        public void SetCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;
        }
    }
}


