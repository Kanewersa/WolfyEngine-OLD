using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using MonoGame.RuntimeBuilder;

namespace WolfyCore.Controllers
{
    public class ContentBuilder
    {
        private static ContentBuilder _instance;
        public static ContentBuilder Instance => _instance ??= new ContentBuilder();

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
