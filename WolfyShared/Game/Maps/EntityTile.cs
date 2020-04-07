using System.Collections.Generic;
using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityTile
    {
        [ProtoIgnore] public bool Selected { get; set; }
        [ProtoIgnore] public int EntityId { get; set; }

        public EntityTile() { }
    }
}

