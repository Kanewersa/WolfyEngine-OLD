﻿using ProtoBuf;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    [ProtoContract] public class GameSettings
    {
        [ProtoMember(1)] public string GameName { get; set; }

        [ProtoMember(2)] public int StartingMap { get; set; }
        [ProtoMember(3)] public Vector2D StartingCoordinates { get; set; }


        public GameSettings()
        {
            GameName = "MyGame";
            StartingMap = 0;
            StartingCoordinates = new Vector2D(0,0);
        }
    }
}
