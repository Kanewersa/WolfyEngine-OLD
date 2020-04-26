using ProtoBuf;

namespace WolfyShared.Game
{
    [ProtoContract]
    public class TilesetInfo
    {
        [ProtoMember(1)] public string TilesetName { get; set; }
        [ProtoMember(2)] public string FileName { get; set; }
        [ProtoMember(3)] public int TilesetId { get; set; }
        [ProtoMember(4)] public string GraphicsPath { get; set; }
    }
}
