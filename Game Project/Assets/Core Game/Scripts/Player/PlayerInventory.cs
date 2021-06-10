using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;
        QuickSlotsUI quickSlotsUI;

        [Header("Quick Slot")]
        //current Items
        public Weapon rightWeapon;
        public Weapon leftWeapon;
        public SpellItems currentSpell;
        public ConsumableItem currentConsumable;

        [Header("Current Gear Equipment")]
        public Helmet currentHelmetEquipment;
        public ChestArmor currentChestArmorEquipment;
        public BottomArmor currentBottomArmorEquipment;


        public Weapon unarmedWeapon;

        public Weapon[] weaponsInRightHandSlot = new Weapon[1];
        public Weapon[] weaponsInLeftHandSlot = new Weapon[1];
        public Helmet[]  helmetInSlot = new Helmet[0];
        public ChestArmor[] chestArmorInSlot = new ChestArmor[0];
        public BottomArmor[] bottomArmorInSlot = new BottomArmor[0];
        public SpellItems[] spellInSlot = new SpellItems[3];
        public ConsumableItem[] itemInSlot = new ConsumableItem[3];

        public int currentRightWeaponIndex ;
        public int currentLeftWeaponIndex;
        public int currentSpellIndex;
        public int currentItemIndex;

        //Inventory Types
        public List<Weapon> weaponsInventory;
        public List<Helmet> helmetsInventory;
        public List<ChestArmor> chestArmorsInventory;
        public List<BottomArmor> bottomArmorsInventory;
        public List<SpellItems> spellInventory;
        public List<ConsumableItem> c_itemInventory;

        private void Awake()
        {
            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();       
        }

        private void Start()
        {
            //weapon
            rightWeapon = weaponsInRightHandSlot[0];
            leftWeapon = weaponsInLeftHandSlot[0];
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);

            //gear
            currentHelmetEquipment = helmetInSlot[0];

            currentChestArmorEquipment = chestArmorInSlot[0];

            currentBottomArmorEquipment = bottomArmorInSlot[0];

            //item
            currentConsumable = itemInSlot[0];
            LoadItemOnSlot(currentConsumable);

            //spell
            currentSpell = spellInSlot[0];
            LoadSpellOnSlot(currentSpell);      

        }
        public void LoadItemOnSlot(ConsumableItem consumableItem)
        {
            quickSlotsUI.UpdateItemQuickSlotUI(consumableItem);
        }
        public void LoadSpellOnSlot(SpellItems spellItem)
        {
            quickSlotsUI.UpdateSpellQuickSlotUI(spellItem);
        }
        public void ChangeRightWeapon()
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;

            if(currentRightWeaponIndex == 0 && weaponsInRightHandSlot[0] != null)
            {
                rightWeapon = weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlot[currentRightWeaponIndex], false);
            } 
            else if (currentRightWeaponIndex == 0 && weaponsInRightHandSlot[0] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }
            else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlot[1] != null)
            {
                rightWeapon = weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlot[currentRightWeaponIndex], false);
            }
            else if (currentRightWeaponIndex == 1 && weaponsInRightHandSlot[1] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }

            if(currentRightWeaponIndex > weaponsInRightHandSlot.Length - 1)
            {
                currentRightWeaponIndex = 0;
                rightWeapon = weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlot[currentRightWeaponIndex], false);
                //rightWeapon = unarmedWeapon;
                //weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, false);
            }

        }        
        public void ChangeLeftWeapon()
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            if(currentLeftWeaponIndex ==0 && weaponsInLeftHandSlot[0] != null)
            {
                leftWeapon = weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
            } 
            else if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlot[0] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }
            else if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlot[1] != null)
            {
                leftWeapon = weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
            }
            else if(currentLeftWeaponIndex == 1 && weaponsInLeftHandSlot[1] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }

            if(currentLeftWeaponIndex > weaponsInLeftHandSlot.Length - 1)
            {
                currentLeftWeaponIndex = 0;
                leftWeapon = weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
                //leftWeapon = unarmedWeapon;
                //weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, true);
            }
        }

        public void ChangeSpellItem()
        {
            currentSpellIndex = currentSpellIndex + 1;
            if (currentSpellIndex == 0 && spellInSlot[0] != null)
            {
                currentSpell = spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 0 && spellInSlot[0] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 1 && spellInSlot[1] != null)
            {
                currentSpell = spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 1 && spellInSlot[1] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 2 && spellInSlot[2] != null)
            {
                currentSpell = spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 2 && spellInSlot[2] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 3 && spellInSlot[3] != null)
            {
                currentSpell = spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 3 && spellInSlot[3] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }

            if (currentSpellIndex > spellInSlot.Length - 1)
            {
                currentSpellIndex = 0;
                currentSpell = spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(spellInSlot[currentSpellIndex]);
            }
        }

        public void ChangeConsumableItem()
        {
            currentItemIndex = currentItemIndex + 1;
            if (currentItemIndex == 0 && itemInSlot[0] != null)
            {
                currentConsumable = itemInSlot[currentItemIndex];
                LoadItemOnSlot(itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 0 && itemInSlot[0] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 1 && itemInSlot[1] != null)
            {
                currentConsumable = itemInSlot[currentItemIndex];
                LoadItemOnSlot(itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 1 && itemInSlot[1] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 2 && itemInSlot[2] != null)
            {
                currentConsumable = itemInSlot[currentItemIndex];
                LoadItemOnSlot(itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 2 && itemInSlot[2] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 3 && itemInSlot[3] != null)
            {
                currentConsumable = itemInSlot[currentItemIndex];
                LoadItemOnSlot(itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 3 && itemInSlot[3] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }

            if (currentItemIndex > itemInSlot.Length - 1)
            {
                currentItemIndex = 0;
                currentConsumable = itemInSlot[currentItemIndex];
                LoadItemOnSlot(itemInSlot[currentItemIndex]);
            }
        } 
    }

}
