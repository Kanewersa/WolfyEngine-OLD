using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class ActionComponent : EntityComponent
    {
        [ProtoMember(1)] public List<WolfyAction> Actions { get; set; }
        [ProtoMember(2)] public bool Executed { get; set; }

        public ActionComponent() { }
    }
}
