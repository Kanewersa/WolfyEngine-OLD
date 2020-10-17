using System.Linq;
using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyCore.Actions;
using WolfyCore.Controllers;

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
        /// Id of condition variable.
        /// </summary>
        [ProtoMember(2)] public uint VariableId { get; set; }

        /// <summary>
        /// Stores current value of condition.
        /// </summary>
        [ProtoIgnore] public WolfyBool Variable => (WolfyBool) VariablesController.Instance.GetVariable(VariableId);

        public BoolCondition() { }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="variableId"></param>
        /// <param name="desiredValue"></param>
        public BoolCondition(uint variableId, bool desiredValue)
        {
            VariableId = variableId;
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
            return "if " + Variable.Name + " (" + Variable.Id + ")" + " is " + DesiredValue;
        }

        public override bool IsMet()
        {
            return Variable.Value == DesiredValue;
        }
    }
}
