using DarkUI.Docking;
using WolfyShared.Game;

namespace WolfyEngine.Controls
{
    public partial class TilesetEditorPanel : DarkToolWindow
    {
        public TilesetEditorPanel()
        {
            InitializeComponent();
        }

        private void passageButton_Click(object sender, System.EventArgs e)
        {
            tilesetEditorControl.LoadPassage();
        }

        private void BushButton_Click(object sender, System.EventArgs e)
        {
            tilesetEditorControl.LoadBush();
        }

        public void LoadTileset(Tileset tileset)
        {
            tilesetEditorControl.LoadTileset(tileset);
        }
    }
}
