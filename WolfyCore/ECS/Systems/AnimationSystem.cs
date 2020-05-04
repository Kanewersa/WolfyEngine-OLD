using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;


namespace WolfyCore.ECS
{
    [ProtoContract] public class AnimationSystem : EntitySystem
    {
        [ProtoMember(1)] private readonly float _timer = 0.01f;
        
        public AnimationSystem() { }

        public override void Initialize()
        {
            RequireComponent<TransformComponent>();
            RequireComponent<AnimationComponent>();
            RequireComponent<MovementComponent>();
        }

        public override void LoadContent(ContentManager content)
        {
            foreach (var entity in Entities)
            {
                var comp = entity.GetComponent<AnimationComponent>();
                comp.AnimationManager.Initialize(comp.Animations["Walk"]);

                //comp.Animations["Walk"].Image.Initialize(graphics);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                var transform = entity.GetComponent<TransformComponent>();
                var animation = entity.GetComponent<AnimationComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var dir = movement.Direction;
                var isMoving = entity.HasComponent<MovementActionComponent>();

                SetAnimations(isMoving, animation);

                animation.AnimationManager.Update(gameTime);

                if (isMoving)
                {
                    // TODO Direction should be changeable even when entity is not moving.
                    animation.AnimationManager.SetDirection(dir);
                    animation.Position = transform.Transform;
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
