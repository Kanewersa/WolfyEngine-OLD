﻿using System.Collections.Generic;
using ProtoBuf;

namespace WolfyECS
{
    [ProtoContract] public class IdDispenser
    {
        [ProtoIgnore] private Queue<uint> _pendingIds;
        [ProtoMember(1)]
        public uint[] Ids
        {
            get => _pendingIds.ToArray();
            set => _pendingIds = new Queue<uint>(value);
        }
        [ProtoMember(2)] private uint _lastId;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdDispenser"/> class.
        /// </summary>
        /// <param name="maxCapacity">The default capacity of Dispenser.</param>
        public IdDispenser(int maxCapacity)
        {
            _pendingIds = new Queue<uint>(maxCapacity);
        }

        public void AddId(uint id)
        {
            _pendingIds.Enqueue(id);
        }

        public uint GetId()
        {
            if (_pendingIds.Count > 0)
                return _pendingIds.Dequeue();
            _lastId++;
            return _lastId;
        }

        public uint GetLastId()
        {
            return _lastId;
        }
    }
}
