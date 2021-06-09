using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerFXManager : MonoBehaviour
    {
        PlayerStats playerStats;
        WeaponSlotManager weaponSlotManager;
        public GameObject currentFX;
        public GameObject instantiatedFXModel;

        public int amountToBeHealed;

        private void Awake()
        {
            playerStats = GetComponentInParent<PlayerStats>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        public void HealEffect()
        {
            playerStats.RestoreHP(amountToBeHealed);
            GameObject healFX = Instantiate(currentFX, playerStats.transform);
            Destroy(instantiatedFXModel.gameObject);
            Destroy(healFX,4);
            weaponSlotManager.ReloadWeapons();
        }
    }
}
