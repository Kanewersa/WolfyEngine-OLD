using System;
using DarkUI.Forms;
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
        public void Initialize()
        {
            if(TileSize.X == 0 || TileSize.Y == 0)
                throw new NullReferenceException("Tile size was not set.");

            Runtime.TileSize = TileSize;
            if (TileSize.X != TileSize.Y)
            {
                DarkMessageBox.ShowError(
                    "Rectangle tiles are not supported. The application will close.",
                    "Rectangle tiles error!");
                System.Windows.Forms.Application.Exit();
                throw new Exception("Rectangle tiles are not supported!");
            }
            Runtime.GridSize = TileSize.X;
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
