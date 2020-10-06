﻿using System.Linq;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;

namespace WolfyCore.ECS
{
    /// <summary>
    /// Checks the condition based on <see cref="WolfyBool"/>.
    /// </summary>
    [ProtoContract] public class BoolCondition : WolfyCondition
    {
        /// <summary>
        /// Desired value for condition to be met.
        /// </summary>
        [ProtoMember(1)] public bool DesiredValue { get; set; }

        /// <summary>
        /// Stores current value of condition.
        /// </summary>
        [ProtoMember(2)] public WolfyBool Variable { get; set; }

        public BoolCondition() { }

        public BoolCondition(bool desiredValue)
        {
            DesiredValue = desiredValue;
        }

        public override void Execute()
        {
            // Get actions from WolfyBool and execute them asynchronously.
            if(Variable.OnChangeActions.Any())
                Target.AddComponent(new StartActionComponent(Variable.OnChangeActions, true));
        }

        public override void Validate(GameTime gameTime)
        {
            Complete();
        }

        public override string GetDescription()
        {
            return "if " + Variable.Name + " is " + DesiredValue;
        }

        protected override bool IsMet()
        {
            return Variable.Value == DesiredValue;
        }
    }
}
