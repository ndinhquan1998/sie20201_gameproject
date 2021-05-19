using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class ConsumableItem : Item
    {
        [Header("Item Quantity")]
        public int maxAmount;
        public int currentAmount;
     

        [Header("Item Model")]
        public GameObject itemModel;

        [Header("Animations")]
        public string consumeAnimation;
        public bool isInteracting;

        public virtual void AttemptToConsumeItem(PlayerAnimatorManager playerAnimatorManager, WeaponSlotManager weaponSlotManager, PlayerFXManager playerFXManager)
        {
            if(currentAmount > 0)
            {
                playerAnimatorManager.PlayTargetAnimation(consumeAnimation, isInteracting, true);

            }
            else
            {
                playerAnimatorManager.PlayTargetAnimation("Empty", true);
            }
        }
    }

}