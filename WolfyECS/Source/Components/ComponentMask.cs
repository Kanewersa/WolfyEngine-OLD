namespace WolfyECS
{
    public struct ComponentMask
    {
        public int Mask { get; private set; }

        public void AddComponent<T>() where T : EntityComponent
        {
            Mask |= (1 << Family.GetComponentFamily<T>());
        }

        public void RemoveComponent<T>() where T : EntityComponent
        {
            Mask &= ~(1 << Family.GetComponentFamily<T>());
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