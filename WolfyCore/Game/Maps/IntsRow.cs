using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class VectorsRow
    {
        [ProtoMember(1)] public int Width { get; set; }
        [ProtoMember(2)] public Vector2D[] Source { get; set; }

        public VectorsRow() { }

        public VectorsRow(int width)
        {
            Width = width;
            Source = new Vector2D[width];

            for (var i = 0; i < width; i++)
            {
                Source[i] = new Vector2D(-1, -1);
            }
        }
    }
}
