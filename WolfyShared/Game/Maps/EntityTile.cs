using System.Collections.Generic;
using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityTile
    {
        [ProtoIgnore] public bool Selected { get; set; }
        [ProtoIgnore] public int Entity { get; set; } = 0;

        public EntityTile() { }
    }
}

