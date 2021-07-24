using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ

{
    public class InputHandler : MonoBehaviour
    {
        //gamemenu
        public bool menu_Input;
        public bool any_Input;

        //left d-pad
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        //Right D-pad
        // Xbox Controller : Y X A B 
        //                   RT RB LT LB  
        //   PS Controller : Triangle Square Cross Circle 
        //                   R1 R2 L1 L2
        //   PC Controller : 
        public bool b_Input;
        public bool a_Input;
        public bool x_Input;
        public bool y_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool lt_Input;
        public bool lb_Input;
        public bool critical_Attack_Input;
        public bool jump_Input;
        public bool inventory_Input;

        //analog stick
        public bool lockOn_Input;
        public bool rightStick_Left_Input;
        public bool rightStick_Right_Input;


        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool d_Pad_Left;
        public bool d_Pad_Right;



        //public bool rollFlag;
        public bool isRolling;
        public bool sprintFlag;
        public bool twoHandFlag;
        public bool lockOnFlag;
        public bool comboFlag;
        public bool inventoryFlag;
        public float rollInputTimer;

        // transform doc lap de khong bi dinh transform tinh tu chan hay mat dat cua model 
        public Transform criticalAttackRayCastStartPoint;

        PlayerControls inputActions;
        PlayerAttacking playerAttacking;
        PlayerInventory playerInventory;
        PlayerManager playerManager;
        PlayerFXManager playerFXManager;
        PlayerStats playerStats;
        BlockingCollider blockingCollider;
        CameraHandler cameraHandler;
        UIManager uiManager;
        WeaponSlotManager weaponSlotManager;
        PlayerAnimatorManager playerAnimatorManager;
        

        Vector2 movementInput;
        Vector2 cameraInput;

        private void Start()
        {
            //Application.targetFrameRate = 100;
        }
        private void Awake()
        {
            playerAttacking = GetComponentInChildren<PlayerAttacking>();
            playerInventory = GetComponent<PlayerInventory>();
            playerManager = GetComponent<PlayerManager>();
            playerStats = GetComponent<PlayerStats>();
            uiManager = FindObjectOfType<UIManager>();
            cameraHandler = FindObjectOfType<CameraHandler>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            playerAnimatorManager = GetComponentInChildren<PlayerAnimatorManager>();
            playerFXManager = GetComponentInChildren<PlayerFXManager>();
            blockingCollider = GetComponentInChildren<BlockingCollider>();

            
        }


        public void OnEnable()
        {
            if ( inputActions == null) 
            {
                inputActions = new PlayerControls();

                inputActions.GameMenu.PauseGame.performed += i => menu_Input = true;
                inputActions.GameMenu.Anykey.performed += i => any_Input = true;

                //Movement Input
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

                //Quick Slot Inventory Input
                inputActions.PlayerQuickSlots.DPadRight.performed += inputActions => d_Pad_Right = true;
                inputActions.PlayerQuickSlots.DPadLeft.performed += inputActions => d_Pad_Left = true;
                inputActions.PlayerQuickSlots.DPadUp.performed += inputActions => d_Pad_Up = true;
                inputActions.PlayerQuickSlots.DPadDown.performed += inputActions => d_Pad_Down = true;

                //Actions Input
                inputActions.PlayerActions.RB.performed += i => rb_Input = true;
                inputActions.PlayerActions.RT.performed += i => rt_Input = true;
                inputActions.PlayerActions.LT.performed += i => lt_Input = true;
                inputActions.PlayerActions.LB.performed += i => lb_Input = true;
                inputActions.PlayerActions.LB.canceled += i => lb_Input = false;

                inputActions.PlayerActions.Inventory.performed += i => inventory_Input = true;
                inputActions.PlayerActions.A.performed += i => a_Input = true;
                inputActions.PlayerActions.X.performed += i => x_Input = true;
                inputActions.PlayerActions.Y.performed += i => y_Input = true;
                inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
                inputActions.PlayerActions.B.performed += i => b_Input = true;
                inputActions.PlayerActions.B.canceled += i => b_Input = false;

                //override action
                //RB
                inputActions.PlayerActions.CriticalAttack.performed += i => critical_Attack_Input = true;

                //Lock On Input
                inputActions.PlayerActions.LockOn.performed += i => lockOn_Input = true;
                inputActions.PlayerMovement.LockOnTargetLeft.performed += i => rightStick_Left_Input = true;
                inputActions.PlayerMovement.LockOnTargetRight.performed += i => rightStick_Right_Input = true;
                
            }
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }
        public void TickInput(float delta)
        {
            HandleMoveInput(delta);
            HandleRollInput(delta);
            HandleCombatInput(delta);
            HandleQuickSlotsInput();
            //HandleInteractingButtonInput();
            //HandlePauseInput();
            HandleInventoryInput();
            HandleTwoHandInput();
            HandleLockOnInput();
            HandleCriticalAttackInput();
            HandleUseConsumableInput();
        }   
        private void HandleMoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta)
        {
            //remove for improvement
            //b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;


            if (b_Input)
            {
                rollInputTimer += delta;

                if (playerStats.CurrentStamina <= 0)
                {
                    b_Input = false;
                    sprintFlag = false;
                }

                if(moveAmount > 0.5f && playerStats.CurrentStamina > 0)
                {
                    sprintFlag = true;
                }
            }
            else
            {
                sprintFlag = false;

                if (rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    
                    isRolling = true;
                }
                rollInputTimer = 0;
            }
        }

        private void HandleCombatInput(float delta)
        {
            if(rb_Input)
            {
                playerAttacking.HandleRBAction();              
            }            
            if(rt_Input)
            {
                playerAttacking.HandleRTAction();
            }
            if (lt_Input)
            {
                if (twoHandFlag)
                {
                    //if two handing handle weapon art
                }
                else
                {
                    playerAttacking.HandleLTAction();
                }
            }
            if (lb_Input)
            {
                playerAttacking.HandleLBAction();
            }
            else
            {
                playerManager.isBlocking = false;

                if (blockingCollider.blockingCollider.enabled)
                {
                    blockingCollider.DisableBlockingCollider();
                }
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
            else if (d_Pad_Up)
            {
                playerInventory.ChangeSpellItem();
            }
            else if (d_Pad_Down)
            {
                playerInventory.ChangeConsumableItem();
            }
        }

        private void HandleInventoryInput()
        {        
            if (inventory_Input)
            {
                inventoryFlag = !inventoryFlag;

                if (inventoryFlag)
                {
                    uiManager.OpenSelectWindows();
                    uiManager.UpdateInventoryUISlots();
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

        private void HandleCriticalAttackInput()
        {
            if(critical_Attack_Input)
            {
                critical_Attack_Input = false;
                playerAttacking.AttemptBackStabOrRiposte();
            }
        }
        public void HandleLockOnInput()
        {
            if(lockOn_Input && lockOnFlag == false)
            {
                lockOn_Input = false;
                cameraHandler.HandleLockOn();
                if(cameraHandler.nearestLockOnTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.nearestLockOnTarget;
                    lockOnFlag = true;
                }

            } else if( lockOn_Input && lockOnFlag)
            {
                lockOn_Input = false;
                lockOnFlag = false;

                //Clear lock on targets
                cameraHandler.CheckDeadTarget();
                cameraHandler.ClearLockOnTargets();
            }

            if(lockOnFlag && rightStick_Left_Input)
            {
                rightStick_Left_Input = false;
                cameraHandler.HandleLockOn();
                if(cameraHandler.leftLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.leftLockTarget;
                }
            }            
            
            if(lockOnFlag && rightStick_Right_Input)
            {
                rightStick_Right_Input = false;
                cameraHandler.HandleLockOn();
                if(cameraHandler.rightLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.rightLockTarget;
                }
            }
            cameraHandler.SetCameraHeight();
        }

        private void HandleUseConsumableInput()
        {
            if (x_Input)
            {
                x_Input = false;
                //use Item
                playerInventory.currentConsumable.AttemptToConsumeItem(playerAnimatorManager, weaponSlotManager, playerFXManager);
            }
        }

    }

}