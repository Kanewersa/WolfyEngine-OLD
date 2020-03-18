using WolfyEngine.Engine;
using WolfyShared;

namespace WolfyEngine
{
    public class ProgramSettings
    {
        public bool FirstStart { get; set; } = true;
        public Project LastProject { get; set; } = null;

        public void Save()
        {
            Serialization.XmlSerialize(this, Globals.StaticPaths.ProgramSettings);
        }

    }
}
