using System;
using DarkUI.Forms;
using ProtoBuf;
using WolfyCore.Engine;
using WolfyEngine.Engine;

namespace WolfyCore
{
    public delegate void ProjectEventHandler(Project project);

    [ProtoContract] public class Project
    {
        [ProtoMember(1)] public string Name { get; set; }
        [ProtoMember(2)] public string Path { get; set; }
        [ProtoMember(3)] public Vector2D TileSize { get; set; }
        [ProtoMember(4)] public DateTime LastModified { get; set; }
        [ProtoMember(5)] public SerializationData SerializationData { get; set; }

        public Project() { }
        public Project(string name, string path, Vector2D tileSize)
        {
            Name = name;
            Path = path;
            TileSize = tileSize;
            LastModified = DateTime.Now;
            Path = path;
            SerializationData = new SerializationData();
        }

        /// <summary>
        /// Initializes the project
        /// </summary>e
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

            SerializationData.Initialize();
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
