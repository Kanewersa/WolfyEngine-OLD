using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using ProtoBuf;
using ProtoBuf.Meta;
using WolfyCore.Actions;
using WolfyECS;
using WolfyEngine.Engine;

namespace WolfyCore
{
    [ProtoContract] public class SerializationData
    {
        [ProtoMember(1)] public SubTypeData<EntitySystem> SystemsData { get; set; }
        [ProtoMember(2)] public SubTypeData<EntityComponent> ComponentsData { get; set; }
        [ProtoMember(3)] public SubTypeData<WolfyAction> ActionsData { get; set; }

        public SerializationData()
        { }

        public void Initialize()
        {
            Serialization.RuntimeTypeModel = RuntimeTypeModel.Create();

            SystemsData ??= new SubTypeData<EntitySystem>();
            ComponentsData ??= new SubTypeData<EntityComponent>();
            ActionsData ??= new SubTypeData<WolfyAction>();

            LoadDefaults();
            LoadSubTypes();
        }

        private static void LoadDefaults()
        {
            Serialization.RuntimeTypeModel.Add(typeof(Vector2), false).Add(1, "X").Add(2, "Y");
        }

        private void LoadSubTypes()
        {
            SystemsData.LoadTypes();
            ComponentsData.LoadTypes();
            ActionsData.LoadTypes();
        }
    }
}