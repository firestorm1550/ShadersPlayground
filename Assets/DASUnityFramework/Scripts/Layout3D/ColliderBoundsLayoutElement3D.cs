using UnityEngine;

namespace DASUnityFramework.Scripts.Layout3D
{
    public class ColliderBoundsLayoutElement3D : LayoutElement3D
    {
        public Collider collider;
        public override float GetSize(Vector3 inAxis)
        {
            return collider.bounds.size.magnitude;
        }
    }
}