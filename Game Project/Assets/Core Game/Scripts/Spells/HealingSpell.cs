using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ {
    [CreateAssetMenu(menuName = "Spells/Healing Spell")]

    public class HealingSpell : SpellItems
    {
        public int healAmount;

        public override void AttempToCastSpell(AnimatorHandler animationHandler, PlayerStats playerStats)
        {
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animationHandler.transform);
            animationHandler.PlayTargetAnimation(spellAnimation, true);
            Debug.Log("Casting Spell");
        }        
        
        public override void SuccessfullyCastSpell(AnimatorHandler animationHandler, PlayerStats playerStats)
        {
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, animationHandler.transform);
            playerStats.healPlayer(healAmount);
            Debug.Log("Spell Cast Successful");
        }
    }
}

