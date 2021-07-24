using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ {
    public class LootPickUp : Interactable
    {
        GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            PickUpItem(playerManager);
        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerStats playerStats;
            PlayerLocomotion playerLocomotion;
            PlayerAnimatorManager animatorHandler;

            playerStats = playerManager.GetComponent<PlayerStats>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<PlayerAnimatorManager>();

            playerLocomotion.rigidbody.velocity = Vector3.zero;
            animatorHandler.PlayTargetAnimation("Pick Up Item", true);
            //playerInventory.weaponsInventory.Add(weapon);
            playerStats.AddCoins(gameManager.lostCoin);
            playerStats.AddExp(gameManager.lostExp);

            Destroy(gameObject);

        }
    }
}
