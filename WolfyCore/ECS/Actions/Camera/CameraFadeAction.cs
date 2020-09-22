using System;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    [ProtoContract] public class CameraFadeAction : WolfyAction
    {
        [ProtoMember(1)] public float FadeDuration;
        [ProtoMember(2)] public bool FadeIn;
        [ProtoMember(3)] public float Timer;

        public CameraFadeAction() { }

        public CameraFadeAction(Entity target, float fadeDuration, bool fadeIn, bool asynchronous = false)
        {
            Asynchronous = asynchronous;
            Target = target;
            FadeDuration = fadeDuration;
            FadeIn = fadeIn;
        }

        public override void Execute()
        {
            if (!Target.HasComponent<CameraComponent>())
                throw new Exception("Could not perform CameraFadeAction on target entity. Entity didn't have camera component.");

            var camera = Target.GetComponent<CameraComponent>();
            camera.FadeToBlack = FadeIn;
            camera.FadeDuration = FadeDuration;
        }

        public override void Validate(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Timer >= FadeDuration)
            {
                Complete();
                Timer = 0;
            }
        }

        public override string GetDescription()
        {
            return "Camera fade: " + (FadeIn ? "Fade In" : "Fade Out" + ", duration: " + FadeDuration + " seconds");
        }
    }
}
