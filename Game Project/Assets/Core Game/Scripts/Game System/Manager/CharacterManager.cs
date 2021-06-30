using System.Collections;
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
        public bool canBeParried;
        public bool isParrying;
        public bool isBlocking;
        public bool isDealingLightAttack;
        public bool isDealingHeavyAttack;
        public bool isUsingRightHand;
        public bool isUsingLeftHand;

        [Header("Movement Flags")]
        public bool isRotatingWithRootMotion;
        public bool canRotate;

        [Header("Spell Flags")]
        public bool isFiringSpell;

        //Damage will be inflicted during an animation event
        //Used in backstab or riposte animations
        public int pendingCriticalDamage;


 

    }
}
