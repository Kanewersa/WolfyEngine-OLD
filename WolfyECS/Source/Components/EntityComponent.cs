using System;
using ProtoBuf;
using ProtoBuf.Meta;

namespace WolfyECS
{
    public struct ComponentCounter
    {
        public static int Counter = 1;
    }
    
    [ProtoContract] public class EntityComponent<T> : EntityComponent
    {
        [ProtoIgnore] private static int _familyId = 0;
        public static int Family()
        {
            if (_familyId != 0) return _familyId;
            _familyId = ComponentCounter.Counter++;
            return _familyId;
        }

        public static void SetFamily(int family)
        {
            if(_familyId != 0) throw new Exception("Family was already assigned.");
            _familyId = family;
        }

        public virtual void Update()
        { }
    }

    [ProtoContract]
    public class EntityComponent
    { }
}
