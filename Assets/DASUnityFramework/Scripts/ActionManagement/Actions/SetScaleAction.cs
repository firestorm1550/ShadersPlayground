using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class SetScaleAction : UndoableAction
    {
        protected List<Transform> _transforms;
        protected List<Vector3> startScales;
        protected List<Vector3> endScales;
        
        public SetScaleAction(List<Transform> transforms, List<Vector3> startingScales, List<Vector3> endingScales)
        {
            if(transforms.Count != startingScales.Count || transforms.Count != endingScales.Count)
                throw new ArgumentException("All 3 lists must be the same length in a SetScaleAction");

            startScales = new List<Vector3>(startingScales);
            endScales = new List<Vector3>(endingScales);
            _transforms = new List<Transform>(transforms); 
        }

        public SetScaleAction(Transform transform, Vector3 startScale, Vector3 endScale) : this(
            new List<Transform> {transform}, new List<Vector3> {startScale}, new List<Vector3> {endScale})
        {
            
        }

        protected override void MyDo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].localScale = endScales[i];
            }
        }

        protected override void MyUndo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].localScale = startScales[i];
            }
        }
    }
}