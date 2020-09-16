using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class EntityManager
    {
        [ProtoIgnore] private World World => World.WorldInstance;
        [ProtoIgnore] public uint EntityCount => _dispenser.GetLastId();
        [ProtoMember(1)] private IdDispenser _dispenser;
        [ProtoMember(2)] private int _worldId;

        public EntityManager () { }

        public EntityManager(int worldId)
        {
            _worldId = worldId;
            _dispenser = new IdDispenser(64);
        }

        public Entity CreateEntity()
        {
            return new Entity((ushort)_dispenser.GetId());
        }

        public Entity CreateEntity(World world)
        {
            return new Entity((ushort)_dispenser.GetId());
        }

        public void DestroyEntity(Entity entity)
        {
            _dispenser.AddId(entity.Id);
        }
    }
}
