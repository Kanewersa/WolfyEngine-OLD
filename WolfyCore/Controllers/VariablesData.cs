using System;
using System.Collections.Generic;
using ProtoBuf;
using WolfyCore.ECS;
using WolfyECS;

namespace WolfyCore.Controllers
{
    /// <summary>
    /// Contains all information about the game variables.
    /// </summary>
    [ProtoContract] public class VariablesData
    {
        /// <summary>
        /// Variables stored by uint id.
        /// </summary>
        [ProtoMember(1)] private Dictionary<uint, BaseVariable> Variables { get; set; }
        
        /// <summary>
        /// Handles the ids of variables.
        /// </summary>
        [ProtoMember(2)] private IdDispenser Dispenser { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VariablesData()
        {
            Variables ??= new Dictionary<uint, BaseVariable>();

            if (Dispenser == null)
            {
                Dispenser = new IdDispenser(64);
            }
        }

        /// <summary>
        /// Creates the selected count of variables.
        /// </summary>
        /// <param name="count"></param>
        public void CreateVariables(int count)
        {
            for (var i = 0; i < count; i++)
            {
                AddVariable(new BaseVariable());
            }
        }

        /// <summary>
        /// Removes all variables with higher id than id given.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVariables(uint id)
        {
            for (var i = id+1; i <= (uint)Variables.Count; i++)
            {
                RemoveVariable(i);
            }
        }

        /// <summary>
        /// Adds the given variable and assigns it an id.
        /// </summary>
        /// <param name="variable"></param>
        public void AddVariable(BaseVariable variable)
        {
            variable.Id = Dispenser.GetId();
            variable.Name = string.Empty;
            Variables[variable.Id] = variable;
        }

        /// <summary>
        /// Returns the variable with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseVariable GetVariable(uint id)
        {
            return Variables[id];
        }

        public void ReplaceVariable(uint id, BaseVariable variable)
        {
            if (id > Variables.Count)
                throw new Exception("Given id was higher than the variables limit.");

            Variables[id] = variable;
        }

        /// <summary>
        /// Removes the variable with given id.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVariable(uint id)
        {
            Variables[id] = null;
            Dispenser.AddId(id);
        }

        /// <summary>
        /// Returns all variables.
        /// </summary>
        /// <returns></returns>
        public Dictionary<uint, BaseVariable> GetVariables()
        {
            return Variables;
        }
    }
}
