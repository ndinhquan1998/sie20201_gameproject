using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class WeaponHolderSlot : MonoBehaviour
    {
        public Transform parentOverride;
        public Weapon currentWeapon;
        public bool isLeftHandSlot;
        public bool isRightHandSlot;
        public bool isBackSlot;

        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if(currentWeaponModel != null)
            {
                currentWeaponModel.SetActive(false);
            }
        }

        public void UnloadWeaponAndDestroy()
        {
            if(currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }

        public void LoadWeaponModel(Weapon weaponItem)
        {
            UnloadWeaponAndDestroy();

            if (weaponItem == null)
            {
                //Unload Weapon Model
                UnloadWeapon();
                return;
            }

            GameObject model = Instantiate(weaponItem.modelPrefab);
            if (model != null)
            {
                 if (parentOverride != null)
                {
                           model.transform.parent = parentOverride;
                }
                else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;
            }

            currentWeaponModel = model; 

        }
    }
}

