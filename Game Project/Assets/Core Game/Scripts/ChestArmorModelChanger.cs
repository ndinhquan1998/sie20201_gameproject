using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class ChestArmorModelChanger : MonoBehaviour
    {
        public List<GameObject> chestArmorModels;

        private void Awake()
        {
            GetAllChestArmorModels();
        }
        private void GetAllChestArmorModels()
        {
            int childGameObjects = transform.childCount;

            for (int i = 0; i < childGameObjects; i++)
            {
                chestArmorModels.Add(transform.GetChild(i).gameObject);
            }
        }

        public void UnequipChestArmor()
        {
            foreach (GameObject model in chestArmorModels)
            {
                model.SetActive(false);
            }
        }

        public void EquipChestArmorModelByName(string helmetName)
        {
            for (int i = 0; i < chestArmorModels.Count; i++)
            {
                if (chestArmorModels[i].name == helmetName)
                {
                    chestArmorModels[i].SetActive(true);
                }
            }
        }
    }

}