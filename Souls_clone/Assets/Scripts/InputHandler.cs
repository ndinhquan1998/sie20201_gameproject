using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ

{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool f_Input;
        public bool y_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool jump_Input;
        public bool inventory_Input;


        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool d_Pad_Left;
        public bool d_Pad_Right;



        //public bool rollFlag;
        public bool isRolling;
        public bool sprintFlag;
        public bool twoHandFlag;
        public bool comboFlag;
        public bool inventoryFlag;
        public float rollInputTimer;
        

        PlayerControls inputActions;
        PlayerAttacking playerAttacking;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        UIManager uiManager;
        WeaponSlotManager weaponSlotManager;

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            playerAttacking = GetComponent<PlayerAttacking>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
            uiManager = FindObjectOfType<UIManager>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }
        public void OnEnable()
        {
            if ( inputActions == null) 
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
                inputActions.PlayerQuickSlots.DPadRight.performed += inputActions => d_Pad_Right = true;
                inputActions.PlayerQuickSlots.DPadLeft.performed += inputActions => d_Pad_Left = true;
                inputActions.PlayerQuickSlots.DPadUp.performed += inputActions => d_Pad_Up = true;
                inputActions.PlayerQuickSlots.DPadDown.performed += inputActions => d_Pad_Down = true;
                inputActions.PlayerActions.RB.performed += i => rb_Input = true;
                inputActions.PlayerActions.RT.performed += i => rt_Input = true;
                inputActions.PlayerActions.Inventory.performed += i => inventory_Input = true;
                inputActions.PlayerActions.F.performed += i => f_Input = true;
                inputActions.PlayerActions.Y.performed += i => y_Input = true;
                inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
                
            }
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }
        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleRollInput(delta);
            HandleAttackInput(delta);
            HandleQuickSlotsInput();
            //HandleInteractingButtonInput();
            //HandleJumpInput();
            HandleInventoryInput();
            HandleTwoHandInput();
        }   
        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta)
        {
            b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            sprintFlag = b_Input;
            if (b_Input)
            {
                rollInputTimer += delta;
                
            }
            else
            {
                if(rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    sprintFlag = false;
                    isRolling = true;
                }
                rollInputTimer = 0;
            }
        }

        private void HandleAttackInput(float delta)
        {
            if(rb_Input)
            {

                if (playerManager.canDoCombo)
                {
                    comboFlag = true;
                    playerAttacking.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    if (playerManager.isInteracting)
                        return;
                    if (playerManager.canDoCombo)
                        return;
                    playerAttacking.HandleLightAttack(playerInventory.rightWeapon);
                }
               
            }            
            if(rt_Input)
            {
                playerAttacking.HandleHeavyAttack(playerInventory.rightWeapon);
            }
        }

        private void HandleQuickSlotsInput()
        {
            if (d_Pad_Right)
            {
                playerInventory.ChangeRightWeapon();
            }
            else if (d_Pad_Left)
            {
                playerInventory.ChangeLeftWeapon();
            }
        }

        /*private void HandleInteractingButtonInput()
        {
            
        }

        private void HandleJumpInput()
        {
            
        }        */
        private void HandleInventoryInput()
        {
            

            if (inventory_Input)
            {
                inventoryFlag = !inventoryFlag;

                if (inventoryFlag)
                {
                    uiManager.OpenSelectWindows();
                    uiManager.UpdateUI();
                    uiManager.hudWindow.SetActive(false);
                }
                else
                {
                    uiManager.CloseSelectWindows();
                    uiManager.CloseAllInventoryWindow();
                    uiManager.hudWindow.SetActive(true);
                }
            }
        }
        private void HandleTwoHandInput()
        {
            if (y_Input)
            {
                y_Input = false;
                twoHandFlag = !twoHandFlag;

                if (twoHandFlag)
                {
                    //Enable
                    weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
                }
                else
                {
                    //disable
                    weaponSlotManager.LoadWeaponOnSlot(playerInventory.rightWeapon, false);
                    weaponSlotManager.LoadWeaponOnSlot(playerInventory.leftWeapon, true);
                }
            }
        }
    }

}