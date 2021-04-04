using UnityEngine;

namespace DASUnityFramework.Scripts.Layout3D
{
    [DisallowMultipleComponent]
    public abstract class LayoutElement3D : MonoBehaviour
    {
        public abstract float GetSize(Vector3 inAxis);
    }
}