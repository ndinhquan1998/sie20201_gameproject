using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class HelmetModelChanger : MonoBehaviour
    {
        public List<GameObject> helmetModels;

        private void Awake()
        {
            GetAllHelmetModels();
        }
        private void GetAllHelmetModels()
        {
            int childGameObjects = transform.childCount;

            for(int i = 0; i< childGameObjects; i++)
            {
                helmetModels.Add(transform.GetChild(i).gameObject);
            }
        }

        public  void UnequipHelmet()
        {
            foreach(GameObject helmetModel in helmetModels)
            {
                helmetModel.SetActive(false);
            }
        }

        public void EquipHelmetModelByName(string helmetName)
        {
            for (int i = 0; i < helmetModels.Count; i++)
            {
                if(helmetModels[i].name == helmetName)
                {
                    helmetModels[i].SetActive(true);
                }
            }
        }
    }
}
