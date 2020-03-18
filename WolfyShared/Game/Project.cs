using System;
using Microsoft.Xna.Framework;
using WolfyEngine.Engine;
using WolfyShared.Engine;

namespace WolfyShared
{
    public delegate void ProjectEventHandler(Project project);

    public class Project
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Vector2D TileSize { get; set; }
        public DateTime LastModified { get; set; }

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
