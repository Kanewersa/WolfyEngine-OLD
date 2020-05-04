using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace WolfyCore.Game
{
    [ProtoContract] public class TilesetsData
    {
        /// <summary>
        /// Stores TilesetInfo values by integer keys
        /// </summary>
        [ProtoMember(1)] public Dictionary<int, TilesetInfo> Info { get; set; } = new Dictionary<int, TilesetInfo>();
        /// <summary>
        /// Wrapper around queue to allow PendingInts serialization
        /// </summary>
        [ProtoMember(2)] public int[] Ids
        {
            get => PendingIds.ToArray();
            set => PendingIds = new Queue<int>(value);
        }
        /// <summary>
        /// Stores ids that were once used by tilesets, but are free now because the tilesets were deleted.
        /// </summary>
        [ProtoIgnore] public Queue<int> PendingIds = new Queue<int>();

        public TilesetsData() {}

        /// <summary>
        /// Returns the next free id for new tileset
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            return PendingIds.Any() ? PendingIds.Dequeue() : Info.Count;
        }
    }
}
