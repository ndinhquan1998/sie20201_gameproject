using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class BottomArmorEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        BottomArmor bottomArmor;


        public bool slot01;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(BottomArmor newItem)
        {
            bottomArmor = newItem;
            icon.sprite = bottomArmor.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearItem()
        {
            bottomArmor = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.bottomArmorSlotSelected = true;
            }
        }
    }
}


