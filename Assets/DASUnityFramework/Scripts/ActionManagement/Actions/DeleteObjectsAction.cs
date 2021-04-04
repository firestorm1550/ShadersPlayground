using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class DeleteObjectsAction : UndoableAction
    {
        readonly List<ObjectState> _objectsStartStates = new List<ObjectState>();
        
        public DeleteObjectsAction(GameObject gameObject) : this(new List<GameObject> {gameObject})
        {

        }

        public DeleteObjectsAction(List<GameObject> objects)
        {
            foreach (GameObject o in objects)
                _objectsStartStates.Add(new ObjectState(o));
        }

        protected override void MyDo()
        {
            base.MyDo();
            MoveObjectsToGraveyard();
        }

        protected override void MyUndo()
        {
            base.MyUndo();
            RemoveObjectsFromGraveyard();
        }

        protected virtual void MoveObjectsToGraveyard()
        {
            foreach (ObjectState obj in _objectsStartStates)
            {
                obj.gameObject.SetActive(false);
                obj.gameObject.transform.parent = actionManager.transform;
            }
        }

        protected virtual void RemoveObjectsFromGraveyard()
        {
            foreach (ObjectState startState in _objectsStartStates)
            {
                startState.RevertObjectToState();
            }
        }

        private class ObjectState
        {
            public GameObject gameObject;
            public Transform parent;
            public TransformData transformData;
            public bool activeSelf;

            public ObjectState(GameObject obj)
            {
                gameObject = obj;
                parent = obj.transform.parent;
                transformData = new TransformData(obj.transform);
                activeSelf = obj.activeSelf;
            }

            public void RevertObjectToState()
            {
                gameObject.transform.parent = parent;
                gameObject.transform.SetLocal(transformData);
                gameObject.SetActive(activeSelf);
            }
        }
    }
}