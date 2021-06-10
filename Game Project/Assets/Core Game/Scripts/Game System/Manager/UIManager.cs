using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class UIManager : MonoBehaviour
    {
        public PlayerInventory playerInventory;
        public EquipmentWindowUI equipmentWindowUI;

        [Header("UI WIndows")]
        public GameObject hudWindow;
        public GameObject selectWindow;
        public GameObject equipmentScreenWindow;
        public GameObject weaponInventoryWindow;

        [Header("Weapon Window Slot Selected")]
        public bool rightHandSlot01Selected;
        public bool rightHandSlot02Selected;
        public bool leftHandSlot01Selected;
        public bool leftHandSlot02Selected;
        
        [Header("Armor Equipment Window Slot Selected")]
        public bool helmetSlotSelected;
        public bool bodyArmorSlotSelected;
        public bool bottomArmorSlotSelected;
        
        [Header("Consumable Window Slot Selected")]
        public bool c_Slot01Selected;
        public bool c_Slot02Selected;
        public bool c_Slot03Selected;
        public bool c_Slot04Selected;
        
        [Header("Spell Window Slot Selected")]
        public bool spell_Slot01Selected;
        public bool spell_Slot02Selected;
        public bool spell_Slot03Selected;
        public bool spell_Slot04Selected;

        [Header("Weapon Inventory")]
        public GameObject weaponInventorySlotPrefab;
        public Transform weaponInventorySlotsParent;
        WeaponInventorySlot[] weaponInventorySlots;

/*        private void Awake()
        {
            equipmentWindowUI = FindObjectOfType<EquipmentWindowUI>();
        }*/
        private void Start()
        {
            weaponInventorySlots = weaponInventorySlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
            equipmentWindowUI.LoadWeaponsOnEquipmentScreen(playerInventory);
        }
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
        public void CloseAllInventoryWindow()
        {
            ResetAllSelectedSlots();
            weaponInventoryWindow.SetActive(false);
            equipmentScreenWindow.SetActive(false);
        }

        public void ResetAllSelectedSlots()
        {
            rightHandSlot01Selected = false;
            rightHandSlot02Selected = false;
            leftHandSlot01Selected = false;
            leftHandSlot02Selected = false;

            helmetSlotSelected = false;
            bodyArmorSlotSelected = false;
            bottomArmorSlotSelected = false;

            c_Slot01Selected = false;
            c_Slot02Selected = false;
            c_Slot03Selected = false;
            c_Slot04Selected = false;

            spell_Slot01Selected = false;
            spell_Slot02Selected = false;
            spell_Slot03Selected = false;
            spell_Slot04Selected = false;
        }
    }
}

