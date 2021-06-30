using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    [CreateAssetMenu]
    public class PlayerProfile : ScriptableObject
    {
        public Weapon[] weaponsInRightHandSlot = new Weapon[2];
        public Weapon[] weaponsInLeftHandSlot = new Weapon[2];

        //public Weapon[] weaponsInRightHandSlot;
        //public Weapon[] weaponsInLeftHandSlot;
        public Helmet[] helmetInSlot = new Helmet[1];
        public ChestArmor[] chestArmorInSlot = new ChestArmor[1];
        public BottomArmor[] bottomArmorInSlot = new BottomArmor[1];
        public SpellItems[] spellInSlot = new SpellItems[4];
        public ConsumableItem[] itemInSlot = new ConsumableItem[4];

        public SaveProfile GetSaveableProfile()
        {
            SaveProfile save = new SaveProfile();
            save.weaponsInRightHandSlot = weaponsInRightHandSlot;
            save.weaponsInLeftHandSlot = weaponsInLeftHandSlot;

            return save;
        }

    }

}