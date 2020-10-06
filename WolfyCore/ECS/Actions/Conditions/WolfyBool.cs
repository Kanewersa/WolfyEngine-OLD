using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyBool : BaseVariable
    {
        /// <summary>
        /// Value of the boolean.
        /// </summary>
        [ProtoMember(1)] public RefBool Value { get; set; }

        /// <summary>
        /// Actions to be executed when boolean value changes.
        /// </summary>
        [ProtoMember(2)] public List<WolfyAction> OnChangeActions { get; set; }

        public WolfyBool() { }

        public WolfyBool(bool value)
        {
            Value = value;
            OnChangeActions = new List<WolfyAction>();
        }
    }
}
