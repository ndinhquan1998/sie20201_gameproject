using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class MPBar : MonoBehaviour
    {
        public Slider slider;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void SetMaxManaPoints(float maxFocusPoints)
        {
            slider.maxValue = maxFocusPoints;
            slider.value = maxFocusPoints;
        }

        public void SetCurrentManaPoints(float currentFocusPoints)
        {
            slider.value = currentFocusPoints;
        }
    }
}
