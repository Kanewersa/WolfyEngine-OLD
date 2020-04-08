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
        [ProtoMember(1)] private static int _familyId = 0;
        public static int Family()
        {
            if (_familyId != 0) return _familyId;
            _familyId = ComponentCounter.Counter++;

            // Add component subtype to protobuf
            RuntimeTypeModel.Default[typeof(EntityComponent)]
                .AddSubType(_familyId * 100, typeof(T));

            return _familyId;
        }

        public virtual void Update()
        { }
    }

    [ProtoContract] public class EntityComponent
    { }
}
