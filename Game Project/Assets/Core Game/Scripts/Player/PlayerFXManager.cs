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

        public int hp_Restored;
        public int mp_Restored;

        private void Awake()
        {
            playerStats = GetComponentInParent<PlayerStats>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        public void HealEffect()
        {
            if(hp_Restored > 0 )
            {
                playerStats.RestoreHP(hp_Restored);
            }
            if (mp_Restored > 0)
            {
                playerStats.RestoreMP(mp_Restored);
            }
            
            GameObject healFX = Instantiate(currentFX, playerStats.transform);
            Destroy(instantiatedFXModel.gameObject);
            Destroy(healFX,4);
            weaponSlotManager.ReloadWeapons();
        }
    }
}
