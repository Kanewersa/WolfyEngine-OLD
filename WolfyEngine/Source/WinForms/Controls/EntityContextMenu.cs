using System.Windows.Forms;
using DarkUI.Renderers;
using Microsoft.Xna.Framework;

namespace WolfyEngine.Controls
{
    public class EntityContextMenu : ContextMenuStrip
    {
        public Vector2 CurrentCoordinates { get; set; }

        public EntityContextMenu()
        {
            Renderer = (ToolStripRenderer) new DarkMenuRenderer();
        }
    }
}
