using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class OpenBossGate : Interactable
    {
        Animator animator;
        public MeshCollider meshCollider;
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
            playerManager.OpenGate(playerStandingPosition);
            animator.Play("Door Open");
            StartCoroutine(DisableCollider());


            StartCoroutine(DelayFunction());
        }

        private IEnumerator DisableCollider()
        {
            yield return new WaitForSeconds(1f);
            if (meshCollider.enabled)
            {
                meshCollider.enabled = false;

                //audioSource.PlayOneShot(illusionarySound);
            }
        }

        private IEnumerator DelayFunction()
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i <= bossHealthBar.Length; i++)
            {
                bossHealthBar[i].SetUIHealthBarToActive();
            }
        }
    }
}
