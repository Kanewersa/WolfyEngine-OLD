using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract] public class Tile
    {
        [ProtoMember(1)] public Vector2D Source { get; set; }
        [ProtoMember(2)] public RefBool Passage { get; set; }
        [ProtoMember(3)] public RefBool Bush { get; set; }

        [ProtoIgnore] public bool Hovered { get; set; }

        public Tile() { }

        public Tile(Vector2D source)
        {
            Source = source;
            Passage = true;
        }

        public bool Empty()
        {
            return Source == new Vector2D(-1, -1);
        }
    }
}
