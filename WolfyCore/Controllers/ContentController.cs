using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.RuntimeBuilder;

namespace WolfyShared.Controllers
{
    public class ContentController
    {
        private static ContentController _instance;
        public static ContentController Instance => _instance ??= new ContentController();

        private RuntimeBuilder RuntimeBuilder { get; set; }

        public TargetPlatform TargetPlatform = TargetPlatform.DesktopGL;
        public GraphicsProfile GraphicsProfile = GraphicsProfile.HiDef;
        public bool CompressContent { get; set; } = true; 

        public void Initialize()
        {
            RuntimeBuilder = new RuntimeBuilder(
                Application.StartupPath,
                Path.Combine(Application.StartupPath, "obj"),
                Path.Combine(Application.StartupPath, "output"),
                TargetPlatform,
                GraphicsProfile,
                CompressContent)
            {
                Logger = new StringBuilderLogger()
            };
        }

        public async Task BuildContent(string[] files)
        {
            await RuntimeBuilder.BuildContent(files);
        }
    }
}
