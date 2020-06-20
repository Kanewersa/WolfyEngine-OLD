using System;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public struct ComponentMask
    {
        public ComponentMask(int mask)
        {
            Mask = mask;
        }
        
        [ProtoMember(1)] public int Mask { get; set; }

        public void Debug()
        {
            Console.WriteLine(Mask);
        }

        public ComponentMask AddComponent<T>() where T : EntityComponent
        {
            var fam = Family.GetComponentFamily<T>();
            Mask |= 1 << Family.GetComponentFamily<T>();
            return this;
        }

        public ComponentMask RemoveComponent<T>() where T : EntityComponent
        {
            Mask &= ~(1 << Family.GetComponentFamily<T>());
            return this;
        }

        public bool IsNewMatch(ComponentMask oldMask, ComponentMask newMask)
        {
            return Matches(newMask) && !oldMask.Matches(newMask);
        }

        public bool IsNoLongerMatched(ComponentMask oldMask, ComponentMask newMask)
        {
            return oldMask.Matches(newMask) && !Matches(newMask);
        }

        public bool Matches(ComponentMask compareMask)
        {
            return (Mask & compareMask.Mask) == compareMask.Mask;
        }

    }
}