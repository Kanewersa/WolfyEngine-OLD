using WolfyShared.Engine;

namespace WolfyShared
{
    public static class Runtime
    {
        public static ProgramSettings ProgramSettings { get; set; }
        public static Vector2D TileSize { get; set; }
        public static int GridSize { get; set; }

        public static bool IsWindows { get; set; }
    }
}
