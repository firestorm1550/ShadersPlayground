using System;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEngine;

namespace DASUnityFramework.Scripts
{
    [Serializable]
    public struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public static TransformData Default => new TransformData
        {
            scale = Vector3.one
        };
    
    
        public TransformData(Transform t, bool world = false)
        {
            if (world)
            {
                position = t.position;
                rotation = t.rotation;
                scale = t.lossyScale;
            }
            else
            {
                position = t.localPosition;
                rotation = t.localRotation;
                scale = t.localScale;
            }
        }

        public TransformData(Vector3 pos, Quaternion rot, Vector3 scale)
        {
            position = pos;
            rotation = rot;
            this.scale = scale;
        }


        public TransformData Combine(TransformData t)
        {
            return new TransformData()
            {
                position = position + t.position,
                rotation = rotation * t.rotation,
                scale = scale.Multiply(t.scale)
            };
        }
    }
}
