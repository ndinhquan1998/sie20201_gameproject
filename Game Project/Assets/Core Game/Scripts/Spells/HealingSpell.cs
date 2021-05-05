using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ {
    [CreateAssetMenu(menuName = "Spells/Healing Spell")]

    public class HealingSpell : SpellItems
    {
        public int healAmount;

        public override void AttempToCastSpell(PlayerAnimatorManager animationHandler, PlayerStats playerStats)
        {
            base.AttempToCastSpell(animationHandler, playerStats);
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animationHandler.transform);
            animationHandler.PlayTargetAnimation(spellAnimation, true);
            Debug.Log("Casting Spell");
        }        
        
        public override void SuccessfullyCastSpell(PlayerAnimatorManager animationHandler, PlayerStats playerStats)
        {
            //whenever we use the successfully cast spell it will also fire this function from the class it derives from on Spell_Item
            base.SuccessfullyCastSpell(animationHandler, playerStats);
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, animationHandler.transform);
            playerStats.healPlayer(healAmount);
            Debug.Log("Spell Cast Successful");
        }
    }
}

