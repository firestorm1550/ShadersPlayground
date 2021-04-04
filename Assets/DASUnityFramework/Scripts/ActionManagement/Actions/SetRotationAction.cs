using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class SetRotationAction : UndoableAction
    {
        protected List<Transform> _transforms;
        protected List<Quaternion> _startingRotations;
        protected List<Quaternion> _endingRotations;
    
        public SetRotationAction(List<Transform> transforms, List<Quaternion> startingRotations, List<Quaternion> endingRotations)
        {
            if(transforms.Count != startingRotations.Count || transforms.Count != endingRotations.Count)
                throw new ArgumentException("All 3 lists must be the same length in a SetRotationAction");
        
            _transforms = new List<Transform>(transforms);
            _startingRotations = new List<Quaternion>(startingRotations);
            _endingRotations = new List<Quaternion>(endingRotations);
        }

        public SetRotationAction(Transform transform, Quaternion start, Quaternion end) : 
            this(new List<Transform> {transform}, new List<Quaternion> {start}, new List<Quaternion> {end})
        {
            //look up two lines ;)
        }
        protected override void MyDo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].localRotation = _endingRotations[i];
            }
        }

        protected override void MyUndo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].localRotation = _startingRotations[i];
            }
        }
    }
}