using System.Collections.Generic;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.Controllers
{
    [ProtoContract]
    public class EntityData
    {
        /// <summary>
        /// Stores Entities by map.
        /// </summary>
        [ProtoMember(1)] public Dictionary<int, List<Entity>> Info { get; set; }

        public EntityData()
        {
            Info ??= new Dictionary<int, List<Entity>>();
        }

        /// <summary>
        /// Returns the entities located on map with given id.
        /// </summary>
        /// <param name="id">Map id.</param>
        /// <returns></returns>
        public List<Entity> GetEntities(int id)
        {
            if (!Info.ContainsKey(id))
                Info.Add(id, new List<Entity>());
            
            return Info[id];
        }

        /// <summary>
        /// Adds the entity to list.
        /// </summary>
        /// <param name="id">Id of the map.</param>
        /// <param name="entity">Entity to be added.</param>
        public void AddEntity(int id, Entity entity)
        {
            Info[id].Add(entity);
        }

        /// <summary>
        /// Removes the entity from list.
        /// </summary>
        /// <param name="id">Id of the map.</param>
        /// <param name="entity">Entity to be removed.</param>
        public void RemoveEntity(int id, Entity entity)
        {
            Info[id].Remove(entity);
        }
    }
}
