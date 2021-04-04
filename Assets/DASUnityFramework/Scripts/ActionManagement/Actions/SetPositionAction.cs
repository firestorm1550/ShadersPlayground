using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class SetPositionAction : UndoableAction
    {
        protected List<Transform> _transforms;
        protected List<Vector3> _startingPositions;
        protected List<Vector3> _endingPositions;

        private bool useLocalPosition;
    
        public SetPositionAction(List<Transform> transforms, List<Vector3> startingPositions, List<Vector3> endingPositions, bool local = true)
        {
            if(transforms.Count != startingPositions.Count || transforms.Count != endingPositions.Count)
                throw new ArgumentException("All 3 lists must be the same length in a SetPositionAction");
        
            _transforms = new List<Transform>(transforms);
            _startingPositions = new List<Vector3>(startingPositions);
            _endingPositions = new List<Vector3>(endingPositions);
            useLocalPosition = local;
        }

        public SetPositionAction(Transform transform, Vector3 start, Vector3 end, bool local = true) : 
            this(new List<Transform> {transform}, new List<Vector3> {start}, new List<Vector3> {end}, local)
        {
            //look up two lines ;)
        }
        protected override void MyDo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                if (useLocalPosition)
                    _transforms[i].localPosition = _endingPositions[i];
                else
                    _transforms[i].position = _endingPositions[i];
            }
        }

        protected override void MyUndo()
        {
            for (var i = 0; i < _transforms.Count; i++)
            {
                if (useLocalPosition)
                    _transforms[i].localPosition = _startingPositions[i];
                else
                    _transforms[i].position = _startingPositions[i];
            }
        }
    }
}
