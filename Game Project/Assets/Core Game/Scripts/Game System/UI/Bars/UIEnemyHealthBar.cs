using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class UIEnemyHealthBar : MonoBehaviour
    {
        Slider slider;
        float timeUntilBarIsHidden = 0;

        private void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
        }
        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }

        public void SetHealth(int health)
        {
            slider.value = health;
            timeUntilBarIsHidden = 6;
        }

        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        private void FixedUpdate()
        {
            timeUntilBarIsHidden = timeUntilBarIsHidden - Time.deltaTime;

            if (slider != null)
            {
                if (timeUntilBarIsHidden <= 0)
                {
                    timeUntilBarIsHidden = 0;
                    slider.gameObject.SetActive(false);
                }
                else
                {
                    if (!slider.gameObject.activeInHierarchy)
                    {
                        slider.gameObject.SetActive(true);
                    }
                }

                if (slider.value <= 0)
                {
                    StartCoroutine(DestroyHPBar());
                }
            }
        }

        IEnumerator DestroyHPBar()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(slider.gameObject);
        }
    }
}
