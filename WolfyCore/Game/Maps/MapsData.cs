using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace WolfyCore.Game
{
    [ProtoContract] public class MapsData
    {
        /// <summary>
        /// Stores MapInfo values by integer keys
        /// </summary>
        [ProtoMember(1)] public Dictionary<int, MapInfo> Info { get; set; } = new Dictionary<int, MapInfo>();
        /// <summary>
        /// Wrapper around queue to allow PendingInts serialization
        /// </summary>
        [ProtoMember(2)] public int[] Ids
        {
            get => PendingIds.ToArray();
            set => PendingIds = new Queue<int>(value);
        }
        /// <summary>
        /// Stores ids that were once used by maps, but are free now because the maps were deleted.
        /// </summary>
        [ProtoIgnore] public Queue<int> PendingIds = new Queue<int>();


        public MapsData() {}

        /// <summary>
        /// Returns the next free id for new map
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            return PendingIds.Any() ? PendingIds.Dequeue() : Info.Count;
        }
    }
}
