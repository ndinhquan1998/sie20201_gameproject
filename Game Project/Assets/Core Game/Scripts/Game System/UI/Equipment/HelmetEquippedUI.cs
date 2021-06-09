using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class HelmetEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        Helmet helmet;
 

        public bool slot01;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        public void AddItem(Helmet newItem)
        {
            helmet = newItem;
            icon.sprite = helmet.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearItem()
        {
            helmet = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.helmetSlotSelected = true;
            }
        }
    }
}


