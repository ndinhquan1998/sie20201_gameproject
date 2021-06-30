using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class InteractWithAnim : Interactable
    {
        public string anim;
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            PlayInteract(playerManager);
        }

        private void PlayInteract(PlayerManager playerManager)
        {
            PlayerLocomotion playerLocomotion;
            PlayerAnimatorManager animatorHandler;

            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<PlayerAnimatorManager>();

            playerLocomotion.rigidbody.velocity = Vector3.zero;
            animatorHandler.PlayTargetAnimation(anim, true);

        }
    }

}