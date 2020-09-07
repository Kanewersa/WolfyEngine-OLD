using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using ProtoBuf;
using ProtoBuf.Meta;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore
{
    [ProtoContract] public class SerializationData
    {
        [ProtoMember(1)] private SubTypeData<EntitySystem> SystemsData { get; set; }
        [ProtoMember(2)] private SubTypeData<EntityComponent> ComponentsData { get; set; }
        [ProtoMember(3)] private SubTypeData<WolfyAction> ActionsData { get; set; }

        public SerializationData()
        { }

        public void Initialize()
        {
            RuntimeTypeModel.Create().MakeDefault();
           
            SystemsData ??= new SubTypeData<EntitySystem>();
            ComponentsData ??= new SubTypeData<EntityComponent>();
            ActionsData ??= new SubTypeData<WolfyAction>();

            LoadDefaults();
            LoadSubTypes();
        }

        private static void LoadDefaults()
        {
            RuntimeTypeModel.Default.Add<Vector2>(false).Add(1, "X").Add(2, "Y");
        }

        private void LoadSubTypes()
        {
            SystemsData.LoadTypes();
            ComponentsData.LoadTypes();
            ActionsData.LoadTypes();
        }
    }
}