using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEditor;
using UnityEngine;

namespace DASUnityFramework.Editor
{
    public class PivotPlacement
    {
        static void PlacePivotInBoundingBox(Vector3 normalizedPosition, GameObject rootObject)
        {
            //Get Renderers
            List<Renderer> renderers = new List<Renderer>();
            List<MeshRenderer> meshRenderers = rootObject.GetComponentsInChildren<MeshRenderer>().ToList();
            List<SkinnedMeshRenderer> skinnedMeshRenderers =
                rootObject.GetComponentsInChildren<SkinnedMeshRenderer>().ToList();

            if (meshRenderers.Any())
                renderers.AddRange(meshRenderers);
            if (skinnedMeshRenderers.Any())
                renderers.AddRange(skinnedMeshRenderers);

            //Calculate aggregate bounds
            Bounds bounds = renderers[0].bounds;
            foreach (Renderer renderer in renderers)
            {
                bounds.Encapsulate(renderer.bounds);
            }


            Vector3 pivotTargetPoint = bounds.center + bounds.extents.Multiply(normalizedPosition);
            Vector3 offsetInWorldCoords = rootObject.transform.position - pivotTargetPoint;

            foreach (Transform transform in rootObject.transform)
            {
                transform.position += offsetInWorldCoords;
            }

            rootObject.transform.position = pivotTargetPoint;
        }


        [MenuItem("Tools/Place Pivot/Left/Bottom-Back")]
        private static void LeftBottomBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, -1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Bottom-Center")]
        private static void LeftBottomCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, -1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Bottom-Front")]
        private static void LeftBottomFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, -1, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Center-Back")]
        private static void LeftCenterBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 0, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Center-Center")]
        private static void LeftCenterCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 0, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Center-Front")]
        private static void LeftCenterFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 0, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Top-Back")]
        private static void LeftTopBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Top-Center")]
        private static void LeftTopCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Left/Top-Front")]
        private static void LeftTopFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(-1, 1, 1), g);
        }


        [MenuItem("Tools/Place Pivot/Center/Bottom-Back")]
        private static void CenterBottomBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, -1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Bottom-Center")]
        private static void CenterBottomCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, -1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Bottom-Front")]
        private static void CenterBottomFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, -1, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Center-Back")]
        private static void CenterCenterBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 0, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Center-Center")]
        private static void CenterCenterCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 0, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Center-Front")]
        private static void CenterCenterFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 0, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Top-Back")]
        private static void CenterTopBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Top-Center")]
        private static void CenterTopCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Center/Top-Front")]
        private static void CenterTopFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(0, 1, 1), g);
        }


        [MenuItem("Tools/Place Pivot/Right/Bottom-Back")]
        private static void RightBottomBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, -1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Bottom-Center")]
        private static void RightBottomCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, -1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Bottom-Front")]
        private static void RightBottomFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, -1, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Center-Back")]
        private static void RightCenterBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 0, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Center-Center")]
        private static void RightCenterCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 0, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Center-Front")]
        private static void RightCenterFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 0, 1), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Top-Back")]
        private static void RightTopBack()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 1, -1), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Top-Center")]
        private static void RightTopCenter()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 1, 0), g);
        }

        [MenuItem("Tools/Place Pivot/Right/Top-Front")]
        private static void RightTopFront()
        {
            GameObject[] obs = Selection.gameObjects;
            foreach (GameObject g in obs)
                PlacePivotInBoundingBox(new Vector3(1, 1, 1), g);
        }
    }
}