using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TimeEventComponent : EntityComponent
    {
        [ProtoMember(1)] public Dictionary<InGameTime, List<WolfyAction>> Events { get; private set; }
        [ProtoMember(2)] public InGameTime LastActionsTime { get; private set; }

        public bool HasEvents(InGameTime time)
        {
            return Events.ContainsKey(time);
        }

        public List<WolfyAction> GetActions(InGameTime time)
        {
            LastActionsTime = time;
            return Events[time];
        }
    }
}
