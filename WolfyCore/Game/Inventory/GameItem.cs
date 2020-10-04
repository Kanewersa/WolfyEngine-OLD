using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract] public abstract class GameItem
    {
        [ProtoMember(1)] public int Id { get; set;  }
        [ProtoMember(2)] public string Name { get; set; }
        [ProtoMember(3)] public string Description { get; set; }
        [ProtoMember(4)] public Image Image { get; set; }
        [ProtoMember(5)] public int Price { get; set; }
    }
}
