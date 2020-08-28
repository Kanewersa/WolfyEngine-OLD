using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TimeSystem : EntitySystem
    {
        [ProtoMember(1)] public int Day;
        [ProtoMember(2)] public int Hour;
        [ProtoMember(3)] public int Minute;
        [ProtoMember(4)] public float Timer;

        public TimeSystem() { }

        public override void Initialize()
        {
            // RequireComponent<TimeComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer < 1f) return;

            Timer = 0;

            Minute++;
            if (Minute == 60)
            {
                Minute = 0;
                Hour++;
                if (Hour == 24)
                {
                    Hour = 0;
                    Day++;
                }
            }

            IterateEntities(entity =>
            {
                // TODO: Handle all events associated with time routines.
            });
        }
    }
}
