using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class QuickSlotsUI : MonoBehaviour
    {
        public Image leftWeaponIcon;
        public Image rightWeaponIcon;
        public Image consumableIcon;
        public Image spellIcon;

        public void UpdateItemQuickSlotUI(ConsumableItem item)
        {
            if (item.itemIcon != null)
            {
                consumableIcon.sprite = item.itemIcon;
                consumableIcon.enabled = true;
            }
            else
            {
                consumableIcon.sprite = null;
                consumableIcon.enabled = false;
            }
        }        
        public void UpdateSpellQuickSlotUI(SpellItems spell)
        {
            if (spell.itemIcon != null)
            {
                spellIcon.sprite = spell.itemIcon;
                spellIcon.enabled = true;
            }
            else
            {
                spellIcon.sprite = null;
                spellIcon.enabled = false;
            }
        }
        public void UpdateWeaponQuickSlotsUI(bool isLeft, Weapon weapon)
        {
            if(isLeft == false)
            {
                if(weapon.itemIcon != null)
                {
                    rightWeaponIcon.sprite = weapon.itemIcon;
                    rightWeaponIcon.enabled = true;
                }
                else
                {
                    rightWeaponIcon.sprite = null;
                    rightWeaponIcon.enabled = false;
                }

            } 
            else
            {
                if (weapon.itemIcon != null)
                {
                    leftWeaponIcon.sprite = weapon.itemIcon;
                    leftWeaponIcon.enabled = true;
                }
                else
                {
                    leftWeaponIcon.sprite = null;
                    leftWeaponIcon.enabled = false;
                }

            }
        }
    }

}
