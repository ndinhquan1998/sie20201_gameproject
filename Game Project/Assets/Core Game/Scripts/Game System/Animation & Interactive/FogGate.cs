using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class FogGate : Interactable
    {
        private GameObject go;
        public static FogGate instance;

        private Material fogMaterial;
        public float alpha;
        public float fadeTimer = 2.5f;
        public bool isOpen;
        public BoxCollider wallCollider;

        public AudioSource audioSource;
        public AudioClip illusionarySound;


        private void Start()
        {
            go = this.gameObject;
            fogMaterial = go.GetComponent<Renderer>().material;
        }
        private void Awake()
        {
            instance = this;
        }


        public void FadeHiddenWall()
        {

            alpha = fogMaterial.GetColor("_BaseColor").a;
            alpha = alpha - Time.deltaTime / fadeTimer;
            Color fadedWallColor = new Color(1, 1, 1, alpha);


            fogMaterial.SetColor("_BaseColor", fadedWallColor);

            if (wallCollider.enabled)
            {
                wallCollider.enabled = false;
                
                //audioSource.PlayOneShot(illusionarySound);
            }

        }

        public override void Interact(PlayerManager playerManager)
        {
            FadeHiddenWall();
            playerManager.TraverseFog();
        }
    }

}