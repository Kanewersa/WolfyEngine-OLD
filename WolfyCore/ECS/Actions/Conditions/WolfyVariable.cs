using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyVariable : BaseVariable
    {
        [ProtoMember(1)] public RefFloat Value { get; set; }

        public WolfyVariable() { }

        public WolfyVariable(float value)
        {
            Value = value;
        }
    }
}
