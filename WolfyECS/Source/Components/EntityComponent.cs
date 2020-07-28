using System;
using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    public struct ComponentCounter
    {
        public static int Counter = 1;
        public static bool[] UsedIds = new bool[128];
        //public static Dictionary<int, Type> ComponentTypes = new Dictionary<int, Type>(256);
    }

    [ProtoContract] public class EntityComponent<T> : EntityComponent
    {
        [ProtoIgnore] private static int _familyId = 0;
        public static int Family()
        {
            if (_familyId != 0) return _familyId;

            _familyId = ComponentCounter.Counter++;
            while (ComponentCounter.UsedIds[_familyId])
            {
                _familyId = ComponentCounter.Counter++;
            }

            return _familyId;
        }

        public override void SetFamily(int family)
        {
            if(_familyId != 0) return;
            ComponentCounter.UsedIds[family] = true;

            _familyId = family;
        }

        public virtual void Update()
        { }
    }

    // TODO EntityComponent should be abstract but protobuf throws exception that EntityComponent is being instantiated.
    [ProtoContract]
    public class EntityComponent
    {
        public EntityComponent() { }
        public virtual void SetFamily(int family)
        {

        }
    }
}
