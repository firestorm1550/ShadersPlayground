using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class GameObjectAndTransformExtensionMethods
    {
        //=============== Transform and GameObject Extensions ==========================================
        public static void DestroyAllChildren(this Transform obj, bool destroyImmediate = false)
        {
            int numChildren = obj.childCount;
            for (int i = numChildren - 1; i >= 0; i--)
            {
                if(destroyImmediate)
                    Object.DestroyImmediate(obj.GetChild(i).gameObject);
                else
                    Object.Destroy(obj.GetChild(i).gameObject);
            }
        }

        public static void SetAllChildrenActive(this GameObject obj, bool value)
        {
            obj.SetActive(value);
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                obj.transform.GetChild(i).gameObject.SetAllChildrenActive(true);
            }
        }

        public static void SetLayerRecursively(this Transform transform, int layer)
        {
            SetLayerRecursively(transform.gameObject, layer);
        }

        public static void SetLayerRecursively(this GameObject objectToSet, int layer)
        {
            objectToSet.layer = layer;
            foreach (Transform transform in objectToSet.transform)
            {
                if (transform.gameObject != objectToSet)
                    transform.gameObject.SetLayerRecursively(layer);
            }
        }
        public static List<TransformData> GetTransformData(this IEnumerable<GameObject> gameObjects)
        {
            return gameObjects.Select(g => new TransformData(g.transform)).ToList();
        }
        


        public static void Reset(this Transform t)
        {
            t.localScale = Vector3.one;
            t.localRotation = Quaternion.identity;
            t.localPosition = Vector3.zero;
        }

        public static void SetLocal(this Transform t, TransformData transformData)
        {
            t.localScale = transformData.scale;
            t.localRotation = transformData.rotation;
            t.localPosition = transformData.position;
        }

        public static List<TransformData> GetTransformData(this IEnumerable<Transform> transforms)
        {
            return transforms.Select(t => new TransformData(t)).ToList();
        }
    }
}