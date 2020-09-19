using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class PathfindingSystem : EntitySystem
    {
        public override void Initialize(GraphicsDevice graphics)
        {
            RequireComponent<ActiveComponent>();
            RequireComponent<PathRequestComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            IterateEntities(entity =>
            {
                var i = entity.GetComponent<PathRequestComponent>();

                var path = WolfyStar.GetPath(
                    i.Start,
                    i.End,
                    MapsController.Instance.GetMap(i.StartingMap));

                entity.AddComponent<PathMovementComponent>().MovementPath = path;

                entity.RemoveComponent<PathRequestComponent>();
            });
        }
    }
}
