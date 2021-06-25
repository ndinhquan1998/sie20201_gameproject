using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;
        QuickSlotsUI quickSlotsUI;
        public PlayerProfile playerProfile;

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

        /*public Weapon[] weaponsInRightHandSlot = new Weapon[1];
        public Weapon[] weaponsInLeftHandSlot = new Weapon[1];
        public Helmet[]  helmetInSlot = new Helmet[0];
        public ChestArmor[] chestArmorInSlot = new ChestArmor[0];
        public BottomArmor[] bottomArmorInSlot = new BottomArmor[0];
        public SpellItems[] spellInSlot = new SpellItems[3];
        public ConsumableItem[] itemInSlot = new ConsumableItem[3];*/

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
            rightWeapon = playerProfile.weaponsInRightHandSlot[0];
            leftWeapon = playerProfile.weaponsInLeftHandSlot[0];
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);

            //gear
            currentHelmetEquipment = playerProfile.helmetInSlot[0];

            currentChestArmorEquipment = playerProfile.chestArmorInSlot[0];

            currentBottomArmorEquipment = playerProfile.bottomArmorInSlot[0];

            //item
            currentConsumable = playerProfile.itemInSlot[0];
            LoadItemOnSlot(currentConsumable);

            //spell
            currentSpell = playerProfile.spellInSlot[0];
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

            if(currentRightWeaponIndex == 0 && playerProfile.weaponsInRightHandSlot[0] != null)
            {
                rightWeapon = playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex], false);
            } 
            else if (currentRightWeaponIndex == 0 && playerProfile.weaponsInRightHandSlot[0] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }
            else if (currentRightWeaponIndex == 1 && playerProfile.weaponsInRightHandSlot[1] != null)
            {
                rightWeapon = playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex], false);
            }
            else if (currentRightWeaponIndex == 1 && playerProfile.weaponsInRightHandSlot[1] == null)
            {
                currentRightWeaponIndex = currentRightWeaponIndex + 1;
            }

            if(currentRightWeaponIndex > playerProfile.weaponsInRightHandSlot.Length - 1)
            {
                currentRightWeaponIndex = 0;
                rightWeapon = playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInRightHandSlot[currentRightWeaponIndex], false);
                //rightWeapon = unarmedWeapon;
                //weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, false);
            }

        }        
        public void ChangeLeftWeapon()
        {
            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            if(currentLeftWeaponIndex ==0 && playerProfile.weaponsInLeftHandSlot[0] != null)
            {
                leftWeapon = playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
            } 
            else if (currentLeftWeaponIndex == 0 && playerProfile.weaponsInLeftHandSlot[0] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }
            else if (currentLeftWeaponIndex == 1 && playerProfile.weaponsInLeftHandSlot[1] != null)
            {
                leftWeapon = playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
            }
            else if(currentLeftWeaponIndex == 1 && playerProfile.weaponsInLeftHandSlot[1] == null)
            {
                currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            }

            if(currentLeftWeaponIndex > playerProfile.weaponsInLeftHandSlot.Length - 1)
            {
                currentLeftWeaponIndex = 0;
                leftWeapon = playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(playerProfile.weaponsInLeftHandSlot[currentLeftWeaponIndex], true);
                //leftWeapon = unarmedWeapon;
                //weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, true);
            }
        }

        public void ChangeSpellItem()
        {
            currentSpellIndex = currentSpellIndex + 1;
            if (currentSpellIndex == 0 && playerProfile.spellInSlot[0] != null)
            {
                currentSpell = playerProfile.spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(playerProfile.spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 0 && playerProfile.spellInSlot[0] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 1 && playerProfile.spellInSlot[1] != null)
            {
                currentSpell = playerProfile.spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(playerProfile.spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 1 && playerProfile.spellInSlot[1] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 2 && playerProfile.spellInSlot[2] != null)
            {
                currentSpell = playerProfile.spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(playerProfile.spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 2 && playerProfile.spellInSlot[2] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }
            else if (currentSpellIndex == 3 && playerProfile.spellInSlot[3] != null)
            {
                currentSpell = playerProfile.spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(playerProfile.spellInSlot[currentSpellIndex]);
            }
            else if (currentSpellIndex == 3 && playerProfile.spellInSlot[3] == null)
            {
                currentSpellIndex = currentSpellIndex + 1;
            }

            if (currentSpellIndex > playerProfile.spellInSlot.Length - 1)
            {
                currentSpellIndex = 0;
                currentSpell = playerProfile.spellInSlot[currentSpellIndex];
                LoadSpellOnSlot(playerProfile.spellInSlot[currentSpellIndex]);
            }
        }

        public void ChangeConsumableItem()
        {
            currentItemIndex = currentItemIndex + 1;
            if (currentItemIndex == 0 && playerProfile.itemInSlot[0] != null)
            {
                currentConsumable = playerProfile.itemInSlot[currentItemIndex];
                LoadItemOnSlot(playerProfile.itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 0 && playerProfile.itemInSlot[0] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 1 && playerProfile.itemInSlot[1] != null)
            {
                currentConsumable = playerProfile.itemInSlot[currentItemIndex];
                LoadItemOnSlot(playerProfile.itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 1 && playerProfile.itemInSlot[1] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 2 && playerProfile.itemInSlot[2] != null)
            {
                currentConsumable = playerProfile.itemInSlot[currentItemIndex];
                LoadItemOnSlot(playerProfile.itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 2 && playerProfile.itemInSlot[2] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }
            else if (currentItemIndex == 3 && playerProfile.itemInSlot[3] != null)
            {
                currentConsumable = playerProfile.itemInSlot[currentItemIndex];
                LoadItemOnSlot(playerProfile.itemInSlot[currentItemIndex]);
            }
            else if (currentItemIndex == 3 && playerProfile.itemInSlot[3] == null)
            {
                currentItemIndex = currentItemIndex + 1;
            }

            if (currentItemIndex > playerProfile.itemInSlot.Length - 1)
            {
                currentItemIndex = 0;
                currentConsumable = playerProfile.itemInSlot[currentItemIndex];
                LoadItemOnSlot(playerProfile.itemInSlot[currentItemIndex]);
            }
        } 
    }

}
