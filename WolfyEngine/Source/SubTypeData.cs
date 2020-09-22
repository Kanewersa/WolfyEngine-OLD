using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine;
using WolfyEngine.Engine;

namespace WolfyCore
{
    [ProtoInclude(100, typeof(EntitySystem))]
    [ProtoInclude(101, typeof(EntityComponent))]
    [ProtoInclude(102, typeof(WolfyAction))]
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
        /// List of the keys added during current runtime.
        /// </summary>
        [ProtoIgnore] public List<string> NewKeys { get; set; }

        /// <summary>
        /// Int value of the biggest added key.
        /// </summary>
        [ProtoMember(3)] public int Counter { get; set; }

        public SubTypeData()
        {
            PendingTypes ??= new Queue<int>();
            Keys ??= new Dictionary<string, int>();
            NewKeys ??= new List<string>();

            if (Counter < 200)
                Counter = 200;
        }

        /// <summary>
        /// Loads the types and allows their serialization.
        /// </summary>
        /// <param name="loadGenericTypes">Determines if generic types should be loaded.</param>
        public void LoadTypes(bool loadGenericTypes = false)
        {
            foreach (var type in ReflectiveEnumerator
                                 .GetSubTypes<T>()
                                 .ConvertAll(x => x.AssemblyQualifiedName)
                                 .Except(Keys.Keys.ToList()))
            {
                NewKeys.Add(type);
                Keys.Add(type, PendingTypes.Any() ? PendingTypes.Dequeue() : Counter++);
            }

            if (loadGenericTypes)
                LoadGenericTypes();

            foreach (var k in Keys)
            {
                Serialization.RuntimeTypeModel[typeof(T)].AddSubType(k.Value, Type.GetType(k.Key)?.UnderlyingSystemType);
                Console.WriteLine("ID: "+ k.Value +","+ "Loaded type: " + Type.GetType(k.Key).UnderlyingSystemType);
            }
        }

        /// <summary>
        /// Creates the generic types and allows their serialization.
        /// TODO: Generic types should be dynamic and not use EntityComponent<>.
        /// </summary>
        private void LoadGenericTypes()
        {
            foreach (var type in NewKeys)
            {
                var generic = typeof(EntityComponent<>).MakeGenericType(Type.GetType(type));
                Keys.Add(generic.AssemblyQualifiedName ?? throw new InvalidOperationException(), PendingTypes.Any() ? PendingTypes.Dequeue() : Counter++);
            }

            /*foreach (var k in Keys)
            {
                RuntimeTypeModel.Default[typeof(T)]
                    .AddSubType(k.Value, typeof(EntityComponent<>).MakeGenericType(Type.GetType(k.Key)).UnderlyingSystemType);
                Console.WriteLine("ID: " + k.Value + "," + "Loaded type: " + typeof(EntityComponent<>).MakeGenericType(Type.GetType(k.Key)).UnderlyingSystemType);
            }*/
        }
    }
}
