using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class EnemyFXManager : MonoBehaviour
    {
        EnemyStats enemyStats;
        EnemyManager enemyManager;
        WeaponSlotManager weaponSlotManager;
        public GameObject currentFX;
        public GameObject instantiatedFXModel;

        public Vector3 collisionPosition;
        public Quaternion collisitionRotation;

        public int amountToBeHealed;

        private void Awake()
        {
            enemyStats = GetComponentInParent<EnemyStats>();
            enemyManager = GetComponentInParent<EnemyManager>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        public void AttackEffect()
        {
            GameObject slamFX = Instantiate(currentFX, collisionPosition, Quaternion.identity);
            Debug.Log(slamFX.transform.position);
            Destroy(slamFX, 4);


        }

        public void HealEffect()
        {
            //enemyStats.RestoreHP(amountToBeHealed);
            GameObject healFX = Instantiate(currentFX, enemyStats.transform);
            Destroy(instantiatedFXModel.gameObject);
            Destroy(healFX, 4);
            weaponSlotManager.ReloadWeapons();
        }
    }
}
