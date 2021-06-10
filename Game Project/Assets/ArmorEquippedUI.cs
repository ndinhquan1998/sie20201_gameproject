using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class ArmorEquippedUI : MonoBehaviour
    {
        UIManager uiManager;
        public Image icon;
        Helmet helmet;
        ChestArmor chestArmor;
        BottomArmor bottomArmor;


        public bool slot01;
        public bool slot02;
        public bool slot03;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        #region Helmet
        public void AddHelmet(Helmet newItem)
        {
            helmet = newItem;
            icon.sprite = helmet.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearHelmet()
        {
            helmet = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        #endregion

        #region Body
        public void AddChestArmor(ChestArmor newItem)
        {
            chestArmor = newItem;
            icon.sprite = chestArmor.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearChestArmor()
        {
            chestArmor = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        #endregion

        #region Bottom
        public void AddBottomArmor(BottomArmor newItem)
        {
            bottomArmor = newItem;
            icon.sprite = bottomArmor.itemIcon;
            icon.enabled = true;
            gameObject.SetActive(true);

        }

        public void ClearBottomArmor()
        {
            bottomArmor = null;
            icon.sprite = null;
            icon.enabled = false;
            gameObject.SetActive(false);

        }
        #endregion




        public void SelectThisSlot()
        {
            if (slot01)
            {
                uiManager.helmetSlotSelected = true;
            }
            else if (slot02)
            {
                uiManager.bodyArmorSlotSelected = true;
            }
            else
            {
                uiManager.bottomArmorSlotSelected = true;
            }
        }
    }
}


