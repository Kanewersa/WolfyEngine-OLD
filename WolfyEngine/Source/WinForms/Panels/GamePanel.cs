using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyEngine.Forms;
using WolfyShared.Controllers;
using WolfyShared.Engine;
using WolfyShared.Game;
using Color = Microsoft.Xna.Framework.Color;
using Point = System.Drawing.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WolfyEngine.Controls
{
    public partial class GamePanel : DarkDocument
    {
        public GameControl GameControl => gameControl;

        private SchemeManager _schemeManager;
        private Map _currentMap;
        private World _world;

        public GamePanel()
        {
            InitializeComponent();
            gameControl.OnCoordinatesChanged += SetCoordinatesInfo;
            gameControl.OnRightClick += GameControl_OnRightClick;
            gameControl.OnEntitySelect += GameControl_OnEntitySelect;
            _schemeManager = new SchemeManager();
        }

        public void LoadWorld()
        {
            _world = GameController.Instance.World;
            if(_world == null)
                throw new Exception("World doesn't exist.");
        }

        public void InitializeProject()
        {
            LoadWorld();
        }

        private void GameControl_OnEntitySelect(Entity entity, Vector2 position)
        {
            if (entity == null)
            {
                EntityScheme selectedScheme = null;

                using (var form = new SelectEntityTypeForm())
                {
                    form.Initialize(_schemeManager);
                    form.OnTypeSelected += delegate(EntityScheme scheme)
                    {
                        selectedScheme = scheme;
                        form.Close();
                    };
                    form.ShowDialog();
                }

                if (selectedScheme == null) return;

                using (var form = new EntityEditForm())
                {
                    form.Initialize(selectedScheme, _world);
                    form.OnSave += delegate(Entity newEntity, Vector2 vector2)
                    {
                        var layer = gameControl.GetCurrentLayer<EntityLayer>();
                        layer.Rows[(int)position.Y]
                            .Tiles[(int)position.X].Entity = newEntity;
                        layer.Entities.Add(newEntity);
                        gameControl.CurrentMap.Entities.Add(newEntity);
                    };
                    form.ShowDialog();
                }
            }
            else
            {
                // Get entity type and open edit form
                var entityComponents = entity.GetComponents();
                using(var form = new EntityEditForm())
                {
                    form.SavedEntity = true;
                    form.Initialize(entity, entityComponents, _world);
                    form.ShowDialog();
                }
            }
        }

        private void GameControl_OnRightClick(object sender, MouseEventArgs e)
        {
            EntityContextMenu.CurrentCoordinates =
                new Vector2D(e.X/_currentMap.TileSize.X, e.Y/_currentMap.TileSize.Y);
            EntityContextMenu.Show(this, new Point(e.X, e.Y + darkToolStrip.Height));
        }

        private void SetCoordinatesInfo(Vector2 vector)
        {
            var (x, y) = vector;
            if (gameControl.CurrentLayer is TileLayer lay)
            {
                if (y > lay.Size.Y - 1|| x > lay.Size.X - 1 || y < 0 || x < 0) return;
                if (lay.Rows[(int)y].Tiles[(int) x] == null) return;

                var pas = lay.Rows[(int)y].Tiles[(int)x].Passage;

                var tile = lay.Rows[(int) y].Tiles[(int) x];

                var refEquals = tile == lay.Tileset.Rows[tile.Source.Y / 32].Tiles[tile.Source.X/32];

                toolStripCoordinatesLabel.Text = "X: " + x + " | Y: " + y + " | Passage: " + pas.Value
                    + " | Equal: " + refEquals;
            }
            else
            {
                toolStripCoordinatesLabel.Text = "X: " + x + " | Y: " + y;
            }
            
        }

        public void LoadMap(Map map)
        {
            _currentMap = map;
            gameControl.LoadMap(map);
        }

        public void LoadLayer(BaseLayer layer)
        {
            gameControl.LoadLayer(layer);
            SetTransparency(layer);
        }

        public void ChangeSelection(Rectangle rect)
        {
            gameControl.SetTileRegion(rect);
        }

        private void RestoreLayers()
        {
            foreach (var layer in _currentMap.Layers)
            {
                if (!(layer is TileLayer lay)) continue;
                lay.SetColor(Color.White, 1f);
            }
            gameControl.Invalidate();
        }

        private void SetTransparency(BaseLayer desiredLayer)
        {
            if (desiredLayer == null || desiredLayer is EntityLayer)
            {
                RestoreLayers();
                return;
            }

            var layers = _currentMap.Layers;

            var index = layers.IndexOf(desiredLayer);

            // Set lower layers
            for (var i = 0; i < index; i++)
                if (layers[i] is TileLayer lay)
                    lay.SetColor(new Color(157, 157, 157), 1f);
            
            // Set desired layer
            if (desiredLayer is TileLayer desiredLay)
                desiredLay.SetColor(Color.White, 1f);

            // Set higher layers
            for (var i = index + 1; i < layers.Count; i++)
                if (layers[i] is TileLayer lay)
                    lay.SetColor(Color.White, .4f);
            
            gameControl.Invalidate();
        }

        private void newEntityToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // Open select entity type form
            using (var form = new SelectEntityTypeForm())
            {
                //form.OnTypeSelected += OnEntityTypeSelected;
                //form.ShowDialog();
            }
        }

        private void setStartingPointToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            GameController.Instance.Settings.StartingMap = _currentMap.Id;
            GameController.Instance.Settings.StartingCoordinates = EntityContextMenu.CurrentCoordinates;
            gameControl.SetStartingPosition();
            gameControl.Invalidate();
        }

        private void PencilButton_Click(object sender, System.EventArgs e)
        {
            gameControl.Tool = GameControl.Tools.Pencil;
            PencilButton.Checked = true;
            FillButton.Checked = false;
        }

        private void FillButton_Click(object sender, System.EventArgs e)
        {
            gameControl.Tool = GameControl.Tools.Fill;
            FillButton.Checked = true;
            PencilButton.Checked = false;
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_world.EntityCount());
        }
    }
}
