using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyECS;

namespace WolfyCore.Game
{
    [ProtoContract] public class EntityLayer : BaseLayer
    {
        [ProtoIgnore] private List<EntityTileRow> Rows { get; set; }
        [ProtoIgnore] private List<Entity> Entities { get; set; }

        public EntityLayer() { }

        public EntityLayer(string name, Vector2D mapSize)
        {
            Name = name;
            Rows = new List<EntityTileRow>(mapSize.Y);
            Size = mapSize;
            Entities = new List<Entity>();
            for (var i = 0; i < mapSize.Y; i++)
            {
                Rows.Add(new EntityTileRow(mapSize.X));
            }
        }

        public override void LoadContent(ContentManager content)
        {
            Entities.ForEach(entity =>
            {
                if (entity.GetIfHasComponent(out AnimationComponent animation))
                {
                    animation.LoadContent(content);
                }
            });
        }

        public void ActivateEntities()
        {
            Entities.ForEach(entity =>
            {
                entity.GetOrCreateComponent<ActiveComponent>();
            });
        }

        public void LoadEntities(List<Entity> entities)
        {
            Entities = entities;
        }

        public override void Initialize(GraphicsDevice graphics)
        {
            Entities ??= new List<Entity>();

            Rows = new List<EntityTileRow>(Size.Y);
            for (var i = 0; i < Size.Y; i++)
            {
                Rows.Add(new EntityTileRow(Size.X));
            }

            foreach (var entity in Entities)
            {
                var transform = entity.GetComponent<TransformComponent>().GridTransform;
                if (!InBounds(transform))
                    continue;
                Rows[(int)transform.Y].Tiles[(int)transform.X].Entity = entity;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle visibleArea)
        {
            /*for (int y = visibleArea.Y; y < visibleArea.Height; y++)
            {
                for (int x = visibleArea.X; x < visibleArea.Width; x++)
                {
                    var entity = GetEntity(x, y);
                    if (entity == Entity.Empty)
                        continue;

                    if (entity.GetIfHasComponent(out AnimationComponent animation)
                        && animation.Initialized)
                        animation.Draw(spriteBatch);
                }
            }*/

            visibleArea = new Rectangle(visibleArea.X - 2,
                                        visibleArea.Y - 2,
                                        visibleArea.Width + 2,
                                        visibleArea.Height + 2);

            foreach (var entity in Entities)
            {
                var transformComponent = entity.GetComponent<TransformComponent>();
                var transform = transformComponent.GridTransform;

                if (InBounds(transform, visibleArea))
                {
                    if (entity.GetIfHasComponent(out AnimationComponent animation))
                    {
                        if (animation.Initialized)
                        {
                            animation.Draw(spriteBatch);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Unloads all entities.
        /// </summary>
        public override void Unload()
        {
            Entities.ForEach(entity =>
            {
                if (entity.GetIfHasComponent(out AnimationComponent animation))
                {
                    animation.Unload();
                }
                entity.RemoveComponent<ActiveComponent>();
            });
        }

        /// <summary>
        /// Checks if tile on given position contains an Entity.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override bool? TileOccupied(Vector2 position)
        {
            return Rows[(int) position.Y].Tiles[(int) position.X].Entity != Entity.Empty ? (bool?) null : false;
        }

        /// <summary>
        /// Adds the entity and sets its position on the grid.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="position"></param>
        public void AddEntity(Entity e, Vector2 position)
        {
            Entities.Add(e);

            if (!InBounds(position))
                return;
            
            Rows[(int) position.Y].Tiles[(int) position.X].Entity = e;
        }

        /// <summary>
        /// Returns the entity at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Entity GetEntity(Vector2 position)
        {
            if (!InBounds(position))
                return Entity.Empty;
            
            return Rows[(int) position.Y].Tiles[(int) position.X].Entity;
        }

        /// <summary>
        /// Gets the entity at given coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Entity GetEntity(int x, int y)
        {
            return Rows[y].Tiles[x].Entity;
        }

        /// <summary>
        /// Sets the entity at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="e"></param>
        public void SetEntity(Vector2 position, Entity e)
        {
            Rows[(int) position.Y].Tiles[(int) position.X].Entity = e;
        }

        /// <summary>
        /// Removes the entity located at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Entity RemoveEntity(Vector2 position)
        {
            Entity entity = GetEntity(position);
            Entities.Remove(entity);
            SetEntity(position, Entity.Empty);

            return entity;
        }

        /// <summary>
        /// Removes the entity from entities list.
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        /// <summary>
        /// Checks if given vector is in layer's bounds.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool InBounds(Vector2 position)
        {
            var (x, y) = position;
            return !(x < 0) && !(y < 0) && !(x >= Size.X) && !(y >= Size.Y);
        }

        /// <summary>
        /// Checks if given vector is in given bounds.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public bool InBounds(Vector2 position, Rectangle bounds)
        {
            var (x, y) = position;
            return x >= bounds.X
                   && y >= bounds.Y
                   && x <= bounds.Width
                   && y <= bounds.Height;
        }
    }
}
