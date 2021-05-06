using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class CharacterStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public float maxStamina;
        public float currentStamina;

        public int FP_level = 10;
        public float maxFP_Points;
        public float currentFP_Points;

        public int coinCount = 0;

        public bool isDead;

    }
}

