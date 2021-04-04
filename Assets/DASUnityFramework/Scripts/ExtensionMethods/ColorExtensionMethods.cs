using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class ColorExtensionMethods
    {
        public static Color WithAlpha(this Color c, float alpha)
        {
            return new Color(c.r,c.g,c.b,alpha);
        }
    }
}