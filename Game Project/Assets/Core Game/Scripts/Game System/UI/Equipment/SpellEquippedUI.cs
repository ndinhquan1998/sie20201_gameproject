using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class SpellEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        SpellItems spellItems;

        public bool slot01;
        public bool slot02;
        public bool slot03;
        public bool slot04;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(SpellItems newItem)
        {
            spellItems = newItem;
            icon.sprite = spellItems.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearItem()
        {
            spellItems = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.spell_Slot01Selected = true;
            }
            else if (slot02)
            {
                uiManager.spell_Slot02Selected = true;
            }
            else if (slot03)
            {
                uiManager.spell_Slot03Selected = true;
            }
            else
            {
                uiManager.spell_Slot04Selected = true;
            }
        }
    }
}
