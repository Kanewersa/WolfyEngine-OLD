namespace WolfyECS
{
    public abstract class EntityComponent
    {
        public uint EntityId;

        public virtual void Update()
        { }
    }
}
