using System.IO;
using WolfyCore.Game;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class InventoryController
    {
        private static InventoryController _instance;
        public static InventoryController Instance => _instance ??= new InventoryController();

        public string InventoryDataPath => PathsController.Instance.InventoryDataPath;

        public InventoryData InventoryData { get; set; }

        public void InitializeProject(bool empty)
        {
            if (empty) return;

            InventoryData = File.Exists(InventoryDataPath)
                ? Serialization.ProtoDeserialize<InventoryData>(InventoryDataPath)
                : new InventoryData();
        }

        public void Save()
        {
            Serialization.ProtoSerialize(InventoryData, InventoryDataPath);
        }

        public static Inventory GetInventory(uint id)
        {
            return Instance.InventoryData.GetInventory(id);
        }
    }
}
