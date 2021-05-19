using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class BottomArmorModelChanger : MonoBehaviour
    {
        public List<GameObject> bottomArmorModels;

        private void Awake()
        {
            GetAllBottomArmorModels();
        }
        private void GetAllBottomArmorModels()
        {
            int childGameObjects = transform.childCount;

            for (int i = 0; i < childGameObjects; i++)
            {
                bottomArmorModels.Add(transform.GetChild(i).gameObject);
            }
        }

        public void UnequipArmor()
        {
            foreach (GameObject model in bottomArmorModels)
            {
                model.SetActive(false);
            }
        }

        public void EquipArmorModelByName(string armorName)
        {
            for (int i = 0; i < bottomArmorModels.Count; i++)
            {
                if (bottomArmorModels[i].name == armorName)
                {
                    bottomArmorModels[i].SetActive(true);
                }
            }
        }
    }
}

