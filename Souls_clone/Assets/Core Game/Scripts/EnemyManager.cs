using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class EnemyManager : CharacterManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
        public bool isPerformingAction;

        [Header("A.I Setting")]
        public float detectionRadius = 20;

        //"eyes's sight" variables
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;

        // Start is called before the first frame update
        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            HandleCurrentAction();
        }
        private void HandleCurrentAction()
        {
            if(enemyLocomotionManager.currentTarget == null)
            {
                enemyLocomotionManager.HandleDectection();
            } else
            {
                {
                    enemyLocomotionManager.HandleMoveToTarget();
                }
            }
        }
    }
}
