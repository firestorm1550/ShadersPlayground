using System;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class QuaternionExtensionMethods
    {
        public static bool IsValid(this Quaternion q, float tolerance = .0001f)
        {
            return Math.Abs(1 - (q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z)) < tolerance;
        }
    }
}