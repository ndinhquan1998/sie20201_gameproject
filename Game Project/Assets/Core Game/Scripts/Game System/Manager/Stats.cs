using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DQ
{
    [CreateAssetMenu(menuName = "Object Stats")]
    [System.Serializable]
    public class Stats : ScriptableObject

    {
        public int healthLevel;
 
        public int staminaLevel;
 

        public int MP_level;

    }

}