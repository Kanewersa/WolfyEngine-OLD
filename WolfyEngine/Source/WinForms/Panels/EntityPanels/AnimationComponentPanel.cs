using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DarkUI.Forms;
using WolfyECS;
using WolfyEngine.Forms;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using WolfyCore.Engine;
using Image = System.Drawing.Image;

namespace WolfyEngine.Controls
{
    public partial class AnimationComponentPanel : ComponentPanel
    {
        private AnimationComponent _animationComponent;
        private string _graphicsPath;

        public AnimationComponentPanel(Type componentType) : base(componentType)
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.HasComponent<AnimationComponent>())
            {
                _animationComponent = entity.GetComponent<AnimationComponent>();

                var animation = _animationComponent.Animations.First().Value;
                // TODO Make graphics and animations usage more clear
                _graphicsPath = animation.Image.Path;
                var pngPath = Path.ChangeExtension(_graphicsPath, ".png");
                Console.WriteLine(pngPath);
                if (!string.IsNullOrEmpty(pngPath))
                    if (!WolfyHelper.IsFileLocked(new FileInfo(pngPath)))
                    {
                        FileStream bitmapFile = new FileStream(pngPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        Image loaded = new Bitmap(bitmapFile);
                        bitmapFile.Close();
                        GraphicsPictureBox.Image = loaded;
                    }
                    else
                        DarkMessageBox.ShowWarning(
                            "Missing file " + pngPath + ".",
                            "File not found.");


                FrameCountNumericUpDown.Value = animation.FrameCount;
                DirectionsCountNumericUpDown.Value = animation.DirectionsCount;
            }
            else
            {
                FrameCountNumericUpDown.Value = 4;
                DirectionsCountNumericUpDown.Value = 4;
            }
        }

        public override void Save()
        {
            _animationComponent = Entity.GetOrCreateComponent<AnimationComponent>();

            var frames = (int) FrameCountNumericUpDown.Value;
            var directions = (int) DirectionsCountNumericUpDown.Value;

            var animations = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation(_graphicsPath, frames, directions) }
            };

            _animationComponent.Animations = animations;
            _animationComponent.AnimationManager = new AnimationManager(animations.First().Value);
            _animationComponent.Initialized = false;
        }

        public override void Unload(Entity entity)
        {
            
            entity.RemoveComponent<AnimationComponent>();
            Close();
        }

        private void SelectGraphicsButton_Click(object sender, System.EventArgs e)
        {
            SelectGraphics();
        }

        private void GraphicsPictureBox_DoubleClick(object sender, System.EventArgs e)
        {
            SelectGraphics();
        }

        private void SelectGraphics()
        {
            using var form = new AssetSelectForm(PathsController.Instance.SpritesPath);
            form.OnAssetSelected += Form_OnAssetSelected;
            form.ShowDialog();
        }

        private void Form_OnAssetSelected(string assetName, string fullPath, string relativePath, string extension)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                _graphicsPath = string.Empty;
                return;
            }

            if(extension != ".png") throw new Exception("Sprite must be a png file!");

            using (var temp = new Bitmap(fullPath))
            {
                var img = new Bitmap(temp);
                GraphicsPictureBox.Image = img;
            }

            _graphicsPath = relativePath;
        }
    }
}
