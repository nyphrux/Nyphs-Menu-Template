/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using UnityEngine;

namespace NyphsMenuTemp.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.magenta, 0.5f),
            new GradientColorKey(Color.black, 1f)
        };

        public bool isRainbow = false;
        public bool copyRigColors = false;
    }
}
