using System;
using WolfyEngine;
using WolfyCore;
using WolfyCore.Engine;

namespace WolfyGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize WolfyEngine
            WolfyManager.WolfyInitialize();

            // TODO Move tile size property from project scope to game settings
            Runtime.TileSize = new Vector2D(32,32);
            Runtime.GridSize = 32;

            using (var game = new WolfyGame())
                game.Run();
        }
    }
}
