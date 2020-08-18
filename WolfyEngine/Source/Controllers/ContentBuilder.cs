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

        public TargetPlatform TargetPlatform = TargetPlatform.Windows;
        public GraphicsProfile GraphicsProfile = GraphicsProfile.HiDef;
        public bool CompressContent { get; set; } = true; 

        public void Initialize()
        {
            RuntimeBuilder = new RuntimeBuilder(
                Path.Combine(Application.StartupPath, "working"),
                Path.Combine(Application.StartupPath, "obj"),
                Path.Combine(Application.StartupPath, "output"),
                TargetPlatform,
                GraphicsProfile,
                CompressContent)
            {
                Logger = new StringBuilderLogger()
            };

            // Add GeonBit.UI data types
            RuntimeBuilder.AddReferences("C:\\Users\\Kanew\\source\\repos\\WolfyEngine\\packages\\GeonBit.UI.3.4.0.1\\lib\\geonbitui\\DataTypes.dll");
        }

        public async Task BuildContent(string[] files)
        {
            await RuntimeBuilder.BuildContent(files);
        }
    }
}
