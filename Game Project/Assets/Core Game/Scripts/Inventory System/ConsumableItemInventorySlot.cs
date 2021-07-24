using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class ConsumableItemInventorySlot : MonoBehaviour
    {
        PlayerInventory playerInventory;
        UIManager uiManager;

        public Image icon;
        ConsumableItem item;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(ConsumableItem newItem)
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
            if (uiManager.c_Slot01Selected)
            {
                playerInventory.c_itemInventory.Add(playerInventory.playerProfile.itemInSlot[0]);
                playerInventory.playerProfile.itemInSlot[0] = item;
                playerInventory.c_itemInventory.Remove(item);
            }
            else if (uiManager.c_Slot02Selected)
            {
                playerInventory.c_itemInventory.Add(playerInventory.playerProfile.itemInSlot[1]);
                playerInventory.playerProfile.itemInSlot[1] = item;
                playerInventory.c_itemInventory.Remove(item);
            }
            else if (uiManager.c_Slot03Selected)
            {
                playerInventory.c_itemInventory.Add(playerInventory.playerProfile.itemInSlot[2]);
                playerInventory.playerProfile.itemInSlot[2] = item;
                playerInventory.c_itemInventory.Remove(item);
            }
            else if (uiManager.c_Slot04Selected)
            {
                playerInventory.c_itemInventory.Add(playerInventory.playerProfile.itemInSlot[3]);
                playerInventory.playerProfile.itemInSlot[3] = item;
                playerInventory.c_itemInventory.Remove(item);
            }
            else
            {
                return;
            }
            //remove current item 
            //add current item to inven
            //remove this item from inven
            playerInventory.currentConsumable = playerInventory.playerProfile.itemInSlot[playerInventory.currentItemIndex];

            uiManager.UpdateInventoryUISlots();
            uiManager.equipmentWindowUI.LoadConsumableOnEquipmentScreen(playerInventory);
            uiManager.ResetAllSelectedSlots();
        }
    }

}