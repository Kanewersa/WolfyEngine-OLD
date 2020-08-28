using System;
using WolfyCore.Actions;
using WolfyECS;

namespace WolfyEngine.Forms
{
    public partial class CameraFadeActionForm : BaseActionForm
    {
        public CameraFadeActionForm()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            // Camera fade action is executed on player's camera.
            Entity = Entity.Player;
        }

        protected override WolfyAction CreateAction()
        {
            var duration = FadeDurationBox.Value;
            var fadeIn = FadeInButton.Checked;
            return new CameraFadeAction(Entity, (float)duration, fadeIn);
        }

        protected override bool ValidateAction()
        {
            return FadeInButton.Checked || FadeOutButton.Checked;
        }

        public override void LoadAction(WolfyAction action)
        {
            var fade = (CameraFadeAction) action;

            if (fade.FadeIn) FadeInButton.Checked = true;
            else FadeOutButton.Checked = true;

            FadeDurationBox.Value = (decimal)fade.FadeDuration;
        }
    }
}
