namespace WolfyECS
{
    public struct ComponentCounter
    {
        public static int Counter = 1;
    }
    
    public class EntityComponent<T> : EntityComponent
    {
        private static int _familyId = 0;
        public static int Family()
        {
            if (_familyId != 0) return _familyId;
            _familyId = ComponentCounter.Counter++;
            return _familyId;
        }

        public virtual void Update()
        { }
    }

    public abstract class EntityComponent
    { }
}
