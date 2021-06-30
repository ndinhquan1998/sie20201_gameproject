using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class OpenDoor : Interactable
    {
        Animator animator;
        public Collider collider;
        public Transform playerStandingPosition;

        UIBossHealthBar[] bossHealthBar;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            bossHealthBar = FindObjectsOfType<UIBossHealthBar>();
        }

        public override void Interact(PlayerManager playerManager)
        {
            //rotate player towards the chest
            //lock transform infront of the chest
            Vector3 rotationDirection = transform.position - playerManager.transform.position;
            rotationDirection.y = 0;
            rotationDirection.Normalize();

            Quaternion tr = Quaternion.LookRotation(rotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(playerManager.transform.rotation, tr, 300 * Time.deltaTime);
            playerManager.transform.rotation = targetRotation;
            //play the animation
            playerManager.OpenDoor(playerStandingPosition);
            animator.Play("Door Open");
            StartCoroutine(DisableCollider());

        }

        private IEnumerator DisableCollider()
        {
            yield return new WaitForSeconds(1f);

                if (collider.enabled)
                {
                    collider.enabled = false;

                    //audioSource.PlayOneShot(illusionarySound);
                }
            
        }

    }
}
