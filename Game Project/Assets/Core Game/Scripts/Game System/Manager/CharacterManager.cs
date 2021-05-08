﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ {
    public class CharacterManager : MonoBehaviour
    {
        [Header("Lock On Transform")]
        public Transform lockOnTransform;

        [Header("Combat Colliders")]
        public DeathblowsCollider backStabCollider;
        public DeathblowsCollider riposteCollider;

        [Header("Combat Flags")]
        public bool canBeRiposted;

        //Damage will be inflicted during an animation event
        //Used in backstab or riposte animations
        public int pendingCriticalDamage;
    }
}
