using ProtoBuf;
using WolfyCore.Engine;

namespace WolfyCore.ECS
{
    [ProtoContract] public class WolfyVariable
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public RefFloat Value { get; set; }

        public WolfyVariable() { }

        public WolfyVariable(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}
