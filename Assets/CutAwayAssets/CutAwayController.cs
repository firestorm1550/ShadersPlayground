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
            fresnel.material.SetColor(Color, fresnelColor);
            fresnel.material.SetFloat(FresnelPower, fresnelPower);
            fresnel.material.SetVector(PlaneNormal, planeNormal);
            fresnel.material.SetVector(PlanePosition, planePosition);
        }

        foreach (MeshRenderer texturedMeshRenderer in _textured)
        {
            texturedMeshRenderer.material.SetVector(PlaneNormal, planeNormal);
            texturedMeshRenderer.material.SetVector(PlanePosition, planePosition);
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
