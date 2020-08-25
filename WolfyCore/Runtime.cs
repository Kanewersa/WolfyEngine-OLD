using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Services;
using WolfyCore.Engine;

namespace WolfyCore
{
    /// <summary>
    /// Contains all static variables needed to run program.
    /// </summary>
    public static class Runtime
    {
        public static Vector2D TileSize { get; set; }
        public static int GridSize { get; set; }
        public static int GameScreenWidth { get; set; }
        public static int GameScreenHeight { get; set; }
        public static bool IsWindows { get; set; }

        public static SwapChainRenderTarget RenderTarget { get; set; }
    }
}
