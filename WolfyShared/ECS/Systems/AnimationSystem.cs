using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WolfyECS;


namespace WolfyShared.ECS
{
    public class AnimationSystem : EntitySystem
    {
        private readonly float _timer = 0.01f;

        public override void Initialize()
        {
            RequireComponent<MovementComponent>();
            RequireComponent<AnimationComponent>();
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var movement = entity.GetComponent<MovementComponent>();
                var animation = entity.GetComponent<AnimationComponent>();

                var wasMoving = movement.WasMoving;

                SetAnimations(wasMoving, animation);

                animation.AnimationManager.Update(gameTime);

                animation.EndPosition = movement.Transform;

                if (wasMoving)
                {
                    animation.AnimationManager.SetDirection(movement.EnumDirection);
                    animation.Position += movement.NormalizedDirection * movement.Speed * _timer;
                    if (Vector2.Distance(animation.StartPosition, animation.Position) >= 32)
                    {
                        animation.Position = animation.EndPosition;
                        animation.StartPosition = animation.EndPosition;
                        movement.WasMoving = false;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var entity in Entities)
            {
                var animation = entity.GetComponent<AnimationComponent>();

                if (animation.Image != null && animation.Texture != null)
                    spriteBatch.Draw(animation.Texture, animation.Position, Color.White);
                else if(animation.AnimationManager != null)
                    animation.AnimationManager.Draw(spriteBatch);
                else throw new Exception("");
            }
            
        }

        private void SetAnimations(bool isMoving, AnimationComponent component)
        {
            if(isMoving)
                component.AnimationManager.Play(component.Animations["Walk"]);
            else
                component.AnimationManager.Stop();
        }
    }
}
