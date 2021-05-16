using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerEquipmentManager : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerInventory playerInventory;

        [Header("Equipment Model Changers")]
        HelmetModelChanger helmetModelChanger;
        ChestArmorModelChanger chestArmorModelChanger;
        //Glove
        //Leg
        [Header("Default Player Model")]
        public GameObject bareHeadModel;
        public GameObject hairModel;
        public string bareChestModel;
        //hand
        //leg

        public BlockingCollider blockingCollider;

        private void Awake()
        {
            inputHandler = GetComponentInParent<InputHandler>();
            playerInventory = GetComponentInParent<PlayerInventory>();
            helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
            chestArmorModelChanger = GetComponentInChildren<ChestArmorModelChanger>();
        }

        private void Start()
        {
            EquipAllGearModelsOnStart();
        }

        private void EquipAllGearModelsOnStart()
        {
            helmetModelChanger.UnequipHelmet();
            if(playerInventory.currentHelmetEquipment != null)
            {
                bareHeadModel.SetActive(false);
                hairModel.SetActive(false);
                helmetModelChanger.EquipHelmetModelByName(playerInventory.currentHelmetEquipment.helmetModelName);
            }
            else
            {
                //display no equipment on player
                bareHeadModel.SetActive(true);
                hairModel.SetActive(true);
            }

            chestArmorModelChanger.UnequipChestArmor();
            if(playerInventory.currentChestArmorEquipment != null)
            {
                chestArmorModelChanger.EquipChestArmorModelByName(playerInventory.currentChestArmorEquipment.armorModelName);
            }
            else
            {
                //display no equipment on player
                chestArmorModelChanger.EquipChestArmorModelByName(bareChestModel);
            }
        }

        public void OpenBlockingCollider()
        {
            if (inputHandler.twoHandFlag)
            {
                blockingCollider.SetColliderDamageAbsorption(playerInventory.rightWeapon);
            }
            else
            {
                blockingCollider.SetColliderDamageAbsorption(playerInventory.leftWeapon);
            }

            blockingCollider.EnableBlockingCollider();
        }

        public void CloseBlockingCollider()
        {
            blockingCollider.DisableBlockingCollider();
        }


    }
}


