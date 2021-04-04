using UnityEngine.UI;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class GraphicsExtensionMethods
    {
        public static void SetAlpha(this Graphic g, float alpha)
        {
            g.color = g.color.WithAlpha(alpha);
        }
    }
}