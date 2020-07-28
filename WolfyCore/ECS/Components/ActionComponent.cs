using System.Collections.Generic;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class ActionComponent : EntityComponent
    {
        [ProtoMember(1)] public List<WolfyAction> Actions;

        public ActionComponent() { }
    }
}
