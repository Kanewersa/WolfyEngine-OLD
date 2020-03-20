using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WolfyShared.Engine
{
    public class Sprite
    {
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;
        protected Image _image;
        private Texture2D Texture => _image.Texture;

        public Input Input;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;

        public Sprite(Dictionary<string, Animation> animations)
        {
            _image = new Image();
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
                spriteBatch.Draw(Texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("");
        }

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown((Input.Up)))
                Velocity.Y -= Speed;
            if (Keyboard.GetState().IsKeyDown((Input.Down)))
                Velocity.Y = Speed;
            if (Keyboard.GetState().IsKeyDown((Input.Left)))
                Velocity.X -= Speed;
            if (Keyboard.GetState().IsKeyDown((Input.Right)))
                Velocity.X = Speed;
        }

        protected virtual void SetAnimations()
        {
            if(Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if(Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if(Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            SetAnimations();

            _animationManager.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;

            Console.WriteLine(1 / (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
