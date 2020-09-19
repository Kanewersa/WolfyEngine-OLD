using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyECS;


namespace WolfyCore.ECS
{
    [ProtoContract] public class AnimationSystem : EntitySystem
    {
        public AnimationSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
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

        public override void PostUpdate(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var animation = entity.GetComponent<AnimationComponent>();
                var isMoving = entity.HasComponent<MovementActionComponent>();

                SetAnimations(isMoving, animation);

                animation.AnimationManager.Update(gameTime);
                animation.Position = entity.GetComponent<TransformComponent>().Transform;
                animation.SetDirection(entity.GetComponent<MovementComponent>().Direction);
            });
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        private static void SetAnimations(bool isMoving, AnimationComponent component)
        {
            if (isMoving)
            {
                component.AnimationManager.Play(component.Animations["Walk"]);
                component.PreserveAnimation = true;
                return;
            }
            
            if(!component.PreserveAnimation)
            {
                component.AnimationManager.Stop();
            }

            component.PreserveAnimation = false;
        }
    }
}
