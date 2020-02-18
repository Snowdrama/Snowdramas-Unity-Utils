using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SnowdramaUtils
{
    public static class ColorUtils
    {
        public static bool ColorEquals(Color a, Color b, float tolerance = 0.04f)
        {
            if (a.r > b.r + tolerance) return false;
            if (a.g > b.g + tolerance) return false;
            if (a.b > b.b + tolerance) return false;
            if (a.r < b.r - tolerance) return false;
            if (a.g < b.g - tolerance) return false;
            if (a.b < b.b - tolerance) return false;

            return true;
        }

        public static float Similarity(Color a, Color b){
            return Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
        }
    }
}
