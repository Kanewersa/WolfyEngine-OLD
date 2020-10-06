﻿using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Checks the condition based on <see cref="WolfyVariable"/>.
    /// </summary>
    [ProtoContract] public class VariableCondition : WolfyCondition
    {
        /// <summary>
        /// Desired comparison operator.
        /// </summary>
        [ProtoMember(1)] public int DesiredOperator { get; set; }

        /// <summary>
        /// Desired value for condition to be met.
        /// </summary>
        [ProtoMember(2)] public float DesiredValue { get; set; }

        /// <summary>
        /// Stores current value of condition.
        /// </summary>
        [ProtoMember(3)] public WolfyVariable Variable { get; set; }

        public VariableCondition() { }

        public VariableCondition(int desiredOperator, int desiredValue)
        {
            DesiredOperator = desiredOperator;
            DesiredValue = desiredValue;
        }

        public override void Execute()
        {
            // Get actions from WolfyVariable and execute them asynchronously.
            Target.AddComponent(new StartActionComponent(Variable.OnChangeActions, true));
        }

        public override void Validate(GameTime gameTime)
        {
            Complete();
        }

        public override string GetDescription()
        {
            if (DesiredOperator < 0)
                return "If " + Variable.Name + " is smaller than " + DesiredValue;

            if (DesiredOperator > 0)
                return "If " + Variable.Name + " is greater than " + DesiredValue;

            return "If " + Variable.Name + " is equal " + DesiredValue;
        }

        protected override bool IsMet()
        {
            if (DesiredOperator < 0)
                return Variable.Value < DesiredValue;
            
            if (DesiredOperator > 0)
                return Variable.Value > DesiredValue;
            
            return Variable.Value == DesiredValue;
        }
    }
}
