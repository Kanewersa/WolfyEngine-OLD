using System.Collections.Generic;
using ProtoBuf;
using WolfyECS;

namespace WolfyShared.Game
{
    [ProtoContract] public class EntityTile
    {
        [ProtoIgnore] public bool Selected { get; set; }
        [ProtoIgnore] public uint EntityId => Entity.Id;
        [ProtoMember(1, AsReference = true)] public Entity Entity { get; set; }

        public EntityTile() { }
    }
}

