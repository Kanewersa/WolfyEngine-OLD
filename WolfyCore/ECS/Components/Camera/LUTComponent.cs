using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class LUTComponent : EntityComponent
    {
        [ProtoMember(1)] public string LUTPath { get; set; }
        [ProtoMember(2)] public float TransitionTime { get; set; }

        public LUTComponent() { }

        public LUTComponent(string path, float time)
        {
            LUTPath = path;
            TransitionTime = time;
        }
    }
}
