using System;
using GeonBit.UI;
using GeonBit.UI.Animators;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using Entity = WolfyECS.Entity;

namespace WolfyCore.Actions
{
    [ProtoContract] public class DialogAction : WolfyAction
    {
        [ProtoMember(1)] public string Content;
        [ProtoIgnore] private static Panel _messagePanel;
        [ProtoIgnore] private static TypeWriterAnimator _typeWriterAnimator;
        [ProtoIgnore] private static float _dialogFastForwardTimer = 10f;

        public DialogAction() { }

        public DialogAction(Entity target, string content)
        {
            Asynchronous = false;
            Target = target;
            Content = content;
        }

        /// <summary>
        /// Displays the dialog on the screen.
        /// </summary>
        public override void Execute()
        {
            _messagePanel = new Panel(new Vector2(400, 150), PanelSkin.Default, Anchor.BottomCenter);
            UserInterface.Active.AddEntity(_messagePanel);

            _messagePanel.AddChild(new Paragraph("Entity"));
            _messagePanel.AddChild(new HorizontalLine());
            var text = _messagePanel.AddChild(new Paragraph(@""));
            _typeWriterAnimator = (TypeWriterAnimator) text.AttachAnimator(new TypeWriterAnimator()
            {
                TextToType = Content
            });
            _typeWriterAnimator.SpeedFactor = 10f;
        }

        public override void Validate()
        {
            if (Target.GetIfHasComponent(out InputComponent input))
            {
                if (input.Enter)
                {
                    if (_typeWriterAnimator.IsDone)
                    {
                        Completed = true;
                        _messagePanel.RemoveFromParent();
                    }
                    else if (_dialogFastForwardTimer <= 0)
                    {
                        _typeWriterAnimator.SpeedFactor = 50f;
                    }

                }
            }

            _dialogFastForwardTimer--;
            if (_dialogFastForwardTimer < 0) _dialogFastForwardTimer = 0;
        }

        public override string GetDescription()
        {
            return "Dialog: " + Content;
        }
    }
}
