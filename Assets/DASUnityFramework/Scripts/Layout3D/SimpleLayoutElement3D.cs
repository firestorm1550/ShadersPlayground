using UnityEngine;

namespace DASUnityFramework.Scripts.Layout3D
{
    public class SimpleLayoutElement3D : LayoutElement3D
    {
        public float width;
        public override float GetSize(Vector3 inAxis)
        {
            return width;
        }
    }
}