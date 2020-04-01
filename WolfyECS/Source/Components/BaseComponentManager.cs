namespace WolfyECS
{
    public abstract class ComponentManager
    {
        public abstract int AddComponent(Entity entity, EntityComponent component);
        public abstract EntityComponent GetComponent(Entity entity);
        public abstract void DestroyComponent(Entity entity);
    }
}