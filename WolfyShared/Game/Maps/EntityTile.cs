using System.Collections.Generic;
using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityTile
    {
        [ProtoMember(1)] public Entity Entity { get; set; }

        [ProtoIgnore] public bool Selected { get; set; }

        public EntityTile() { }
    }
}

