using System;
using WolfyEngine;

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

            using (var game = new WolfyGame())
                game.Run();
        }
    }
}
