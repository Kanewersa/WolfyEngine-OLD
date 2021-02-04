using System;
using System.IO;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    /// <summary>
    /// Changes the lookup table.
    /// </summary>
    [ProtoContract] public class ChangeLUTAction : WolfyAction
    {
        [ProtoMember(1)] public string LUTPath;
        [ProtoMember(2)] public float TransitionTime;


        public ChangeLUTAction() { }

        public ChangeLUTAction(Entity target, string path, float transitionTime)
        {
            Asynchronous = false;
            Target = target;
            LUTPath = path;
            TransitionTime = transitionTime;
        }

        public override void Execute()
        {
            if (Target.HasComponent<LUTComponent>())
            {
                throw new Exception("Target entity already had LUTComponent.");
            }

            Target.AddComponent(new LUTComponent(LUTPath, TransitionTime));
        }

        public override void Validate(GameTime gameTime)
        {
            if (!Target.HasComponent<LUTComponent>())
            {
                Complete();
            }
        }

        public override string GetDescription()
        {
            return "Set LUT to " + Path.GetFileName(LUTPath);
        }
    }
}
