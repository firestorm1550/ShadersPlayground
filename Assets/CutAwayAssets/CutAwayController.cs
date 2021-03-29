using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CutAwayController : MonoBehaviour
{
    public Color fresnelColor;
    public float fresnelPower;
    public Vector3 planeNormal;
    public Vector3 planePositionWorld;

    private List<MeshRenderer> _fresnels = new List<MeshRenderer>();
    private List<MeshRenderer> _textured = new List<MeshRenderer>();
    private static readonly int Color = Shader.PropertyToID("_Color");
    private static readonly int FresnelPower = Shader.PropertyToID("_FresnelPower");
    private static readonly int PlaneNormal = Shader.PropertyToID("_PlaneNormal");
    private static readonly int PlanePosition = Shader.PropertyToID("_PlanePosition");

    // Start is called before the first frame update
    void Start()
    {
        CheckForNewCutawayShadersInChildren();
    }

    private void Update()
    {
        ApplySettings(fresnelColor, fresnelPower, planeNormal, planePositionWorld);
    }

    public void ApplySettings(Color fresnelColor, float fresnelPower, Vector3 planeNormal, Vector3 planePosition)
    {
        foreach (MeshRenderer fresnel in _fresnels)
        {
            Material[] materials = fresnel.materials;

            foreach (Material material in materials)
            {
                material.SetColor(Color, fresnelColor);
                material.SetFloat(FresnelPower, fresnelPower);
                material.SetVector(PlaneNormal, planeNormal);
                material.SetVector(PlanePosition, planePosition);
            }
            
            fresnel.materials = materials;
        }

        foreach (MeshRenderer texturedMeshRenderer in _textured)
        {
            Material[] materials = texturedMeshRenderer.materials;

            foreach (Material material in materials)
            {
                material.SetVector(PlaneNormal, planeNormal);
                material.SetVector(PlanePosition, planePosition);
            }
            
            texturedMeshRenderer.materials = materials;
        }
    }
    public void CheckForNewCutawayShadersInChildren()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            string shaderName = meshRenderer.material.shader.name.ToLower();
            if (shaderName.Contains("cutaway"))
            {
                if (shaderName.Contains("fresnel"))
                    _fresnels.Add(meshRenderer);
                else if (shaderName.Contains("textured"))
                    _fresnels.Add(meshRenderer);
            }
        }
    }
}
