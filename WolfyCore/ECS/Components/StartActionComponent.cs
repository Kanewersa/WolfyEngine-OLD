using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class StartActionComponent : EntityComponent
    {
        /// <summary>
        /// List of actions to be executed.
        /// </summary>
        [ProtoMember(1)] public List<WolfyAction> Actions { get; set; }

        /// <summary>
        /// Determines if actions are executed simultaneously or are added to queue.
        /// </summary>
        [ProtoMember(2)] public bool Asynchronous { get; private set; }

        /// <summary>
        /// Determines if actions were added to ActionsManager.
        /// </summary>
        [ProtoMember(3)] public bool Executed { get; set; }

        public StartActionComponent() { }

        public StartActionComponent(List<WolfyAction> actions, bool asynchronous)
        {
            Actions = actions;
            Asynchronous = asynchronous;
        }

        public StartActionComponent(WolfyAction action, bool asynchronous)
        {
            Actions = new List<WolfyAction> { action };
            Asynchronous = asynchronous;
        }
    }
}
