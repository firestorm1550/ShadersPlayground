using System.Collections.Generic;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class CompoundAction : UndoableAction
    {
        public List<UndoableAction> actions;

        public CompoundAction(List<UndoableAction> actions, string name = null)
        {
            this.actions = new List<UndoableAction>(actions);
            if (name != null)
                this.name = name;
        }

        protected override void MyDo()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Do();
            }
        }

        protected override void MyUndo()
        {
            for (int i = actions.Count - 1; i >= 0; i-- )
            {
                actions[i].Undo();
            }
        }

        protected override void MyRedo()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Redo();
            }
        }

        public override void Dispose()
        {
            foreach (UndoableAction action in actions)
            {
                action.Dispose();
            }
        }
    }
}