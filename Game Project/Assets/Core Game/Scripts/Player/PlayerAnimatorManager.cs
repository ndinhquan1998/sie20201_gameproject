using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class PlayerAnimatorManager : AnimatorManager
    {

        InputHandler inputHandler;
        PlayerStats playerStats;
        PlayerLocomotion playerLocomotion;
        PlayerManager playerManager;
        int vertical;
        int horizontal;


        public void Initialize()
        {
            anim = GetComponent<Animator>();
            playerManager = GetComponentInParent<PlayerManager>();
            playerStats = GetComponentInParent<PlayerStats>();
            inputHandler = GetComponentInParent<InputHandler>();
            playerLocomotion = GetComponentInParent<PlayerLocomotion>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");

        }
        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)
        {
            #region Vertical 
            float tweakedVerticalValue = 0;

            if(verticalMovement > 0 && verticalMovement < 0.55f)
            {
                tweakedVerticalValue = 0.5f;
            }
            else if (verticalMovement >0.55f)
            {
                tweakedVerticalValue = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f)
            {
                tweakedVerticalValue = -0.5f;
            }
            else if (verticalMovement < -0.55f)
            {
                tweakedVerticalValue = -1;
            }
            else
            {
                tweakedVerticalValue = 0;
            }
            #endregion

            #region Horizontal
            float tweakedHorizontallValue = 0;
            if (horizontalMovement > 0 && horizontalMovement < 0.55f)
            {
                tweakedHorizontallValue = 0.5f;
            }
            else if (horizontalMovement > 0.55f)
            {
                tweakedHorizontallValue = 1;
            }
            else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
            {
                tweakedHorizontallValue = -0.5f;
            }
            else if (horizontalMovement < -0.55f)
            {
                tweakedHorizontallValue = -1;
            }
            else
            {
                tweakedHorizontallValue = 0;
            }
            #endregion

            if (isSprinting && tweakedVerticalValue != 0)
            {
                tweakedVerticalValue = 2;
                tweakedHorizontallValue = horizontalMovement;
            }

            anim.SetFloat(vertical, tweakedVerticalValue, 0.1f, Time.deltaTime);
            anim.SetFloat(horizontal, tweakedHorizontallValue, 0.1f, Time.deltaTime);
        }



        public void CanRotate()
        {
            anim.SetBool("canRotate", true);
        }
        public void StopRotation()
        {
            anim.SetBool("canRotate", false);
        }

        public void EnableCombo()
        {
            anim.SetBool("canDoCombo", true);
        }
        public void DisableCombo()
        {
            anim.SetBool("canDoCombo", false);
        }

        public void EnableIsInvulnerable()
        {
            anim.SetBool("isInvulnerable", true);
        }        
        public void DisableIsInvulnerable()
        {
            anim.SetBool("isInvulnerable", false);
        }

        public void EnableIsParrying()
        {
            playerManager.isParrying = true;
        }

        public void DisableIsParrying()
        {
            playerManager.isParrying = false;
        }

        public void EnableCanBeRiposted()
        {
            playerManager.canBeRiposted = true;
        }

        public void DisableCanBeRiposted()
        {
            playerManager.canBeRiposted = false;
        }

        public override void TakeCriticalDamageAnimationEvent()
        {
            playerStats.TakeDamageNoAnimation(playerManager.pendingCriticalDamage);
            playerManager.pendingCriticalDamage = 0;
        }

        private void OnAnimatorMove()
        {
            if (playerManager.isInteracting == false)
                return;
            float delta = Time.deltaTime;
            playerLocomotion.rigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            playerLocomotion.rigidbody.velocity = velocity;

        }
    }
}