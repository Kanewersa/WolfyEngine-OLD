using ProtoBuf;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract(SkipConstructor = true)] public class EntityTile
    {
        [ProtoIgnore] public bool Selected { get; set; }
        [ProtoMember(1)] public Entity Entity { get; set; }

        public EntityTile()
        {
            Entity = Entity.Empty;
        }
    }
}

