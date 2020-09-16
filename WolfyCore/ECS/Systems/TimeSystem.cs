using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TimeSystem : EntitySystem
    {
        [ProtoMember(1)] public float Timer;
        [ProtoMember(2)] public InGameTime Time;

        public TimeSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<TimeEventComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Change in-game time flow
            
            // One minute in game = one second
            if (Timer < 1f) return;

            Timer = 0;

            Time = Time.AddMinute();

            IterateEntities(entity =>
            {
                var timeComponent = entity.GetComponent<TimeEventComponent>();
                if (!timeComponent.HasEvents(Time)) return;
                var startAction = new StartActionComponent(timeComponent.GetActions(Time), true);
                entity.AddComponent(startAction);
            });
        }
    }
}