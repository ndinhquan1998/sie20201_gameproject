using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DQ
{
    public class RGBColor : MonoBehaviour
    {
        public Color getRGBColor { get; set; }

        public RGBColor(float r, float g, float b)
        {
            Color c;

            if (r > 255)
                r = 255f;

            if (g > 255)
                g = 255f;

            if (b > 255)
                b = 255f;

            r /= 255f;
            g /= 255f;
            b /= 255f;

            c = new Color(r, g, b);

            this.getRGBColor = c;
        }
    }   
}
