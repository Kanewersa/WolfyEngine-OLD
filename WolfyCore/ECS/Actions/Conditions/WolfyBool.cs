using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyBool : BaseVariable
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
