using System.Collections.Generic;
using ProtoBuf;

namespace WolfyCore.Game
{
    [ProtoContract] public class Inventory
    {
        [ProtoMember(1)] public uint Id { get; set; }
        [ProtoMember(2)] public Dictionary<GameItem, int> Items { get; private set; }

        public Inventory(uint id)
        {
            Id = id;
        }

        public void AddItem(GameItem item)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += 1;
            }
            else
            {
                Items[item] = 1;
            }
        }

        public void RemoveItem(GameItem item)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] -= 1;
                if (Items[item] == 0)
                    Items.Remove(item);
            }
        }

        public bool HasItem(GameItem item)
        {
            return Items.ContainsKey(item);
        }
    }
}
