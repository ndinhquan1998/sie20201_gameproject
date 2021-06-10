using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class ChestArmorEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        ChestArmor chestArmor;


        public bool slot01;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(ChestArmor newItem)
        {
            chestArmor = newItem;
            icon.sprite = chestArmor.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearItem()
        {
            chestArmor = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.bodyArmorSlotSelected = true;
            }
        }
    }
}
