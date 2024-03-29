﻿using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Stores the information about entity location.
    /// </summary>
    [ProtoContract] public class TransformComponent : EntityComponent
    {
        /// <summary>
        /// Current entity transform.
        /// </summary>
        [ProtoMember(1)] public Vector2 Transform { get; set; }

        /// <summary>
        /// Transform of the entity on a grid.
        /// </summary>
        [ProtoMember(2)] public Vector2 GridTransform { get; set; }

        /// <summary>
        /// Index of the map entity is on.
        /// </summary>
        [ProtoMember(3)] public int CurrentMap { get; set; }

        public TransformComponent() { }

        /// <summary>
        /// Returns the instance of current map.
        /// </summary>
        /// <returns></returns>
        public Map GetMap()
        {
            return MapsController.Instance.GetMap(CurrentMap);
        }
    }
}