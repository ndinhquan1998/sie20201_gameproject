﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    [CreateAssetMenu(menuName ="A.I/Enemy Actions/Attack Action")]
    public class EnemyAttackAction : EnemyAction
    {

        public bool canDoCombo;
        public bool usingWeapon;
        public bool isLeft;

        public EnemyAttackAction comboAction;

        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximumAttackAngle = 35 ;
        public float minimumAttackAngle = -35;

        public float maximumDistanceNeededToAttack = 3;
        public float minimumDistanceNeededToAttack = 0;

    }
}

