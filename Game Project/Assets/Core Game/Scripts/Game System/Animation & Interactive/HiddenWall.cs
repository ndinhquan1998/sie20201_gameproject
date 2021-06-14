using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class HiddenWall : MonoBehaviour
    {
        private GameObject go;

        public bool wallHasBeenHit;
        //public Material hiddenWallMaterial;
        private Material hiddenWallMaterial;
        public float alpha;
        public float fadeTimer = 2.5f;

        public BoxCollider wallCollider;

        public AudioSource audioSource;
        public AudioClip illusionarySound;

  
        private void Start()
        {
            go = this.gameObject;
            hiddenWallMaterial = go.GetComponent<Renderer>().material;
        }
        private void Update()
        {
            if (wallHasBeenHit)
            {
                FadeHiddenWall();
            }
        }

        /*
        Universal Render Pipeline  won't be able to access and change a material's alpha with material.color.a.
        instead to get it with material.GetColor("_BaseColor").a
        and set it with material.SetColor("_BaseColor", newColor).*/
        public void FadeHiddenWall()
        {

            alpha = hiddenWallMaterial.GetColor("_BaseColor").a;
            alpha = alpha - Time.deltaTime / fadeTimer;
            Color fadedWallColor = new Color(1, 1, 1, alpha);


            hiddenWallMaterial.SetColor("_BaseColor", fadedWallColor);

            if (wallCollider.enabled)
            {
                wallCollider.enabled = false;
                //audioSource.PlayOneShot(illusionarySound);
            }
            if( alpha <= 0)
            {
                Destroy(this);
            }
        }
    }
}

