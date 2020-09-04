using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.Game
{
    [ProtoContract] public class GameSettings
    {
        [ProtoMember(1)] public string GameName { get; set; }

        public GameSettings()
        {
            GameName = "MyGame";
        }
    }
}
