using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DQ
{
    public class ConsumableEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        ConsumableItem consumableItem  ;

        public bool slot01;
        public bool slot02;
        public bool slot03;
        public bool slot04;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(ConsumableItem newItem)
        {
            consumableItem = newItem;
            icon.sprite = consumableItem.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearItem()
        {
            consumableItem = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.c_Slot01Selected = true;
            }
            else if (slot02)
            {
                uiManager.c_Slot02Selected = true;
            }
            else if (slot03)
            {
                uiManager.c_Slot03Selected = true;
            }
            else 
            {
                uiManager.c_Slot04Selected = true;
            }
        }
    }
}


