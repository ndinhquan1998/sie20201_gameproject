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

        [Header("Spell Cost")]
        public int focusPointCost;

        [Header("Spell Types")]
        public bool isHolySpell;
        public bool isMagicSpell;
        public bool isPyroSpell;

        [Header("Spell Descriptions")]
        [TextArea]
        public string spellDescription;

        public virtual void AttempToCastSpell(PlayerAnimatorManager animationHandler, PlayerStats playerStats)
        {
            Debug.Log("Casting Spell");

        }        
        public virtual void SuccessfullyCastSpell(PlayerAnimatorManager animationHandler, PlayerStats playerStats)
        {
            Debug.Log("Casting Spell successful");
            playerStats.DeductFocusPoints(focusPointCost);
        }
    }

}
