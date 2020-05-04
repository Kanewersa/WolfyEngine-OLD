using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class NameComponent : EntityComponent
    {
        [ProtoMember(1)] public string Name { get; set; }
    }
}
