using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyVariable : BaseVariable
    {
        /// <summary>
        /// Float value of the variable.
        /// </summary>
        [ProtoMember(1)] public RefFloat Value { get; set; }

        /// <summary>
        /// Actions to be executed when variable value changes.
        /// </summary>
        [ProtoMember(2)] public List<WolfyAction> OnChangeActions { get; set; }

        public WolfyVariable() { }

        public WolfyVariable(float value)
        {
            Value = value;
            OnChangeActions = new List<WolfyAction>();
        }
    }
}
