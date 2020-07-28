using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class WolfyBool
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public RefBool Value { get; set; }

        public WolfyBool() { }

        public WolfyBool(string name, bool value)
        {
            Name = name;
            Value = value;
        }
    }
}
