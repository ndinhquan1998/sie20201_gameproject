using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class Item : ScriptableObject
    {
        [Header("Item Info")]
        public string itemName;
        public Sprite itemIcon;
    }
}

