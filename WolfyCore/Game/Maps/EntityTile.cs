using ProtoBuf;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract] public class EntityTile
    {
        [ProtoIgnore] public bool Selected { get; set; }
        [ProtoMember(1)] public Entity Entity { get; set; }

        public EntityTile() { }
    }
}

