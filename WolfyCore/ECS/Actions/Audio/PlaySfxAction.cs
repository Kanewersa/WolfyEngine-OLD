using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    public class PlaySfxAction : WolfyAction
    {
        [ProtoMember(1)] public Sound Sound { get; private set; }

        public PlaySfxAction(Entity target, Sound sound)
        {
            Target = target;
            Sound = sound;
        }
        public override void Execute()
        {
            Target.AddComponent(new SFXComponent(Sound));
        }

        public override void Validate(GameTime gameTime)
        {
            if (Target.HasComponent<SFXComponent>())
            {
                Target.RemoveComponent<SFXComponent>();
                Complete();
            }
        }

        public override string GetDescription()
        {
            return "Play sound: " + Sound.GetNameWithoutPath();
        }
    }
}
