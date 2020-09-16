﻿using WolfyEngine.Engine;

namespace WolfyCore
{
    public class ProgramSettings
    {
        public bool SmoothForms { get; set; } = true;
        public bool FirstStart { get; set; } = true;
        public string LastProjectPath { get; set; }
        public void Save()
        {
            Serialization.XmlSerialize(this, StaticPaths.ProgramSettings);
        }
    }
}
