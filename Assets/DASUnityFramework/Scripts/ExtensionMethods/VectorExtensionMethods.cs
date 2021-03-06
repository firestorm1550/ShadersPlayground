using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static partial class VectorExtensionMethods 
    {
        //=============== Vector3 Extensions ==========================================

        public static Vector3 Multiply(this Vector3 v1, Vector3Int v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        public static Vector3 Multiply(this Vector3Int v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        public static Vector3Int Multiply(this Vector3Int v1, Vector3Int v2)
        {
            Vector3Int retval = new Vector3Int(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }
        //Multiplies x by x, y by y, and z by z, returning the resultant value
        public static Vector3 Multiply(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            return retval;
        }

        public static Vector3 Multiply(this Vector3 v1, float x, float y, float z)
        {
            Vector3 retval = new Vector3(v1.x * x, v1.y * y, v1.z * z);
            return retval;
        }

        public static Vector3 Divide(this Vector3 v1, Vector3 v2)
        {
            Vector3 retval = new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            return retval;
        }

        public static Vector3 Abs(this Vector3 v)
        {
            return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
        }

        public static Vector3 Average(this List<Vector3> vector3s)
        {
            Vector3 sum = Vector3.zero;

            foreach (Vector3 vector3 in vector3s)
            {
                sum += vector3;
            }

            int numVectors = vector3s.Count;

            sum = new Vector3(sum.x / numVectors, sum.y / numVectors, sum.z / numVectors);

            return sum;
        }

        public static float GreatestDimension(this Vector3 vector)
        {
            if (vector.x > vector.y && vector.x > vector.z)
                return vector.x;
            //At this point we know x is not the greatest, so it must be y or z
            return vector.y > vector.z ? vector.y : vector.z;
        }

        public static Vector3 SwapXandZ(this Vector3 v3)
        {
            return new Vector3(v3.z, v3.y, v3.x);
        }

        public static Vector3Int ToVector3Int(this Vector3 v)
        {
            return new Vector3Int((int)v.x,(int)v.y,(int)v.z);
        }
        
        public static float Max(this Vector3 v)
        {
            return Mathf.Max(v.x, v.y, v.z);
        }


        public static float Min(this Vector3 v)
        {
            return Mathf.Min(v.x, v.y, v.z);
        }

        public static float MaxAbsValue(this Vector3 v)
        {
            float max = v.Max();
            float min = v.Min();

            return max > Mathf.Abs(min) ? max : min;
        }

        public static bool IsUniform(this Vector3 v)
        {
            return Math.Abs(v.x - v.y) < .01f && Math.Abs(v.y - v.z) < .01f;
        }
        
        //=============== Vector4 Extensions ==========================================
        public static float Max(this Vector4 v)
        {
            return Mathf.Max(v.w, v.x, v.y, v.z);
        }

        /// <summary>
        /// returns this vector 4 multiplied by some value such that it's new greatest element is 1. *sort of* like normalization
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector4 Maximized(this Vector4 v)
        {
            float maxValue = Max(v);
            return v / maxValue;
        }

    }
}
