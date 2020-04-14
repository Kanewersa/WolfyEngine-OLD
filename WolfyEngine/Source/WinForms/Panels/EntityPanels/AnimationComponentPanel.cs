using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WolfyECS;
using WolfyEngine.Forms;
using WolfyShared.Controllers;
using WolfyShared.ECS;
using WolfyShared.Engine;

namespace WolfyEngine.Controls
{
    public partial class AnimationComponentPanel : ComponentPanel
    {
        private AnimationComponent _animationComponent;
        private string _graphicsPath;

        public AnimationComponentPanel()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.HasComponent<AnimationComponent>())
            {
                _animationComponent = entity.GetComponent<AnimationComponent>();

                //_graphicsPath = _animationComponent.
            }
            else
            {
                
            }
        }

        public override void Save()
        {
            _animationComponent = Entity.GetIfHasComponent<AnimationComponent>();

            var frames = (int) FrameCountNumericUpDown.Value;
            var directions = (int) DirectionsCountNumericUpDown.Value;

            var animations = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation(_graphicsPath, frames, directions) }
            };

            _animationComponent.Animations = animations;
            _animationComponent.AnimationManager = new AnimationManager(animations.First().Value, 32);
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

        private void Form_OnAssetSelected(string assetName, string fullPath, string extension)
        {
            if(extension != ".png") throw new Exception("Sprite must be a png file!");

            using (var temp = new Bitmap(fullPath))
            {
                var img = new Bitmap(temp);
                GraphicsPictureBox.Image = img;
            }

            _graphicsPath = fullPath;
        }
    }
}
