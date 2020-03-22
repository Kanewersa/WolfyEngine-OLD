using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    public class Camera
    {
        public float Zoom { get; set; }
        public Vector2 Position { get; protected set; }
        public Vector2 Bounds { get; protected set; }
        public Rectangle VisibleArea { get; protected set; }
        public Vector2 MapBounds { get; protected set; }
        public Matrix Transform { get; protected set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        private float _currentMouseWheelValue, previousMouseWheelValue;

        public Camera()
        {
            Zoom = 1f;
        }

        public Rectangle GetVisibleArea()
        {
            /*var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Position.X, Position.Y), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));

            return new Rectangle((int)min.X, (int)min.Y, (int)max.X, (int)max.Y);*/

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

            var rect = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
            return rect;
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

        public void UpdateCamera(Viewport bounds)
        {

            var cameraMovement = Vector2.Zero;
            int moveSpeed;

            if (Zoom > .8f)
                moveSpeed = 15;
            else if (Zoom < .8f && Zoom >= .65f)
                moveSpeed = 20;
            else if (Zoom < .65f && Zoom > .5f)
                moveSpeed = 25;
            else if (Zoom <= .5f)
                moveSpeed = 30;
            else
                moveSpeed = 10;
        }

        public void FollowTarget(Sprite target)
        {
            var bounds = new Vector2(ScreenWidth / 2, ScreenHeight/ 2);

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

            if (MapBounds.X < bounds.X * 2)
                pos.X = MapBounds.X / 2;

            if (MapBounds.Y < bounds.Y * 2)
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

        public void SetMapBoundaries(Vector2 bounds)
        {
            MapBounds = bounds;
        }

        public void Update(Sprite target)
        {
            previousMouseWheelValue = _currentMouseWheelValue;
            _currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (_currentMouseWheelValue > previousMouseWheelValue)
                AdjustZoom(.05f);

            if (_currentMouseWheelValue < previousMouseWheelValue)
                AdjustZoom(-.05f);

            if (target != null)
                FollowTarget(target);
        }
    }
}
