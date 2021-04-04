using System;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    [Serializable]
    public class UndoableAction
    {
        public string name;
        public Action Do;
        public Action Undo;
        public Action Redo;

        //This should be set when the Action Manager executes this action
        public ActionManager actionManager;

        public UndoableAction(string actionName, Action action, Action undo, Action redo)
        {
            name = actionName;
            Do = action;
            Undo = undo;
            Redo = redo;
        }

        public UndoableAction()
        {
            name = GetType().ToString();
            if(name.Contains("."))
                name = name.Substring(name.LastIndexOf('.') + 1);
            Do = MyDo;
            Undo = MyUndo;
            Redo = MyRedo;
        }

        protected virtual void MyDo()
        {
        
        }

        protected virtual void MyUndo()
        {
        
        }

        protected virtual void MyRedo()
        {
            MyDo();
        }

        //this is used by some actions to get rid of any saved state. For example, the InstantiateHullPartsAction,
        //when it is Undone, it moves the HullParts to the HullPart Graveyard. However, if another action is taken at that point,
        //it'll be removed from the redo stack, so we no longer need to keep those objects.
        public virtual void Dispose()
        {
        
        }

    }
}
