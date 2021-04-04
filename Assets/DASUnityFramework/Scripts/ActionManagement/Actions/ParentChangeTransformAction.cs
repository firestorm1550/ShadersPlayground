using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class ParentChangeTransformAction : TransformAction
    {
        private readonly List<Transform> _startParents;
        private readonly List<Transform> _endParents;

        public ParentChangeTransformAction(List<Transform> transforms, List<Transform> startParents, List<Transform> endParents, List<TransformData> start, List<TransformData> end) : base(transforms, start, end)
        {
            _startParents = new List<Transform>(startParents);
            _endParents = new List<Transform>(endParents);
        }

        public ParentChangeTransformAction(Transform t, Transform startParent, Transform endParent, TransformData start, TransformData end) : 
            this(new List<Transform>{t},new List<Transform>{startParent},new List<Transform>{endParent} 
                ,new List<TransformData>{start}, new List<TransformData> {end})
        {
            
        }

        protected override void MyDo()
        {
            for (int i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].parent = _endParents[i];
            }
            base.MyDo();
        }

        protected override void MyUndo()
        {
            for (int i = 0; i < _transforms.Count; i++)
            {
                _transforms[i].parent = _startParents[i];
            }
            base.MyUndo();
        }
    }
}