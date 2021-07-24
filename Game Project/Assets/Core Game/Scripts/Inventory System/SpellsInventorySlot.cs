using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class SpellsInventorySlot : MonoBehaviour
    {
        PlayerInventory playerInventory;
        UIManager uiManager;

        public Image icon;
        SpellItems item;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(SpellItems newItem)
        {
            item = newItem;
            icon.sprite = item.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearInventorySlot()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }

        public void EquipThisItem()
        {
            if (uiManager.spell_Slot01Selected)
            {
                playerInventory.spellInventory.Add(playerInventory.playerProfile.spellInSlot[0]);
                playerInventory.playerProfile.spellInSlot[0] = item;
                playerInventory.spellInventory.Remove(item);
            }
            else if (uiManager.spell_Slot02Selected)
            {
                playerInventory.spellInventory.Add(playerInventory.playerProfile.spellInSlot[1]);
                playerInventory.playerProfile.spellInSlot[1] = item;
                playerInventory.spellInventory.Remove(item);
            }
            else if (uiManager.spell_Slot03Selected)
            {
                playerInventory.spellInventory.Add(playerInventory.playerProfile.spellInSlot[2]);
                playerInventory.playerProfile.spellInSlot[2] = item;
                playerInventory.spellInventory.Remove(item);
            }
            else if (uiManager.spell_Slot04Selected)
            {
                playerInventory.spellInventory.Add(playerInventory.playerProfile.spellInSlot[3]);
                playerInventory.playerProfile.spellInSlot[3] = item;
                playerInventory.spellInventory.Remove(item);
            }
            else
            {
                return;
            }
            //remove current item 
            //add current item to inven
            //remove this item from inven
            playerInventory.currentSpell = playerInventory.playerProfile.spellInSlot[playerInventory.currentSpellIndex];

            uiManager.UpdateInventoryUISlots();
            uiManager.equipmentWindowUI.LoadSpellOnEquipmentScreen(playerInventory);
            uiManager.ResetAllSelectedSlots();
        }
    }
}
