using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class CameraComponent : EntityComponent
    {
        [ProtoMember(1)] public float Zoom { get; set; }
        [ProtoMember(2)] public Vector2 Position { get; protected set; }
        [ProtoMember(3)] public Vector2 Bounds { get; protected set; }
        [ProtoMember(4)] public Vector2D MapBounds { get; protected set; }
        [ProtoMember(5)] public Matrix Transform { get; protected set; }
        [ProtoMember(6)] public bool FadeToBlack { get; set; }
        [ProtoMember(7)] public float FadeDuration { get; set; }
        [ProtoIgnore] public int ScreenWidth => Runtime.GameScreenWidth;
        [ProtoIgnore] public int ScreenHeight => Runtime.GameScreenHeight;

        [ProtoIgnore] private float _currentMouseWheelValue;
        [ProtoIgnore] private float _previousMouseWheelValue;

        public CameraComponent()
        {
            Zoom = 1f;
        }

        public Rectangle GetVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);
            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(Bounds, inverseViewMatrix);
            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));

            if (MapBounds.X < Bounds.X / Zoom)
            {
                min.X = 0;
                max.X = MapBounds.X;
            }

            if (MapBounds.Y < Bounds.Y / Zoom)
            {
                min.Y = 0;
                max.Y = MapBounds.Y;
            }

            return new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;

            // Set zoom bounds
            if (Zoom < .5f)
                Zoom = .5f;
            if (Zoom > 2f)
                Zoom = 2;
        }

        public void FollowTarget(AnimationComponent target)
        {
            var bounds = new Vector2(ScreenWidth / 2, ScreenHeight / 2);

            var pos = new Vector2(
                target.Position.X + target.Bounds.Width / 2,
                target.Position.Y + target.Bounds.Height / 2);

            // If position is outside the map don't translate the camera

            if (pos.X - bounds.X / Zoom < 0)
                pos.X = bounds.X / Zoom;

            if (pos.X + bounds.X / Zoom > MapBounds.X)
                pos.X = MapBounds.X - bounds.X / Zoom;

            if (pos.Y - bounds.Y / Zoom < 0)
                pos.Y = bounds.Y / Zoom;

            if (pos.Y + bounds.Y / Zoom > MapBounds.Y)
                pos.Y = MapBounds.Y - bounds.Y / Zoom;

            // If map is smaller then screen
            // then map should be centered on the screen

            if (MapBounds.X < bounds.X / Zoom * 2)
                pos.X = MapBounds.X / 2;

            if (MapBounds.Y < bounds.Y / Zoom * 2)
                pos.Y = MapBounds.Y / 2;

            var position = Matrix.CreateTranslation(
                -pos.X,
                -pos.Y,
                0);

            var screenOffset = Matrix.CreateTranslation(
                bounds.X,
                bounds.Y,
                0);

            var zoom = Matrix.CreateScale(Zoom);

            Transform = position * zoom * screenOffset;
            Position = pos;
            Bounds = bounds * 2;
        }

        public void SetMapBoundaries(Vector2D bounds)
        {
            MapBounds = bounds;
        }

        public void Update(AnimationComponent target)
        {
            Update();

            if (target == null)
                throw new Exception("Could not find camera target!");

            FollowTarget(target);
        }

        public void Update()
        {
            _previousMouseWheelValue = _currentMouseWheelValue;
            _currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (_currentMouseWheelValue > _previousMouseWheelValue)
                AdjustZoom(.05f);

            if (_currentMouseWheelValue < _previousMouseWheelValue)
                AdjustZoom(-.05f);
        }
    }
}
