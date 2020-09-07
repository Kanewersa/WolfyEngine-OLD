using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using ProtoBuf.Meta;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore
{
    [ProtoInclude(10, typeof(SubTypeData<EntitySystem>))]
    [ProtoInclude(11, typeof(SubTypeData<EntityComponent>))]
    [ProtoInclude(12, typeof(SubTypeData<WolfyAction>))]
    [ProtoContract] public class SubTypeData<T> where T : class
    {
        /// <summary>
        /// Wrapper around queue to allow serialization.
        /// </summary>
        [ProtoMember(1)]
        public int[] Ids
        {
            get => PendingTypes.ToArray();
            set => PendingTypes = new Queue<int>(value);
        }

        /// <summary>
        /// Stores ids that were once used by types, but are free now because the types were deleted.
        /// </summary>
        [ProtoIgnore] public Queue<int> PendingTypes = new Queue<int>();

        /// <summary>
        /// Stores the assembly names and ProtoMember int tags.
        /// </summary>
        [ProtoMember(2)] public Dictionary<string, int> Keys { get; set; }

        /// <summary>
        /// Int value of the biggest added key.
        /// </summary>
        [ProtoMember(3)] public int Counter { get; set; }

        /// <summary>
        /// Loads the types and allows their serialization.
        /// </summary>
        public void LoadTypes()
        {
            foreach (var type in ReflectiveEnumerator
                                 .GetSubTypes<T>()
                                 .ConvertAll(x => x.AssemblyQualifiedName)
                                 .Except(Keys.Keys.ToList()))
            {

                Keys.Add(type, PendingTypes.Any() ? PendingTypes.Dequeue() : Counter++);
            }

            foreach (var k in Keys)
            {
                RuntimeTypeModel.Default[typeof(T)].AddSubType(k.Value, Type.GetType(k.Key)?.UnderlyingSystemType);
            }
        }
    }
}
