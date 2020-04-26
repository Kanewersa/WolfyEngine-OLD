using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract]
    public class MapInfo
    {
        [ProtoMember(1)] public string MapName { get; set; }
        [ProtoMember(2)] public string FileName { get; set; }
        [ProtoMember(3)] public int MapId { get; set; }
    }
}
