using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyVariable : BaseVariable
    {
        private List<WolfyAction> _changeActions;

        /// <summary>
        /// Float value of the variable.
        /// </summary>
        [ProtoMember(1)] public float Value { get; set; }

        /// <summary>
        /// Actions to be executed when variable value changes.
        /// </summary>
        [ProtoMember(2)]
        public List<WolfyAction> OnChangeActions
        {
            get => _changeActions ??= new List<WolfyAction>();
            set => _changeActions = value;
        }

        public WolfyVariable() { }

        public WolfyVariable(float value)
        {
            Value = value;
            OnChangeActions = new List<WolfyAction>();
        }
    }
}
