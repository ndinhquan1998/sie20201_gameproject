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
        //Upperbody
        ChestArmorModelChanger chestArmorModelChanger;
        UpperLeftArmModelChanger upperLeftArmModelChanger;
        UpperRightArmModelChanger upperRightArmModelChanger;

        LowerLeftArmModelChanger lowerLeftArmModelChanger;
        LowerRightArmModelChanger lowerRightArmModelChanger;

        LeftShoulderModelChanger leftShoulderModelChanger;
        RightShoulderModelChanger rightShoulderModelChanger;
        

        //Glove
        //Leg
        BottomArmorModelChanger bottomArmorModelChanger;
        RightLegArmorModelChanger rightLegArmorModelChanger;
        RightKneeModelChanger rightKneeModelChanger;
        LeftLegArmorModelChanger leftLegArmorModelChanger;
        LeftKneeModelChanger leftKneeModelChanger;


        [Header("Default Player Model")]
        public GameObject bareHeadModel;
        public GameObject hairModel;

        public string bareChestModel;
        public string bareUpperLeftArmModel;
        public string bareUpperRightArmModel;
        public string bareLowerLeftArmModel;
        public string bareLowerRightArmModel;


        public string bareBottomModel;
        public string bareRightLegModel;
        public string bareLeftLegModel;
         

        public BlockingCollider blockingCollider;

        private void Awake()
        {
            inputHandler = GetComponentInParent<InputHandler>();
            playerInventory = GetComponentInParent<PlayerInventory>();

            //model loader
            helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
            chestArmorModelChanger = GetComponentInChildren<ChestArmorModelChanger>();
            upperLeftArmModelChanger = GetComponentInChildren<UpperLeftArmModelChanger>();
            upperRightArmModelChanger = GetComponentInChildren<UpperRightArmModelChanger>();
            lowerLeftArmModelChanger = GetComponentInChildren<LowerLeftArmModelChanger>();
            lowerRightArmModelChanger = GetComponentInChildren<LowerRightArmModelChanger>();
            bottomArmorModelChanger = GetComponentInChildren<BottomArmorModelChanger>();
            leftLegArmorModelChanger = GetComponentInChildren<LeftLegArmorModelChanger>();
            rightLegArmorModelChanger = GetComponentInChildren<RightLegArmorModelChanger>();
            //accessory
            rightKneeModelChanger = GetComponentInChildren<RightKneeModelChanger>();
            leftKneeModelChanger = GetComponentInChildren<LeftKneeModelChanger>();

            leftShoulderModelChanger = GetComponentInChildren<LeftShoulderModelChanger>();
            rightShoulderModelChanger = GetComponentInChildren<RightShoulderModelChanger>();


        }

        private void Start()
        {
            EquipAllGearModelsOnStart();
        }

        private void EquipAllGearModelsOnStart()
        {
            #region Headwear
            helmetModelChanger.UnequipHelmet();
            if (playerInventory.currentHelmetEquipment != null)
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
            #endregion

            #region Chest Armor
            chestArmorModelChanger.UnequipChestArmor();
            upperLeftArmModelChanger.UnEquipAllModels();
            upperRightArmModelChanger.UnEquipAllModels();
            lowerLeftArmModelChanger.UnEquipAllModels();
            lowerRightArmModelChanger.UnEquipAllModels();
            leftShoulderModelChanger.UnEquipAllModels();
            rightShoulderModelChanger.UnEquipAllModels();

            if (playerInventory.currentChestArmorEquipment != null)
            {
                chestArmorModelChanger.EquipChestArmorModelByName(playerInventory.currentChestArmorEquipment.armorModelName);

                upperLeftArmModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.upperLeftArmModelName);
                upperRightArmModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.upperRightArmModelName);

                lowerLeftArmModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.lowerLeftArmModelName);
                lowerRightArmModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.lowerRightArmModelName);

                leftShoulderModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.leftShoulderModelName);
                rightShoulderModelChanger.EquipModelByName(playerInventory.currentChestArmorEquipment.rightShoulderModelName);

            }
            else
            {
                //display no equipment on player
                chestArmorModelChanger.EquipChestArmorModelByName(bareChestModel);
                upperLeftArmModelChanger.EquipModelByName(bareUpperLeftArmModel);
                upperRightArmModelChanger.EquipModelByName(bareUpperRightArmModel);
                lowerLeftArmModelChanger.EquipModelByName(bareLowerLeftArmModel);
                lowerRightArmModelChanger.EquipModelByName(bareLowerRightArmModel);
            }
            #endregion

            #region Bottom Armor
            bottomArmorModelChanger.UnequipArmor();
            leftLegArmorModelChanger.UnEquipAllLegModels();
            rightLegArmorModelChanger.UnEquipAllLegModels();
            leftKneeModelChanger.UnEquipAllModels();
            rightKneeModelChanger.UnEquipAllModels();

            if (playerInventory.currentBottomArmorEquipment != null)
            {
                bottomArmorModelChanger.EquipArmorModelByName(playerInventory.currentBottomArmorEquipment.hipArmorModelName);
                leftLegArmorModelChanger.EquipLegModelByName(playerInventory.currentBottomArmorEquipment.leftLegArmorModelName );
                rightLegArmorModelChanger.EquipLegModelByName(playerInventory.currentBottomArmorEquipment.rightLegArmorModelName);

                leftKneeModelChanger.EquipModelByName(playerInventory.currentBottomArmorEquipment.leftKneeModelName);
                rightKneeModelChanger.EquipModelByName(playerInventory.currentBottomArmorEquipment.rightKneeModelName);

            }
            else
            {
                //display no equipment on player
                bottomArmorModelChanger.EquipArmorModelByName(bareBottomModel);
                leftLegArmorModelChanger.EquipLegModelByName(bareLeftLegModel);
                rightLegArmorModelChanger.EquipLegModelByName(bareRightLegModel);
            }
            #endregion


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


