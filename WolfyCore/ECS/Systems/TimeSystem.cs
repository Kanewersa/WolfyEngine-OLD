using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TimeSystem : EntitySystem
    {
        private static TimeSystem Instance;
        public static InGameTime GameTime { get; private set; }

        [ProtoMember(1)] public float Timer;
        [ProtoMember(2)] public InGameTime Time;

        public TimeSystem() { }

        public override void Initialize(GraphicsDevice graphics)
        {
            Instance = this;

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
            GameTime = Time;

            IterateEntities(entity =>
            {
                var timeComponent = entity.GetComponent<TimeEventComponent>();
                if (!timeComponent.HasEvents(Time)) return;
                var startAction = new StartActionComponent(timeComponent.GetActions(Time), true);
                entity.AddComponent(startAction);
            });
        }

        public static void SetTime(InGameTime time)
        {
            GameTime = time;
            Instance.Time = time;
            Instance.Timer = 0;
            // TODO: Do all operations to npc after changing game-time
        }
    }
}