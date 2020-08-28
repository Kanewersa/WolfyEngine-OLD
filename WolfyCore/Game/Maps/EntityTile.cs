using ProtoBuf;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract(SkipConstructor = true)] public class EntityTile
    {
        [ProtoMember(1)] public Entity Entity { get; set; }

        public EntityTile()
        {
            Entity = Entity.Empty;
        }
    }
}

