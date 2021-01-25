using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class SpellItems : Item
    {
        public GameObject spellWarmUpFX;
        public GameObject spellCastFX;
        public string spellAnimation;

        [Header("Spell Types")]
        public bool isHolySpell;
        public bool isMagicSpell;
        public bool isPyroSpell;

        [Header("Spell Descriptions")]
        [TextArea]
        public string spellDescription;

        public virtual void AttempToCastSpell(AnimatorHandler animationHandler, PlayerStats playerStats)
        {
            Debug.Log("Casting Spell");
        }        
        public virtual void SuccessfullyCastSpell(AnimatorHandler animationHandler, PlayerStats playerStats)
        {
            Debug.Log("Casting Spell successful");
        }
    }

}
