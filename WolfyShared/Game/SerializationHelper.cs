using System.Collections.Generic;
using ProtoBuf;
using WolfyECS;

namespace WolfyShared
{
    [ProtoContract] public class SerializationHelper
    {
        [ProtoMember(1)] public List<string> ComponentNames { get; private set; }


        public void AddComponent<T>() where T : EntityComponent
        {
            ComponentNames.Add(typeof(T).AssemblyQualifiedName);
        }
    }
}
