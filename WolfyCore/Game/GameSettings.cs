using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract] public class GameSettings
    {
        [ProtoMember(1)] public string GameName { get; set; }

        [ProtoMember(2)] public int StartingMap { get; set; }
        [ProtoMember(3)] public Vector2 StartingCoordinates { get; set; }


        public GameSettings()
        {
            GameName = "MyGame";
            StartingMap = 0;
            StartingCoordinates = new Vector2(0,0);
        }
    }
}
