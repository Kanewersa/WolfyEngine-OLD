using System;
using ProtoBuf;
using WolfyEngine.Engine;
using WolfyShared.Engine;

namespace WolfyShared
{
    public delegate void ProjectEventHandler(Project project);

    [ProtoContract] public class Project
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public string Path { get; set; }
        [ProtoMember(3)] public Vector2D TileSize { get; set; }
        [ProtoMember(4)] public DateTime LastModified { get; set; }

        public Project() { }
        public Project(string name, string path, Vector2D tileSize)
        {
            Name = name;
            Path = path;
            TileSize = tileSize;
            LastModified = DateTime.Now;
            Path = path;
        }

        /// <summary>
        /// Initializes the project
        /// </summary>
        public void Load()
        {
        }

        /// <summary>
        /// Saves the project to it's directory
        /// </summary>
        public void Save()
        {
            Serialization.XmlSerialize(this, System.IO.Path.Combine(Path, Name + ".proj"));
        }
    }

}
