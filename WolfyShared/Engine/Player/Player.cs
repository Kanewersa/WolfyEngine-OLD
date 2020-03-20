using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WolfyShared.Engine;

namespace WolfyShared.Game
{
    public class Player : Sprite
    {
        public Input Input;

        public Player(Dictionary<string, Animation> animations)
        {
            _image = new Image();
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public override void Move()
        {
            base.Move();

            if (Keyboard.GetState().IsKeyDown((Input.Up)))
            {
                Velocity.Y -= Speed;
                _animationManager.SetDirection(Directions.Up);
            }
            if (Keyboard.GetState().IsKeyDown((Input.Down)))
            {
                Velocity.Y = Speed;
                _animationManager.SetDirection(Directions.Down);
            }
            if (Keyboard.GetState().IsKeyDown((Input.Left)))
            {
                Velocity.X -= Speed;
                _animationManager.SetDirection(Directions.Left);
            }
            if (Keyboard.GetState().IsKeyDown((Input.Right)))
            {
                Velocity.X = Speed;
                _animationManager.SetDirection(Directions.Right);
            }
        }

        protected override void SetAnimations()
        {
            if(Math.Abs(Velocity.X) > 0 || Math.Abs(Velocity.Y) > 0)
                _animationManager.Play(_animations["Walk"]);
            else _animationManager.Stop();
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);

            Move();
        }
    }
}
