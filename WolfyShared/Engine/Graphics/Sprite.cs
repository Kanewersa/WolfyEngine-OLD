﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WolfyShared.Engine
{
    public class Sprite
    {
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;
        protected Image _image;
        protected int GridSize = 32;

        private Texture2D Texture => _image.Texture;

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

        public Vector2 Velocity;
        public virtual Rectangle Bounds => _image.Texture.Bounds;

        public Sprite() { }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _image = new Image();
            _animations = animations;
            //_animationManager = new AnimationManager(_animations.First().Value);
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
        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }

        public virtual void Update(GameTime gameTime)
        {
            SetAnimations();

            _animationManager.Update(gameTime);

            //Position += Velocity;
            //Velocity = Vector2.Zero;
        }
    }
}
