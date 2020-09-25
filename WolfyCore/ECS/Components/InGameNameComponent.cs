using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class InGameNameComponent : EntityComponent
    {
        [ProtoMember(1)] public string Name { get; set; }

        public InGameNameComponent() { }

        public InGameNameComponent(string name)
        {
            Name = name;
        }
    }
}
