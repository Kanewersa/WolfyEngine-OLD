using System;
using System.Collections.Generic;
using System.IO;
using WolfyCore.Actions;
using WolfyCore.ECS;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class VariablesController : IController
    {
        private static VariablesController _instance;
        public static VariablesController Instance => _instance ??= new VariablesController();

        private string VariablesPath => PathsController.Instance.VariablesDataPath;

        public VariablesData VariablesData { get; private set; }

        public void InitializeProject()
        {
            if (empty) return;

            if (File.Exists(VariablesPath))
            {
                VariablesData = Serialization.ProtoDeserialize<VariablesData>(VariablesPath);
            }
            else
            {
                VariablesData = new VariablesData();
                CreateVariables(32);
            }
        }

        public void SaveData()
        {
            Serialization.ProtoSerialize(VariablesData, VariablesPath);
        }

        /// <summary>
        /// Creates the selected count of variables.
        /// </summary>
        /// <param name="count"></param>
        public void CreateVariables(int count)
        {
            VariablesData.CreateVariables(count);
        }

        /// <summary>
        /// Removes all variables with higher id than id given.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVariables(uint id)
        {
            VariablesData.RemoveVariables(id);
        }

        public BaseVariable GetVariable(uint id)
        {
            return VariablesData.GetVariable(id);
        }
        public void ReplaceVariable(uint id, BaseVariable variable)
        {
            VariablesData.ReplaceVariable(id, variable);
        }

        public Dictionary<uint, BaseVariable> GetVariables()
        {
            return VariablesData.GetVariables();
        }

        public WolfyVariable CreateWolfyVariable()
        {
            var variable = new WolfyVariable();
            VariablesData.AddVariable(variable);
            return variable;
        }

        public WolfyBool CreateWolfyBool()
        {
            var variable = new WolfyBool();
            VariablesData.AddVariable(variable);
            return variable;
        }
    }
}
