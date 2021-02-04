using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class GameController : IController
    {
        private static GameController _instance;
        public static GameController Instance => _instance ??= new GameController();

        public World World { get; set; }
        public GameSettings Settings { get; set; }

        private string GameSettingsPath => PathsController.Instance.GameSettingsPath;
        private string WorldPath => PathsController.Instance.WorldPath;

        public GameController()
        { }

        /// <summary>
        /// Loads the game world and settings for current project
        /// </summary>
        public void InitializeProject()
        {
            Settings = File.Exists(GameSettingsPath)
                ? Serialization.ProtoDeserialize<GameSettings>(GameSettingsPath)
                : new GameSettings();
                
            World = File.Exists(WorldPath)
                ? Serialization.ProtoDeserialize<World>(WorldPath)
                : CreateNewWorld();

            World.SetWorld(World);

            var presentSystems = World.GetSystems().ConvertAll(x => x.GetType());
            foreach (var newSystem in ReflectiveEnumerator.GetSubTypes<EntitySystem>().Except(presentSystems))
            {
                var system = (EntitySystem)Activator.CreateInstance(newSystem);
                World.AddSystem(system);
                system.Initialize(null);
            }

            World.Initialize(null);
        }

        public int GetEntitiesCount()
        {
            return (int) World.WorldInstance.EntityCount();
        }

        public ComponentMask GetMask(Entity entity)
        {
            return World.WorldInstance.GetMask(entity);
        }

        private World CreateNewWorld()
        {
            var world = new World();
            World.SetWorld(world);
            CreateSystems(world);
            CreatePlayer(world);
            CreateLUTTime(world);
            return world;
        }

        private void CreateSystems(World world)
        {
            foreach (var type in ReflectiveEnumerator.GetSubTypes<EntitySystem>())
            {
                var system = (EntitySystem)Activator.CreateInstance(type);
                world.AddSystem(system);
                system.Initialize(null);
            }
        }

        private Entity CreatePlayer(World world)
        {
            var player = world.CreateEntity();

            var name = player.AddComponent<InGameNameComponent>();
            name.Name = "Player";

            var movement = player.AddComponent<MovementComponent>();
            movement.Speed = 5;

            var input = player.AddComponent<InputComponent>();

            var camera = player.AddComponent<CameraComponent>();

            var transform = player.AddComponent<TransformComponent>();
            transform.CurrentMap = 0;
            transform.GridTransform = Vector2.Zero;
            transform.Transform = Vector2.Zero;

            player.GetMask();

            var animation = player.AddComponent<AnimationComponent>();
            var animations = new Dictionary<string, Animation>()
            {
                { "Walk", new Animation("001-Fighter01", 4, 4) }
            };
            animation.Animations = animations;
            animation.AnimationManager = new AnimationManager(animations.FirstOrDefault().Value);

            return player;
        }

        private Entity CreateLUTTime(World world)
        {
            var time = world.CreateEntity();
            var name = time.AddComponent<InGameNameComponent>();
            name.Name = "LUTTime";

            time.AddComponent<ActiveComponent>();
            return time;
        }

        public void SaveData()
        {
            Serialization.ProtoSerialize(Settings, GameSettingsPath);
            Serialization.ProtoSerialize(World.WorldInstance, WorldPath);
        }
    }
}
