using System.Collections.Generic;
using System.IO;
using WolfyECS;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class EntityController : IController
    {
        private static EntityController _instance;
        public static EntityController Instance => _instance ??= new EntityController();

        private string EntityDataPath => PathsController.Instance.EntityDataPath;

        public EntityData EntityData { get; private set; }

        public void InitializeProject()
        {
            EntityData = File.Exists(EntityDataPath)
                ? Serialization.ProtoDeserialize<EntityData>(EntityDataPath)
                : new EntityData();
        }

        public static List<Entity> GetEntities(int mapId)
        {
            return Instance.EntityData.GetEntities(mapId);
        }

        public void SaveData()
        {
            Serialization.ProtoSerialize(EntityData, EntityDataPath);
        }
    }
}
