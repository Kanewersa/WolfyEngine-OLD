namespace WolfyECS
{
    public struct ComponentCounter
    {
        public static int Counter;
    }
    
    public class EntityComponent<T> : EntityComponent
    {
        private static int _familyId = -1;
        public static int Family()
        {
            if (_familyId != -1) return _familyId;
            _familyId = ComponentCounter.Counter++;
            return _familyId;
        }

        public virtual void Update()
        { }
    }

    public abstract class EntityComponent
    { }
}
