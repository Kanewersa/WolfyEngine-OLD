using ProtoBuf;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class InventoryComponent : EntityComponent
    {
        [ProtoMember(1)] public uint InventoryId { get; }

        public InventoryComponent() { }

        public InventoryComponent(Inventory inventory)
        {
            InventoryId = inventory.Id;
        }

        public Inventory GetInventory()
        {
            return InventoryController.GetInventory(InventoryId);
        }
    }
}
