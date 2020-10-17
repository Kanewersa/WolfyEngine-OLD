using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;

namespace WolfyCore.Actions
{
    /// <summary>
    /// A special case of WolfyAction which contains other actions and
    /// executes them based on given condition.
    /// </summary>
    [ProtoInclude(201, typeof(BoolCondition))]
    [ProtoInclude(202, typeof(VariableCondition))]
    [ProtoContract] public abstract class WolfyCondition : WolfyAction
    {
        /// <summary>
        /// Actions to execute when condition is met.
        /// </summary>
        [ProtoMember(101)] protected List<WolfyAction> IfActions;

        /// <summary>
        /// Actions to execute when condition is not met.
        /// </summary>
        [ProtoMember(102)] protected List<WolfyAction> ElseActions;

        /// <summary>
        /// Determines whether condition is met.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsMet();

        /// <summary>
        /// Returns the actions to execute based on condition fulfillment.
        /// </summary>
        /// <returns></returns>
        public List<WolfyAction> GetActions()
        {
            return IsMet()
                ? IfActions ??= new List<WolfyAction>()
                : ElseActions ??= new List<WolfyAction>();
        }

        public List<WolfyAction> GetIfActions()
        {
            return IfActions ??= new List<WolfyAction>();
        }

        public List<WolfyAction> GetElseActions()
        {
            return ElseActions ??= new List<WolfyAction>();
        }

        public void SetActions(List<WolfyAction> ifActions, List<WolfyAction> elseActions)
        {
            IfActions = ifActions;
            ElseActions = elseActions;
        }
    }
}
