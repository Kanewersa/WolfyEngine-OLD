using WolfyCore.Engine;

namespace WolfyCore
{
    public static class Runtime
    {
        public static Vector2D TileSize { get; set; }
        public static int GridSize { get; set; }
        public static int GameScreenWidth { get; set; }
        public static int GameScreenHeight { get; set; }
        public static bool IsWindows { get; set; }
    }
}
