using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class CheckPoint : Interactable
    {
        Animator animator;

         

        public Transform playerStandingPosition;
        public GameObject particle;
        GameManager gameManager;
        public float delay = 1;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameManager = FindObjectOfType<GameManager>();

            
        }

        public override void Interact(PlayerManager playerManager)
        {
            Vector3 rotationDirection = transform.position - playerManager.transform.position;
            rotationDirection.y = 0;
            rotationDirection.Normalize();
            Quaternion tr = Quaternion.LookRotation(rotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 300 * Time.deltaTime);
            playerManager.transform.rotation = targetRotation;

            //play the animation
            playerManager.ActivateCheckPoint(playerStandingPosition);

            DisableInactiveCP();
            Invoke("EnableParticle", delay);
            //ActivateCheckPoint();

            RGBColor col = new RGBColor(200,217,40);
            Color c = col.getRGBColor;
            gameManager.UpdateStatus(c, "Bonfire Lit");
            gameManager.Saving();
        }

        private void DisableInactiveCP()
        {
            CheckPoint[] checkpoints = FindObjectsOfType<CheckPoint>();
            for (int i = 0; i< checkpoints.Length; i++)
            {
                checkpoints[i].particle.SetActive(true);
                checkpoints[i].particle.SetActive(false);
            }
        }

        public void EnableParticle()
        {
            particle.SetActive(true);
        }

    }
}


