using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class EquipmentWindowUI : MonoBehaviour
    {
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



        public HandEquipmentSlotUI[] handEquipmentSlotUI;
        /*        public HelmetEquippedUI[] helmetEquippedUI;
                public ChestArmorEquippedUI[] chestArmorEquippedUI;
                public BottomArmorEquippedUI[] bottomArmorEquippedUI;*/
        public ArmorEquippedUI[] armorEquippedUI;
        public ConsumableEquippedUI[] consumableEquippedUIs;
        public SpellEquippedUI[] spellEquippedUI;

        private void Awake()
        {
            handEquipmentSlotUI = GetComponentsInChildren<HandEquipmentSlotUI>();

            /*            helmetEquippedUI = GetComponentsInChildren<HelmetEquippedUI>();
                        chestArmorEquippedUI = GetComponentsInChildren<ChestArmorEquippedUI>();
                        bottomArmorEquippedUI = GetComponentsInChildren<BottomArmorEquippedUI>();*/
            armorEquippedUI = GetComponentsInChildren<ArmorEquippedUI>();
            consumableEquippedUIs = GetComponentsInChildren<ConsumableEquippedUI>();
            spellEquippedUI = GetComponentsInChildren<SpellEquippedUI>();
        }

        public void LoadWeaponsOnEquipmentScreen(PlayerInventory playerInventory)
        {
            for(int i =0; i <handEquipmentSlotUI.Length; i++)
            {
                if (handEquipmentSlotUI[i].rightHandSlot01)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponsInRightHandSlot[0]);
                } 
                else if (handEquipmentSlotUI[i].rightHandSlot02)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponsInRightHandSlot[1]);
                }
                else if (handEquipmentSlotUI[i].leftHandSlot01)
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponsInLeftHandSlot[0]);
                }
                else
                {
                    handEquipmentSlotUI[i].AddItem(playerInventory.weaponsInLeftHandSlot[1]);
                }
            }
        }

        public void LoadArmorOnEquipmentScreen(PlayerInventory playerInventory)
        {
            for (int i = 0; i < armorEquippedUI.Length; i++)
            {
                if (armorEquippedUI[i].slot01)
                {
                    armorEquippedUI[i].AddHelmet(playerInventory.helmetInSlot[0]);
                }
                else if (armorEquippedUI[i].slot02)
                {
                    armorEquippedUI[i].AddChestArmor(playerInventory.chestArmorInSlot[0]);
                }
                else
                {
                    armorEquippedUI[i].AddBottomArmor(playerInventory.bottomArmorInSlot[0]);
                }
            }
        }

        public void LoadConsumableOnEquipmentScreen(PlayerInventory playerInventory)
        {
            for (int i = 0; i < consumableEquippedUIs.Length; i++)
            {
                if (consumableEquippedUIs[i].slot01)
                {
                    consumableEquippedUIs[i].AddItem(playerInventory.itemInSlot[0]);
                }
                else if (consumableEquippedUIs[i].slot02)
                {
                    consumableEquippedUIs[i].AddItem(playerInventory.itemInSlot[1]);
                }
                else if (consumableEquippedUIs[i].slot03)
                {
                    consumableEquippedUIs[i].AddItem(playerInventory.itemInSlot[2]);
                }
                else
                {
                    consumableEquippedUIs[i].AddItem(playerInventory.itemInSlot[3]);
                }
            }
        }
        public void LoadSpellOnEquipmentScreen(PlayerInventory playerInventory)
        {
            for (int i = 0; i < spellEquippedUI.Length; i++)
            {
                if (spellEquippedUI[i].slot01)
                {
                    spellEquippedUI[i].AddItem(playerInventory.spellInSlot[0]);
                }
                else if (spellEquippedUI[i].slot02)
                {
                    spellEquippedUI[i].AddItem(playerInventory.spellInSlot[1]);
                }
                else if (spellEquippedUI[i].slot03)
                {
                    spellEquippedUI[i].AddItem(playerInventory.spellInSlot[2]);
                }
                else
                {
                    spellEquippedUI[i].AddItem(playerInventory.spellInSlot[3]);
                }
            }
        }

        #region Weapon Selector
        public void SelectRightHandSlot01()
        {
            rightHandSlot01Selected = true;
        }
        public void SelectRightHandSlot02()
        {
            rightHandSlot02Selected = true;
        }
        public void SelectLeftHandSlot01()
        {
            leftHandSlot01Selected = true;
        }
        public void SelectLeftHandSlot02()
        {
            leftHandSlot02Selected = true;
        }
        #endregion

        #region Consumable Selector
        public void SelectConsumableSlot01()
        {
            c_Slot01Selected = true;
        }
        public void SelectConsumableSlot02()
        {
            c_Slot02Selected = true;
        }
        public void SelectConsumableSlot03()
        {
            c_Slot03Selected = true;
        }
        public void SelectConsumableSlot04()
        {
            c_Slot04Selected = true;
        }
        #endregion

        #region Spell Selector
        public void SelectSpellSlot01()
        {
            spell_Slot01Selected = true;
        }
        public void SelectSpellSlot02()
        {
            spell_Slot02Selected = true;
        }
        public void SelectSpellSlot03()
        {
            spell_Slot03Selected = true;
        }
        public void SelectSpellSlot04()
        {
            spell_Slot04Selected = true;
        }
        #endregion

        #region Armor Selector
        public void SelectHelmetSlot()
        {
            helmetSlotSelected = true;
        }
        public void SelectChestArmorSlot()
        {
            bodyArmorSlotSelected = true;
        }
        public void SelectBottomArmorSlot()
        {
            bottomArmorSlotSelected = true;
        }
        #endregion
    }
}

