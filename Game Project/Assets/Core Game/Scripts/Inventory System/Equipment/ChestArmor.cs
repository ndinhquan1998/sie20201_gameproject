using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    [CreateAssetMenu(menuName = "Item/Gears/Chest Armor")]
    public class ChestArmor : Equipment
    {
        //name of the gameobject not in-game item
        public string armorModelName;
        public string upperLeftArmModelName;
        public string upperRightArmModelName;
        public string lowerLeftArmModelName;
        public string lowerRightArmModelName;
        public string rightShoulderModelName;
        public string leftShoulderModelName;
    }
}

