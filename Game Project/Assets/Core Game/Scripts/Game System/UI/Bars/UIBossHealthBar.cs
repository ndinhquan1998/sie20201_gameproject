using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class UIBossHealthBar : MonoBehaviour
    {
        public Text bossTitle;
        public Slider slider;

        private void Start()
        {
            SetUIHealthBarToInactive();
        }

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
            bossTitle = GetComponentInChildren<Text>();
        }
        public void SetBossTitle(string name)
        {
            bossTitle.text = name;
        }

        public void SetUIHealthBarToActive()
        {
            gameObject.SetActive(true);
        }
        public void SetUIHealthBarToInactive()
        {
            gameObject.SetActive(false);
        }

        public void SetBossMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        public void SetBossCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;
        }
    }

}

