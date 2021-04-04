using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.ActionManagement.Actions;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement
{
    public class ActionManager : MonoBehaviour
    {
        public Stack<UndoableAction> ActionsDone => actionsDone;
        [SerializeField] private List<string> debugActionsDoneStack = new List<string>();
        public Stack<UndoableAction> ActionsUndone => actionsUndone;
        [SerializeField] private List<string> debugActionsUndoneStack = new List<string>();

        private Stack<UndoableAction> actionsDone = new Stack<UndoableAction>();
        private Stack<UndoableAction> actionsUndone = new Stack<UndoableAction>();

        public void Execute(UndoableAction action, bool isUndoable = true)
        {
            action.actionManager = this;
            action.Do();

            if (isUndoable)
            {
                foreach (UndoableAction redoableAction in actionsUndone)
                {
                    redoableAction.Dispose();
                }

                actionsUndone = new Stack<UndoableAction>();
                actionsDone.Push(action);
                RefreshDebugLists();
            }
        }

        public void UndoAction(bool isRedoable = true)
        {
            if (actionsDone.Any())
            {
                UndoableAction action = actionsDone.Pop();
                if (isRedoable)
                {
                    actionsUndone.Push(action);
                    RefreshDebugLists();
                }

                action.Undo.Invoke();
            }
        }

        public void RedoAction()
        {
            if (actionsUndone.Any())
            {
                UndoableAction action = actionsUndone.Pop();
                action.Redo.Invoke();
                actionsDone.Push(action);
                RefreshDebugLists();
            }    
        }

        //squashes the last 'numActions' actions into a single CompoundAction
        public void SquashDoneActions(int numActions, string name = null)
        {
            List<UndoableAction> actions = new List<UndoableAction>();
            for(int i =0; i< numActions; i++)
                actions.Insert(0,actionsDone.Pop());
            if (name == null)
            {
                name = "";
                actions.ForEach(a => name += a.name);
            }

            actionsDone.Push(new CompoundAction(actions, name));
            RefreshDebugLists();
        }

        private void RefreshDebugLists()
        {
            debugActionsDoneStack = new List<string>(actionsDone.Select(a=>a.name));
            debugActionsUndoneStack = new List<string>(actionsUndone.Select(a=>a.name));
        }

        public void PopDone()
        {
            actionsDone.Pop();
            RefreshDebugLists();
        }

        public void ClearAllActions()
        {
            foreach (UndoableAction action in actionsUndone)
            {
                action.Dispose();
            }

            foreach (UndoableAction action in actionsDone)
            {
                action.Dispose();
            }

            actionsUndone = new Stack<UndoableAction>();
            actionsDone = new Stack<UndoableAction>();
            RefreshDebugLists();
        }
    
    }
}
