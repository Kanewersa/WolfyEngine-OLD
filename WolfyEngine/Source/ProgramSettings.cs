using WolfyEngine.Engine;

namespace WolfyShared
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
