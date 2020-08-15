using System;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    [ProtoContract] public class DialogAction : WolfyAction
    {
        [ProtoMember(1)] private readonly string _content;

        public DialogAction() { }

        public DialogAction(Entity target, string content)
        {
            Asynchronous = false;
            Target = target;
            _content = content;
        }

        /// <summary>
        /// Displays the dialog on screen.
        /// </summary>
        public override void Execute()
        {
            // TODO Display UI here!
            Console.WriteLine(_content);
        }

        public override void Validate()
        {
            if (Target.GetIfHasComponent(out InputComponent input))
            {
                if (input.Enter)
                    Completed = true;
            }
        }

        public override string GetDescription()
        {
            return "Dialog: " + _content;
        }
    }
}
