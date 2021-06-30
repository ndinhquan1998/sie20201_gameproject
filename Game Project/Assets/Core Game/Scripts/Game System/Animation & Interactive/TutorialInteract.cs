using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DQ
{
    public class TutorialInteract : Interactable
    {
        public string text;
        public Texture texture;
        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            Read(playerManager);
        }

        private void Read(PlayerManager playerManager)
        {
            playerManager.itemInteractableGameObject.GetComponentInChildren<Text>().text = text;
            playerManager.itemInteractableGameObject.GetComponentInChildren<RawImage>().texture = texture;
            playerManager.itemInteractableGameObject.SetActive(true);
            Destroy(gameObject);

        }
    }

}