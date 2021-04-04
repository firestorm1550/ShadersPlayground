using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static partial class VectorExtensionMethods
    {
        public static Vector3 XOO(this Vector3 v)
        {
            return new Vector3(v.x, 0, 0);
        }

        public static Vector3 OYO(this Vector3 v)
        {
            return new Vector3(0, v.y, 0);
        }

        public static Vector3 OOZ(this Vector3 v)
        {
            return new Vector3(0, 0, v.z);
        }

        //=============================================================================================================
        public static Vector3 XYO(this Vector3 v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        public static Vector3 OYZ(this Vector3 v)
        {
            return new Vector3(0, v.y, v.z);
        }

        public static Vector3 XOZ(this Vector3 v)
        {
            return new Vector3(v.x, 0, v.z);
        }
    }
}