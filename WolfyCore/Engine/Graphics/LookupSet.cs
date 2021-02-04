using System.Collections;
using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyCore.Game;

namespace WolfyCore.Engine
{
    [ProtoContract] public class LookupSet
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public Dictionary<InGameTime, string> Assets { get; private set; }
        [ProtoMember(3)] private TimeEventComponent TimeEvents { get; set; }

        public LookupSet() { }

        public LookupSet(string name)
        {
            Name = name;
            Assets = new Dictionary<InGameTime, string>();
            TimeEvents = new TimeEventComponent();
        }

        public void AddEvent(InGameTime time, ChangeLUTAction action)
        {
            TimeEvents.AddEvent(time, action);
        }

        public void RemoveEvent(InGameTime timeTHIS, int indexORTHIS)
        {

        }
    }
}