using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    [CreateAssetMenu(menuName = "Item/Consumables/Recovery Potion")]
    public class VitalityItem : ConsumableItem
    {
        [Header("Potion Type")]

        public bool healthPotion;

        public bool magicPotion;

        [Header("Recovery Amount")]

        public int hpRestoredAmount;

        public int mpRestoredAmount;

        [Header("Animation FX")]

        public GameObject recoveryFX;

        public override void AttemptToConsumeItem(PlayerAnimatorManager playerAnimatorManager, WeaponSlotManager weaponSlotManager, PlayerFXManager playerFXManager)
        {
            base.AttemptToConsumeItem(playerAnimatorManager, weaponSlotManager, playerFXManager);
            //spawn item model
            GameObject potionModel = Instantiate(itemModel, weaponSlotManager.leftHandSlot.transform);
            playerFXManager.currentFX = recoveryFX;
            if (hpRestoredAmount > 0)
            {
                playerFXManager.hp_Restored = hpRestoredAmount;
            }
            if (mpRestoredAmount > 0)
            {
                playerFXManager.mp_Restored = mpRestoredAmount;
            }

            playerFXManager.instantiatedFXModel = potionModel;
            // disable weapon model
            
            weaponSlotManager.rightHandSlot.UnloadWeapon();
            weaponSlotManager.leftHandSlot.UnloadWeapon();

        }

    }
}
