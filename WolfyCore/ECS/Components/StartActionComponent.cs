using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class StartActionComponent : EntityComponent
    {
        [ProtoMember(1)] public Entity MetEntity { get; set; }
        public StartActionComponent() { }

        public StartActionComponent(Entity metEntity)
        {
            MetEntity = metEntity;
        }
    }
}
