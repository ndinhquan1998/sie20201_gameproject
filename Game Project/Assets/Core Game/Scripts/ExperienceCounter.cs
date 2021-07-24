using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DQ
{
    public class ExperienceCounter : MonoBehaviour
    {
        public Text expCountText;

        public void SetExpText(int count)
        {
            expCountText.text = count.ToString();
        }
    }
}


