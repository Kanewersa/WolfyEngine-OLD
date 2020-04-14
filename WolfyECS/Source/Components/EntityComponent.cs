using ProtoBuf;
using ProtoBuf.Meta;

namespace WolfyECS
{
    public struct ComponentCounter
    {
        public static int Counter = 1;
    }
    
    [ProtoContract] public class EntityComponent<T> : EntityComponent where T : EntityComponent
    {
        [ProtoIgnore] private static int _familyId = 0;
        public static int Family()
        {
            if (_familyId != 0) return _familyId;
            _familyId = ComponentCounter.Counter++;
            return _familyId;
        }

        public virtual void Update()
        { }
    }
    [ProtoContract] public class EntityComponent
    { }
}
