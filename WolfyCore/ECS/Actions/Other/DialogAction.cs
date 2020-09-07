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
        [ProtoMember(1)] public new string Content;

        public DialogAction() { }

        public DialogAction(Entity target, string content)
        {
            Asynchronous = false;
            Target = target;
            Content = content;
        }

        /// <summary>
        /// Adds <see cref="DialogComponent"/> to Entity.
        /// </summary>
        public override void Execute()
        {
            Target.AddComponent(new DialogComponent("Entity", Content));
        }

        public override void Validate(GameTime gameTime)
        {
            if (Entity.Player.HasComponent<DialogComponent>())
                return;
            
            Complete();
        }

        public override string GetDescription()
        {
            return "Dialog: " + Content;
        }
    }
}
