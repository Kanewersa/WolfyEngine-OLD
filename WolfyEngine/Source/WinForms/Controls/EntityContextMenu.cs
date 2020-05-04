using System.Windows.Forms;
using DarkUI.Renderers;
using WolfyCore.Engine;

namespace WolfyEngine.Controls
{
    public class EntityContextMenu : ContextMenuStrip
    {
        public Vector2D CurrentCoordinates { get; set; }

        public EntityContextMenu()
        {
            Renderer = (ToolStripRenderer) new DarkMenuRenderer();
        }
    }
}
