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
                // TODO Allow setting default animation
                comp.AnimationManager.Initialize(comp.Animations["Walk"]);
                comp.LoadContent(content);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var animation = entity.GetComponent<AnimationComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var isMoving = entity.HasComponent<MovementActionComponent>();

                SetAnimations(isMoving, animation);

                animation.AnimationManager.Update(gameTime);

                if (isMoving)
                {
                    var transform = entity.GetComponent<TransformComponent>();
                    // TODO Direction should be changeable even when entity is not moving.
                    animation.AnimationManager.SetDirection(movement.Direction);
                    animation.Position = transform.Transform;
                }
            });
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var entity in Entities)
            {
                var animation = entity.GetComponent<AnimationComponent>();
                animation.Draw(spriteBatch);
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
