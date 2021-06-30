using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class SpawnEnemy : MonoBehaviour
    {
        public int maxAmount;
        public int minAmount;
        public GameObject[] enemyPrefabs;

        private void Start()
        {
            int rand = Random.Range(minAmount, maxAmount + 1);
            for (int i = 0; i< rand; i++)
            {
                int r = Random.Range(0, enemyPrefabs.Length);

                GameObject go = Instantiate(enemyPrefabs[r]);
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
            }
        }
    }
}
