using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Actions
{
    [ProtoContract] public class OverlayAction : WolfyAction
    {
        [ProtoMember(1)] public Color TargetColor;
        [ProtoMember(2)] public float Time;
        [ProtoIgnore] private float _colorAmount;

        public OverlayAction() { }

        public OverlayAction(Entity target, Color targetColor, float time)
        {
            Asynchronous = false;
            Target = target;
            TargetColor = targetColor;
            Time = time;
        }

        public override void Execute()
        {
            
        }

        public override void Validate(GameTime gameTime)
        {
            var camera = Target.GetComponent<CameraComponent>();
            if (TargetColor == camera.OverlayColor)
            {
                Complete();
                return;
            }

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _colorAmount += delta/Time;

            camera.OverlayColor = Color.Lerp(camera.OverlayColor, camera.OverlayColor, _colorAmount);
        }

        public override string GetDescription()
        {
            return "Set overlay color to " + TargetColor.ToVector4();
        }
    }
}
