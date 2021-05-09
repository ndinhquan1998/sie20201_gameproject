using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    [CreateAssetMenu(menuName = "Item/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Damage")]
        public int baseDamage = 25 ;
        public int criticalDamageMultiplier = 4;
        
        [Header("Idle Animation")]
        public string right_hand_idle;
        public string left_hand_idle;
        public string two_hand_idle;

        [Header("One Handed Attack Animation")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;        
        
        [Header("Two Handed Attack Animation")]
        public string TH_Light_Attack_1;
        public string TH_Light_Attack_2;
        public string TH_Heavy_Attack_1;

        [Header("Weapon Art")]
        public string weapon_Art; 

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;

        [Header("Weapon Type")]
        public bool isSpellCaster;
        public bool isHolyCaster;
        public bool isPyroCaster;
        public bool isMeleeWeapon;
        public bool isShieldWeapon;

    }
}

