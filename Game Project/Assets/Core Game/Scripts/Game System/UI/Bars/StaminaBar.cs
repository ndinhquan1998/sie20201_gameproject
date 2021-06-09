using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class StaminaBar : MonoBehaviour
    {
        public Slider slider;
        float timeUntilBarIsHidden = 0;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
        private void Start()
        {
            slider = GetComponentInChildren<Slider>();
        }
        private void Update()
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
            }
        }
        public void SetMaxStamina(float maxStamina)
        {
            slider.maxValue = maxStamina;
            slider.value = maxStamina;
        }
        public void SetCurrentStamina(float currentStamina)
        {
            slider.value = currentStamina;
            timeUntilBarIsHidden = 3;
        }
    }
}

