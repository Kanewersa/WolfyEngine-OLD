using WolfyEngine.Engine;

namespace WolfyCore
{
    public class ProgramSettings
    {
        public bool FirstStart { get; set; } = true;
        public Project LastProject { get; set; } = null;

        public void Save()
        {
            Serialization.XmlSerialize(this, StaticPaths.ProgramSettings);
        }
    }
}
