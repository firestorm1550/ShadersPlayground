using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MaterialSwapper : Editor
{
    [MenuItem("Tools/Duplicate MeshRenderers and Set to CutAwayFresnel materials")]
    private static void CreateFresnelMeshRenderers()
    {
        List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
        foreach (GameObject gameObject in Selection.gameObjects)
            meshRenderers.Add(gameObject.GetComponent<MeshRenderer>());

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            MeshRenderer fresnelRenderer = Instantiate(meshRenderer,meshRenderer.transform.parent);
            fresnelRenderer.gameObject.name = meshRenderer.gameObject.name + " - Fresnel";
            
            Material[] texturedMaterials = fresnelRenderer.sharedMaterials;
            Material[] fresnelMaterials = new Material[texturedMaterials.Length];

            for (int i = 0; i < texturedMaterials.Length; i++)
            {
                Material texturedMaterial = texturedMaterials[i];
                string texturedMaterialPath = AssetDatabase.GetAssetPath(texturedMaterial);
                string fresnelMaterialPath = texturedMaterialPath.Split('.')[0] + "-Fresnel.mat";

                if (File.Exists(fresnelMaterialPath))
                {
                    //try to find a fresnel material
                    fresnelMaterials[i] = AssetDatabase.LoadAssetAtPath<Material>(fresnelMaterialPath);
                }
                else
                {
                    //make a copy of the material but with Fresnel shader
                    Material fresnelMaterial = Instantiate(texturedMaterial);
                    fresnelMaterial.name = Path.GetFileName(fresnelMaterialPath);
                    fresnelMaterial.shader = Shader.Find("Shader Graph/CutAwayFresnel");
                    AssetDatabase.CreateAsset(fresnelMaterial, fresnelMaterialPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    fresnelMaterials[i] = AssetDatabase.LoadAssetAtPath<Material>(fresnelMaterialPath);
                }
            }

            fresnelRenderer.materials = fresnelMaterials;
        }
    }
}
