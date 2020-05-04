using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class InputComponent : EntityComponent
    {
        [ProtoMember(1)] public bool ArrowUp { get; set; }
        [ProtoMember(2)] public bool ArrowDown { get; set; }
        [ProtoMember(3)] public bool ArrowLeft { get; set; }
        [ProtoMember(4)] public bool ArrowRight { get; set; }
        [ProtoMember(5)] public bool LeftShift { get; set; }

        public InputComponent() { }
    }
}
