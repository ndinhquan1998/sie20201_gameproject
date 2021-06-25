using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class PlayerEquipmentManager : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerInventory playerInventory;
        PlayerStats playerStats;

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
            playerStats = GetComponentInParent<PlayerStats>();
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
            if (playerInventory.playerProfile.helmetInSlot[0] != null)
            {
                bareHeadModel.SetActive(false);
                hairModel.SetActive(false);
                helmetModelChanger.EquipHelmetModelByName(playerInventory.playerProfile.helmetInSlot[0].helmetModelName);
                //Getting Stats
                playerStats.physicalDmgAbsorbtion_Head = playerInventory.playerProfile.helmetInSlot[0].physicalDefense;
                Debug.Log("% Head Def" + playerStats.physicalDmgAbsorbtion_Head);
            }
            else
            {
                //display no equipment on player
                bareHeadModel.SetActive(true);
                hairModel.SetActive(true);
                //Getting Stats
                playerStats.physicalDmgAbsorbtion_Head = 0;
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

            if (playerInventory.playerProfile.chestArmorInSlot[0] != null)
            {
                chestArmorModelChanger.EquipChestArmorModelByName(playerInventory.playerProfile.chestArmorInSlot[0].armorModelName);

                upperLeftArmModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].upperLeftArmModelName);
                upperRightArmModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].upperRightArmModelName);

                lowerLeftArmModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].lowerLeftArmModelName);
                lowerRightArmModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].lowerRightArmModelName);

                leftShoulderModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].leftShoulderModelName);
                rightShoulderModelChanger.EquipModelByName(playerInventory.playerProfile.chestArmorInSlot[0].rightShoulderModelName);
                //Getting Stats
                playerStats.physicalDmgAbsorbtion_BodyArmor = playerInventory.playerProfile.chestArmorInSlot[0].physicalDefense;
                Debug.Log("% Body Def" + playerStats.physicalDmgAbsorbtion_BodyArmor);
            }
            else
            {
                //display no equipment on player
                chestArmorModelChanger.EquipChestArmorModelByName(bareChestModel);
                upperLeftArmModelChanger.EquipModelByName(bareUpperLeftArmModel);
                upperRightArmModelChanger.EquipModelByName(bareUpperRightArmModel);
                lowerLeftArmModelChanger.EquipModelByName(bareLowerLeftArmModel);
                lowerRightArmModelChanger.EquipModelByName(bareLowerRightArmModel);
                //Getting Stats
                playerStats.physicalDmgAbsorbtion_BodyArmor = 0;
            }
            #endregion

            #region Bottom Armor
            bottomArmorModelChanger.UnequipArmor();
            leftLegArmorModelChanger.UnEquipAllLegModels();
            rightLegArmorModelChanger.UnEquipAllLegModels();
            leftKneeModelChanger.UnEquipAllModels();
            rightKneeModelChanger.UnEquipAllModels();

            if (playerInventory.playerProfile.bottomArmorInSlot[0] != null)
            {
                bottomArmorModelChanger.EquipArmorModelByName(playerInventory.playerProfile.bottomArmorInSlot[0].hipArmorModelName);
                leftLegArmorModelChanger.EquipLegModelByName(playerInventory.playerProfile.bottomArmorInSlot[0].leftLegArmorModelName );
                rightLegArmorModelChanger.EquipLegModelByName(playerInventory.playerProfile.bottomArmorInSlot[0].rightLegArmorModelName);

                leftKneeModelChanger.EquipModelByName(playerInventory.playerProfile.bottomArmorInSlot[0].leftKneeModelName);
                rightKneeModelChanger.EquipModelByName(playerInventory.playerProfile.bottomArmorInSlot[0].rightKneeModelName);
                //Getting Stats from Armor
                playerStats.physicalDmgAbsorbtion_BottomArmor = playerInventory.playerProfile.bottomArmorInSlot[0].physicalDefense;
                Debug.Log("% Bottom Def" + playerStats.physicalDmgAbsorbtion_BottomArmor);
            }
            else
            {
                //display no equipment on player
                bottomArmorModelChanger.EquipArmorModelByName(bareBottomModel);
                leftLegArmorModelChanger.EquipLegModelByName(bareLeftLegModel);
                rightLegArmorModelChanger.EquipLegModelByName(bareRightLegModel);
                //Getting Stats when no Armor
                playerStats.physicalDmgAbsorbtion_BottomArmor = 0;
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


