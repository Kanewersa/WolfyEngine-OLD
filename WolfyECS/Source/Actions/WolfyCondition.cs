using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    /// <summary>
    /// A special case of WolfyAction which contains other actions and
    /// executes them based on given condition.
    /// </summary>
    [ProtoContract] public abstract class WolfyCondition : WolfyAction
    {
        /// <summary>
        /// Actions to execute when condition is met.
        /// </summary>
        [ProtoMember(201)] protected List<WolfyAction> IfActions;

        /// <summary>
        /// Actions to execute when condition is not met.
        /// </summary>
        [ProtoMember(202)] protected List<WolfyAction> ElseActions;

        /// <summary>
        /// Determines whether condition is met.
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsMet();

        /// <summary>
        /// Returns the actions to execute based on condition fulfillment.
        /// </summary>
        /// <returns></returns>
        public List<WolfyAction> GetActions()
        {
            return IsMet() ? IfActions : ElseActions;
        }

        public List<WolfyAction> GetIfActions()
        {
            return IfActions;
        }

        public List<WolfyAction> GetElseActions()
        {
            return ElseActions;
        }
    }
}
