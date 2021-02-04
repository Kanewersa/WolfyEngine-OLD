using System.Collections.Generic;
using System.IO;
using WolfyCore.Engine;
using WolfyEngine.Engine;

namespace WolfyCore.Controllers
{
    public class LookupTablesController : IController
    {
        private static LookupTablesController _instance;
        public static LookupTablesController Instance => _instance ??= new LookupTablesController();
        public List<LookupSet> Data { get; private set; }
        private string LookupDataPath => PathsController.Instance.LookupDataPath;

        public void InitializeProject()
        {
            // Load lookup sets from file
            Data = File.Exists(LookupDataPath)
                ? Serialization.ProtoDeserialize<List<LookupSet>>(LookupDataPath)
                : new List<LookupSet>();
        }

        public void SaveData()
        {
            // Save lookup sets to file
            Serialization.ProtoSerialize(Data, LookupDataPath);
        }
    }
}
