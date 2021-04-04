using System;
using System.Collections;
using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using DASUnityFramework.Scripts.Layout3D;
using UnityEngine;

public class RenderBoundsLayoutElement3D : LayoutElement3D
{
    private Bounds? _bounds;
    
    
    public void RecalculateBounds()
    {
        _bounds = gameObject.MakeBoundingBoxForObjectRenderers();
    }

    public override float GetSize(Vector3 inAxis)
    {
        if(_bounds.HasValue == false )
            RecalculateBounds();
        return _bounds.Value.size.magnitude;
    }
    
}
