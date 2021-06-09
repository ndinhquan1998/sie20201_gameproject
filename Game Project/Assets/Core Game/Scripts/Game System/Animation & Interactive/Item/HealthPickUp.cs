using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class HealthPickUp : Interactable
    {
                public CharacterStats characterStats;
        public PlayerStats playerStats;
 
        private void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }
 
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);
 
            PickUpItem(playerManager);
        }
 
        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerLocomotion playerLocomotion;
            PlayerAnimatorManager animatorHandler;
 
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<PlayerAnimatorManager>();
 
            playerLocomotion.rigidbody.velocity = Vector3.zero; //Stops the player from moving whilst picking up item
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //Plays the animation of looting the item
            Destroy(gameObject);
 
 
            if (playerStats.CurrentHealth < playerStats.MaxHealth)
            {
                playerStats.AddHealth();
            }
 
 
        }
    }
}
