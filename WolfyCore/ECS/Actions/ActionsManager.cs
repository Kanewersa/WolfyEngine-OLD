using System.Collections.Generic;
using System.Linq;
using Nito.Collections;
using ProtoBuf;

namespace WolfyCore.Actions
{
    /// <summary>
    /// Manages all WolfyActions.
    /// </summary>
    [ProtoContract] public class ActionsManager
    {
        /// <summary>
        /// Currently executed action.
        /// </summary>
        [ProtoMember(1)] public WolfyAction CurrentAction { get; set; }

        /// <summary>
        /// All pending actions to be executed.
        /// </summary>
        [ProtoIgnore] private Deque<WolfyAction> _pendingActions;

        // TODO Create serializable Deque to replace wrappers.
        [ProtoMember(2)]
        public WolfyAction[] Actions
        {
            get => _pendingActions.ToArray();
            set => _pendingActions = new Deque<WolfyAction>(value);
        }

        /// <summary>
        /// Determines if there is an action being executed.
        /// </summary>
        private bool ExecutingAction => CurrentAction != null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ActionsManager()
        {
            _pendingActions = new Deque<WolfyAction>();
        }

        /// <summary>
        /// Updates the <see cref="ActionsManager"/> and performs all operations on WolfyActions.
        /// </summary>
        public void Update()
        {
            if (ExecutingAction)
            {
                if (CurrentAction.Completed)
                {
                    EndCurrentAction();
                    return;
                }
                
                CurrentAction.Validate();
                return;
            }

            if (_pendingActions.Count > 0)
                StartNewAction();
        }

        /// <summary>
        /// Starts the execution of next action in pending actions.
        /// </summary>
        private void StartNewAction()
        {
            CurrentAction = _pendingActions.First();

            if (CurrentAction is WolfyCondition condition)
            {
                FillConditionActions(condition);
                condition.Complete();
                return;
            }

            CurrentAction.Execute();

            if (CurrentAction.Asynchronous)
                EndCurrentAction();
        }

        /// <summary>
        /// Removes current action from pending actions.
        /// </summary>
        private void EndCurrentAction()
        {
            CurrentAction = null;
            _pendingActions.RemoveFromFront();
        }

        /// <summary>
        /// Gets all valid actions from <see cref="WolfyCondition"/> and adds them to pending actions.
        /// </summary>
        /// <param name="condition"></param>
        private void FillConditionActions(WolfyCondition condition)
        {
            var actions = condition.GetActions();
            PushActions(actions);
        }

        /// <summary>
        /// Adds all actions in given list to pending actions.
        /// </summary>
        /// <param name="actions"></param>
        public void PushActions(List<WolfyAction> actions)
        {
            _pendingActions.InsertRange(0, actions);
        }
    }
}