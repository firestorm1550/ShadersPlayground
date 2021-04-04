using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class SetActiveAction : UndoableAction
    {
    
        private GameObject _gameObject;
        private bool _initialState;
        private bool _newState;
        
        public SetActiveAction(GameObject gameObject, bool initialState, bool newState)
        {
            _gameObject = gameObject;
            _initialState = initialState;
            _newState = newState;
        }

        public SetActiveAction(Component c, bool initialState, bool newState) : this(c.gameObject, initialState, newState)
        {
            
        }
        
        //saves the current state and uses the new state
        public SetActiveAction(Component c, bool newState) : this(c, c.gameObject.activeSelf, newState)
        {
            
        }
        
        

        protected override void MyDo()
        {
            _gameObject.SetActive(_newState);
        }

        protected override void MyUndo()
        {
            _gameObject.SetActive(_initialState);
        }
    }
}