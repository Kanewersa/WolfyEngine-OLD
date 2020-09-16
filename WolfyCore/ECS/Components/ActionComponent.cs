using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class ActionComponent : EntityComponent
    {
        [ProtoMember(1)] public List<WolfyAction> Actions { get; set; }

        public ActionComponent() { }
    }
}
