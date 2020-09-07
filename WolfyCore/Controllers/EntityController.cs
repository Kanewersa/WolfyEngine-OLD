using System.Collections.Generic;
using System.IO;
using WolfyECS;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class EntityController
    {
        private static EntityController _instance;
        public static EntityController Instance => _instance ??= new EntityController();

        private string EntityDataPath => PathsController.Instance.EntityDataPath;

        public EntityData EntityData { get; private set; }

        public void InitializeProject(bool empty)
        {
            if (empty) return;

            EntityData = File.Exists(EntityDataPath)
                ? Serialization.ProtoDeserialize<EntityData>(EntityDataPath)
                : new EntityData();
        }

        public static List<Entity> GetEntities(int mapId)
        {
            return Instance.EntityData.GetEntities(mapId);
        }

        /*
        public static void AddEntity(int mapId, Entity entity)
        {
            Instance.EntityData.AddEntity(mapId, entity);
        }

        public static void RemoveEntity(int mapId, Entity entity)
        {
            Instance.EntityData.RemoveEntity(mapId, entity);
        }

        public static void MoveEntity(int sourceMap, int targetMap, Entity entity)
        {
            Instance.EntityData.RemoveEntity(sourceMap, entity);
            Instance.EntityData.AddEntity(targetMap, entity);
        }*/
    }
}
