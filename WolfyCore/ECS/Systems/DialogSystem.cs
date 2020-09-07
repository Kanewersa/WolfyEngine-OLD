using System;
using GeonBit.UI;
using GeonBit.UI.Animators;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;
using Entity = WolfyECS.Entity;

namespace WolfyCore.ECS
{
    [ProtoContract] public class DialogSystem : EntitySystem
    {
        private Panel DialogPanel { get; set; }
        private Paragraph HeaderParagraph { get; set; }
        private Paragraph ContentParagraph { get; set; }
        private TypeWriterAnimator Animator { get; set; }

        // TODO: Fix dialog system UI initialization.
        private bool Initialized { get; set; }
        [ProtoMember(1)] private string HeaderText { get; set; }
        [ProtoMember(2)] private string ContentText { get; set; }

        private int DialogCloseTimeout { get; set; }
        private float SpeedFactorTimeout { get; set; }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<DialogComponent>();
            ResetDialogTimeout();
        }

        public override void Update(GameTime gameTime)
        {
            if (!Initialized)
            {
                CreateDialogUI();
            }

            IterateEntities(entity =>
            {
                SpeedFactorTimeout -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (SpeedFactorTimeout <= 0)
                {
                    SpeedFactorTimeout = 0;
                }
                var dialog = entity.GetComponent<DialogComponent>();
                if (dialog.Displayed) return;
                dialog.Displayed = true;

                // Display the dialog panel if it is not present.
                if (DialogPanel.Parent == null)
                    UserInterface.Active.AddEntity(DialogPanel);

                // Reset dialog timeout to prevent DialogPanel removal.
                ResetDialogTimeout();
                SpeedFactorTimeout = .15f;

                // Set the dialog content.
                HeaderParagraph.Text = HeaderText = dialog.NpcName;
                Animator.TextToType = ContentText = dialog.Content;
                Animator.SpeedFactor = 10f;
            });

            // If dialog panel is displayed and player clicked enter.
            if (DialogPanel.Parent != null
                && Entity.Player.GetIfHasComponent(out InputComponent input)
                && input.Enter)
            {
                // If Animator completed the animation
                if (Animator.IsDone)
                {
                    // Remove the dialog component.
                    Entity.Player.RemoveComponent<DialogComponent>();
                }
                else
                {
                    // Speed up the animator.
                    if (SpeedFactorTimeout <= 0)
                    {
                        Animator.SpeedFactor = 50f;
                    }
                }
            }

            if (DialogPanel.Parent != null
                && !Entity.Player.HasComponent<DialogComponent>())
            {
                DialogCloseTimeout--;
                if (DialogCloseTimeout <= 0)
                {
                    DialogPanel.RemoveFromParent();
                    HeaderParagraph.Text = "";
                    ContentParagraph.Text = "";
                    ResetDialogTimeout();
                }
            }
        }

        private void ResetDialogTimeout()
        {
            DialogCloseTimeout = 4;
        }

        private void CreateDialogUI()
        {
            DialogPanel = new Panel(new Vector2(500, 200), PanelSkin.Default, Anchor.BottomCenter);

            if (string.IsNullOrEmpty(HeaderText))
                HeaderText = "Header";
            if (string.IsNullOrEmpty(ContentText))
                ContentText = "Content";
            
            HeaderParagraph = new Paragraph(HeaderText);
            ContentParagraph = new Paragraph(ContentText);
            DialogPanel.AddChild(HeaderParagraph);
            DialogPanel.AddChild(new HorizontalLine());
            var text = DialogPanel.AddChild(ContentParagraph);
            Animator = (TypeWriterAnimator)text.AttachAnimator(new TypeWriterAnimator());
            Animator.TextToType = ContentText;
            Animator.SpeedFactor = 10f;

            Initialized = true;
        }
    }
}
