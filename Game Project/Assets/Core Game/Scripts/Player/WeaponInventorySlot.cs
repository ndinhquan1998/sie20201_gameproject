using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{    
    public class WeaponInventorySlot : MonoBehaviour
    {
        PlayerInventory playerInventory;
        WeaponSlotManager weaponSlotManager;
        UIManager uiManager;

        public Image icon;
        Weapon item;

        private void Awake()
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(Weapon newItem)
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
            if (uiManager.rightHandSlot01Selected)
            {
                playerInventory.weaponsInventory.Add(playerInventory.playerProfile.weaponsInRightHandSlot[0]);
                playerInventory.playerProfile.weaponsInRightHandSlot[0] = item;
                playerInventory.weaponsInventory.Remove(item);
            }
            else if (uiManager.rightHandSlot02Selected)
            {
                playerInventory.weaponsInventory.Add(playerInventory.playerProfile.weaponsInRightHandSlot[1]);
                playerInventory.playerProfile.weaponsInRightHandSlot[1] = item;
                playerInventory.weaponsInventory.Remove(item);
            } 
            else if (uiManager.leftHandSlot01Selected)
            {
                playerInventory.weaponsInventory.Add(playerInventory.playerProfile.weaponsInLeftHandSlot[0]);
                playerInventory.playerProfile.weaponsInLeftHandSlot[0] = item;
                playerInventory.weaponsInventory.Remove(item);
            }
            else if (uiManager.leftHandSlot01Selected)
            {
                playerInventory.weaponsInventory.Add(playerInventory.playerProfile.weaponsInLeftHandSlot[1]);
                playerInventory.playerProfile.weaponsInLeftHandSlot[1] = item;
                playerInventory.weaponsInventory.Remove(item);
            }
            else
            {
                return;
            }
            //remove current item 
            //add current item to inven
            //remove this item from inven
            playerInventory.rightWeapon = playerInventory.playerProfile.weaponsInRightHandSlot[playerInventory.currentRightWeaponIndex];
            playerInventory.leftWeapon = playerInventory.playerProfile.weaponsInLeftHandSlot[playerInventory.currentLeftWeaponIndex];

            weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, true);

            uiManager.equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);
            uiManager.ResetAllSelectedSlots();
        }
    }
}

