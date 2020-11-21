using ProtoBuf;
using WolfyCore.ECS;

namespace WolfyCore.Engine
{
    [ProtoContract] public class LookupSet
    {
        public TimeEventComponent TimeEvents;

        [ProtoMember(1)] public string AssetPath { get; private set; }


        public LookupSet() { }

        public LookupSet(string asset)
        {
            AssetPath = asset;
            TimeEvents = new TimeEventComponent();
        }
    }
}
