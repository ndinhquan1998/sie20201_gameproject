using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
    public class MasterLightControl : MonoBehaviour
    {
        public Light masterLight;
        public float maxDistance = 10;
        public float maxIntensity = 2;

        private void Update()
        {

            Transform p = transform;
            float distance = Vector3.Distance(p.position, masterLight.transform.position);

            float t = maxDistance / distance;
            t = Mathf.Clamp01(t);

            masterLight.intensity = Mathf.Lerp(maxIntensity, 0, t);
        }
    }
}
