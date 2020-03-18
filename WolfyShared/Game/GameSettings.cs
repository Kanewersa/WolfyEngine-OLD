using WolfyShared.Engine;

namespace WolfyShared.Game
{
    public class GameSettings
    {
        public string GameName { get; set; }

        public int StartingMap { get; set; }
        public Vector2D StartingCoordinates { get; set; }


        public GameSettings()
        {
            GameName = "MyGame";
        }
    }
}
