using System;
using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class EntityMap
    {
        [ProtoMap(DisableMap = true)]
        [ProtoMember(1)] public Dictionary<Entity, int> Map { get; set; }
        [ProtoMap(DisableMap = true)]
        [ProtoMember(2)] public Dictionary<int, Entity> ReversedMap { get; set; }
        [ProtoMember(3)] public int Size { get; private set; }
        [ProtoIgnore] private EntityComponent[] _components;
        [ProtoMember(4, OverwriteList = true)]
        public EntityComponent[] Components
        {
            get => _components;
            set => _components = value;
        }

        public EntityMap(int size = 0)
        {
            Size = size;
            Map = new Dictionary<Entity, int>(Size);
            ReversedMap = new Dictionary<int, Entity>(Size);
            Components = new EntityComponent[Size];
        }

        [ProtoAfterDeserialization]
        private void FillComponentsArray()
        {
            if (Components.Length < Size)
            {
                Array.Resize(ref _components, Size);
            }
        }
    }
}
