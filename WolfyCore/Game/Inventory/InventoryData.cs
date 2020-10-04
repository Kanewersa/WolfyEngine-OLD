using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Game;
using WolfyECS;

namespace WolfyCore.Controllers
{
    [ProtoContract] public class InventoryData
    {
        [ProtoMember(1)] public Dictionary<uint, Inventory> Inventories { get; private set; }
        [ProtoMember(2)] public IdDispenser IdDispenser { get; private set; }

        public InventoryData()
        {
            Inventories ??= new Dictionary<uint, Inventory>();
            IdDispenser ??= new IdDispenser(64);
        }

        public Inventory CreateInventory()
        {
            var id = IdDispenser.GetId();
            return Inventories[id] = new Inventory(id);
        }

        public Inventory GetInventory(uint id)
        {
            return Inventories[id];
        }

        public Inventory RemoveInventory(uint id)
        {
            var inventory = Inventories[id];
            Inventories.Remove(id);
            IdDispenser.AddId(id);
            return inventory;
        }
    }
}
