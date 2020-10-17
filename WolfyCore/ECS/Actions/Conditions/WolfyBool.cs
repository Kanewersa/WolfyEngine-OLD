using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyCore.Engine;

namespace WolfyCore.Actions
{
    [ProtoContract] public class WolfyBool : BaseVariable
    {
        private List<WolfyAction> _changeActions;

        /// <summary>
        /// Value of the boolean.
        /// </summary>
        [ProtoMember(1)] public RefBool Value { get; set; }

        /// <summary>
        /// Actions to be executed when boolean value changes.
        /// </summary>
        [ProtoMember(2)]
        public List<WolfyAction> OnChangeActions
        {
            get => _changeActions ??= new List<WolfyAction>();
            set => _changeActions = value;
        }

        public WolfyBool() { }

        public WolfyBool(bool value)
        {
            Value = value;
            OnChangeActions = new List<WolfyAction>();
        }
    }
}
