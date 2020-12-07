using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class UIManager : MonoBehaviour
    {
        public PlayerInventory playerInventory;

        public GameObject selectWindow;

        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        WeaponInventorySlot[] weaponInventorySlots;

        public void UpdateUI()
        {
            #region Weapon Inventory Slots 
            for (int i = 0; i < weaponInventorySlots.Length; i++)
            {
                if (i < playerInventory.weaponsInventory.Count)
                {
                    if (weaponInventorySlots.Length < playerInventory.weaponsInventory.Count)
                    {
                        Instantiate(weaponInventorySlotPrefab, weaponInventorySlotsParent);
                        weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                    }
                    weaponInventorySlots[i].AddItem(playerInventory.weaponsInventory[i]);
                }
                else
                {
                    weaponInventorySlots[i].ClearInventorySlot();
                }
            }
            #endregion
        }
        public void OpenSelectWindows()
        {
            selectWindow.SetActive(true);
        }        
        public void CloseSelectWindows()
        {
            selectWindow.SetActive(false);
        }
    }
}

