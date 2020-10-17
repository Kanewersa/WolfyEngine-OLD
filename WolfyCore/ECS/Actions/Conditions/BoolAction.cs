using System;
using System.Linq;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyCore.Controllers;

namespace WolfyCore.ECS
{
    [ProtoContract] public class BoolAction : WolfyAction
    {
        [ProtoMember(1)] public uint VariableId { get; set; }
        [ProtoMember(2)] public bool NewValue { get; set; }
        [ProtoIgnore] private WolfyBool Variable => VariablesController.Instance.GetVariable(VariableId) as WolfyBool;

        public BoolAction() { }

        public BoolAction(uint targetVariableId, bool value)
        {
            VariableId = targetVariableId;
            NewValue = value;
        }

        public override void Execute()
        {
            if (Variable == null)
                throw new Exception("Variable (" + VariableId + ") is not a boolean variable.");

            if (Variable.OnChangeActions.Any())
            {
                // TODO: Execute OnChangeActions when variable value is changed.
            }

            Variable.Value = NewValue;

            Complete();
        }

        public override void Validate(GameTime gameTime)
        {
            Complete();
        }

        public override string GetDescription()
        {
            return "Change variable " + Variable.FormattedName() + " to " + NewValue;
        }
    }
}
