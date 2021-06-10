using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class ArmorInventorySlot : MonoBehaviour
    {
        PlayerInventory playerInventory;
        WeaponSlotManager weaponSlotManager;
        UIManager uiManager;

        public Image icon;
        Helmet item_H;
        ChestArmor item_C;
        BottomArmor item_B;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
            uiManager = FindObjectOfType<UIManager>();
        }
        #region Helmet
        public void AddHelmetItem(Helmet newItem)
        {
            item_H = newItem;
            icon.sprite = item_H.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearHelmetSlot()
        {
            item_H = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }
        #endregion

        #region Chest
        public void AddChestItem(ChestArmor newItem)
        {
            item_C = newItem;
            icon.sprite = item_C.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearChestSlot()
        {
            item_C = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }
        #endregion

        #region Bottom
        public void AddBottomItem(BottomArmor newItem)
        {
            item_B = newItem;
            icon.sprite = item_B.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);
        }

        public void ClearBottomSlot()
        {
            item_B = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);
        }
        #endregion


        public void EquipThisItem()
        {
            if (uiManager.helmetSlotSelected)
            {
                playerInventory.helmetsInventory.Add(playerInventory.helmetInSlot[0]);
                playerInventory.helmetInSlot[0] = item_H;
                playerInventory.helmetsInventory.Remove(item_H);
            }
            else if (uiManager.bodyArmorSlotSelected)
            {
                playerInventory.chestArmorsInventory.Add(playerInventory.chestArmorInSlot[0]);
                playerInventory.chestArmorInSlot[0] = item_C;
                playerInventory.chestArmorsInventory.Remove(item_C);
            }
            else if (uiManager.bottomArmorSlotSelected)
            {
                playerInventory.bottomArmorsInventory.Add(playerInventory.bottomArmorInSlot[0]);
                playerInventory.bottomArmorInSlot[0] = item_B;
                playerInventory.bottomArmorsInventory.Remove(item_B);
            }
            else
            {
                return;
            }
            //remove current item 
            //add current item to inven
            //remove this item from inven
            playerInventory.currentHelmetEquipment = playerInventory.helmetInSlot[0];
            playerInventory.currentChestArmorEquipment = playerInventory.chestArmorInSlot[0];
            playerInventory.currentBottomArmorEquipment = playerInventory.bottomArmorInSlot[0];


            uiManager.equipmentWindowUI.LoadArmorOnEquipmentScreen(playerInventory);
            uiManager.ResetAllSelectedSlots();
        }
    }
}


