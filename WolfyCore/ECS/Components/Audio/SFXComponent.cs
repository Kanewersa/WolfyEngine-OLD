using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class SFXComponent : EntityComponent
    {
        [ProtoMember(1)] public string AudioFile;
        [ProtoMember(2)] public short PlayChance;
        [ProtoMember(3)] public short PlayDelay;

        public short LastPlayed = -1;
    }
}
