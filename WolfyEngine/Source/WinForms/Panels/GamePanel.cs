using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Docking;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using WolfyECS;
using WolfyEngine.Forms;
using WolfyCore;
using WolfyCore.Controllers;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using Color = Microsoft.Xna.Framework.Color;
using Point = System.Drawing.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WolfyEngine.Controls
{
    public partial class GamePanel : DarkDocument
    {
        private SchemeManager _schemeManager;
        private Map _currentMap;
        private World _world;

        public event EventHandler<bool> OnGameStateChanged;

        private bool _gameRunning;
        private bool _gamePaused = false;

        private bool GameRunning
        {
            get => _gameRunning;
            set
            {
                _gameRunning = value;
                OnGameStateChanged?.Invoke(this, value);
            }
        }

        private bool GamePaused
        {
            get => _gamePaused;
            set
            {
                _gamePaused = value;
                if (wolfyGameControl.Visible)
                    wolfyGameControl.Paused = value;
            }
        }

        public GamePanel()
        {
            InitializeComponent();
            gameEditorControl.OnCoordinatesChanged += SetCoordinatesInfo;
            gameEditorControl.OnRightClick += GameControl_OnRightClick;
            gameEditorControl.OnEntitySelect += GameControl_OnEntitySelect;
            _schemeManager = new SchemeManager();
            RefreshButtons();
        }

        public void LoadWorld()
        {
            _world = World.WorldInstance;
            if(_world == null)
                throw new Exception("World doesn't exist.");

            gameEditorControl.LoadWorld(_world);
        }

        public void InitializeProject(Project project)
        {
            if (project == null)
            {
                darkToolStrip.Enabled = false;
                return;
            }
            
            LoadWorld();
        }

        private void GameControl_OnEntitySelect(Entity entity, Vector2 position)
        {
            if (entity == Entity.Empty)
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
                    var transform = new TransformComponent
                    {
                        CurrentMap = _currentMap.Id,
                        GridTransform = position,
                        Transform = position * Runtime.GridSize
                    };

                    form.Initialize(selectedScheme, _world, transform);
                    form.OnSave += delegate(Entity newEntity, Vector2 vector2)
                    {
                        var layer = gameEditorControl.GetCurrentLayer<EntityLayer>();
                        layer.AddEntity(newEntity, vector2);
                    };
                    form.ShowDialog();
                }
            }
            else
            {
                using var form = new EntityEditForm { SavedEntity = true };
                form.Initialize(entity, _world);
                form.ShowDialog();
            }
        }

        private void GameControl_OnRightClick(object sender, MouseEventArgs e)
        {
            EntityContextMenu.CurrentCoordinates =
                new Vector2((float)e.X/Runtime.TileSize.X, (float)e.Y/Runtime.TileSize.Y);
            EntityContextMenu.Show(this, new Point(e.X, e.Y + darkToolStrip.Height));
        }

        private void SetCoordinatesInfo(object sender, Vector2 vector)
        {
            var (x, y) = vector;
            if (gameEditorControl.CurrentLayer is TileLayer lay)
            {
                if (y > lay.Size.Y - 1|| x > lay.Size.X - 1 || y < 0 || x < 0) return;
                if (lay.Rows[(int)y].Tiles[(int) x] == null) return;

                var pas = lay.Rows[(int)y].Tiles[(int)x].Passage;

                var tile = lay.Rows[(int) y].Tiles[(int) x];

                var refEquals = tile == lay.Tileset.Rows[tile.Source.Y / 32].Tiles[tile.Source.X/32];

                toolStripCoordinatesLabel.Text = "X: " + x + " | Y: " + y + " | Passage: " + pas.Value
                    + " | Equal: " + refEquals;
            }
            else if (gameEditorControl.CurrentLayer is EntityLayer elay)
            {
                if (y > elay.Size.Y - 1 || x > elay.Size.X - 1 || y < 0 || x < 0) return;

                var ent = elay.GetEntity((int)x, (int)y);

                if (ent != Entity.Empty)
                    toolStripCoordinatesLabel.Text = "X: " + x + " | Y: " + y + " | Entity: "; //+ ent.Name;
                else toolStripCoordinatesLabel.Text = "X: " + x + " | Y: " + y + " | Entity: None";

            }
            
        }

        public void LoadMap(Map map)
        {
            _currentMap = map;
            gameEditorControl.LoadMap(map);
            RefreshButtons();
        }

        public void LoadLayer(BaseLayer layer)
        {
            gameEditorControl.LoadLayer(layer);
            SetTransparency(layer);
        }

        public void ChangeSelection(Rectangle rect)
        {
            gameEditorControl.SetTileRegion(rect);
        }

        private void RestoreLayers()
        {
            foreach (var layer in _currentMap.Layers)
            {
                if (!(layer is TileLayer lay)) continue;
                lay.SetColor(Color.White, 1f);
            }
            gameEditorControl.Invalidate();
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
            
            gameEditorControl.Invalidate();
        }

        private void NewEntityToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            // Open select entity type form
            using var form = new SelectEntityTypeForm();
            //form.OnTypeSelected += OnEntityTypeSelected;
            //form.ShowDialog();
        }

        private void SetStartingPointToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var newCoordinates = new Vector2((int)EntityContextMenu.CurrentCoordinates.X, (int)EntityContextMenu.CurrentCoordinates.Y);
            var transform = Entity.Player.GetComponent<TransformComponent>();

            if (transform.CurrentMap != _currentMap.Id)
            {
                var map = MapsController.Instance.GetMap(transform.CurrentMap);
                map.RemoveEntity(transform.GridTransform);
                map = MapsController.Instance.GetMap(_currentMap.Id);
                map.AddEntity(Entity.Player, newCoordinates);
            }
            else
            {
                var map = MapsController.Instance.GetMap(transform.CurrentMap);
                map.MoveEntity(Entity.Player, transform.GridTransform, newCoordinates);
            }

            transform.CurrentMap = _currentMap.Id;
            transform.GridTransform = newCoordinates;
            transform.Transform = newCoordinates * Runtime.GridSize;

            gameEditorControl.Invalidate();
        }

        private void PencilButton_Click(object sender, System.EventArgs e)
        {
            gameEditorControl.Tool = GameControl.Tools.Pencil;
            PencilButton.Checked = true;
            FillButton.Checked = false;
        }

        private void FillButton_Click(object sender, System.EventArgs e)
        {
            gameEditorControl.Tool = GameControl.Tools.Fill;
            FillButton.Checked = true;
            PencilButton.Checked = false;
        }

        public void RefreshButtons()
        {
            if (_currentMap == null)
            {
                darkToolStrip.Enabled = false;
                return;
            }

            darkToolStrip.Enabled = true;
            
            if (GameRunning)
            {
                StartGameButton.Enabled = GamePaused;
                PauseGameButton.Enabled = !GamePaused;
                StopGameButton.Enabled = true;
            }
            else
            {
                StartGameButton.Enabled = true;
                PauseGameButton.Enabled = false;
                StopGameButton.Enabled = false;
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            // Start game here
            if (!GameRunning)
            {
                GameRunning = true;

                wolfyGameControl.Location = new Point(0, darkToolStrip.Height);

                wolfyGameControl.Size = new Size(Size.Width - 32, Size.Height - 32);
                // TODO: Fix wolfyGameControl size on resize.
                /*if (gameEditorControl.Size.Width > Size.Width)
                    wolfyGameControl.Size = gameEditorControl.Size.Height > Size.Height ? Size : new Size(Size.Width, gameEditorControl.Height);
                else
                    wolfyGameControl.Size = gameEditorControl.Size.Height > Size.Height ? new Size(gameEditorControl.Width, Size.Height) : gameEditorControl.Size;*/

                Runtime.GameScreenWidth = wolfyGameControl.Width;
                Runtime.GameScreenHeight = wolfyGameControl.Height;

                wolfyGameControl.Visible = true;
                wolfyGameControl.LoadMap(_currentMap);
                wolfyGameControl.LoadWorld(World.WorldInstance);
                wolfyGameControl.InitializeScene();
                wolfyGameControl.InitializeGui();
                gameEditorControl.Visible = false;
            }
            else if (GamePaused)
            {
                GamePaused = false;
                MediaPlayer.Resume();
            }

            RefreshButtons();
        }


        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            // Pause game here
            GamePaused = true;
            MediaPlayer.Pause();

            RefreshButtons();
        }

        private void StopGameButton_Click(object sender, EventArgs e)
        {
            // Stop game here
            GamePaused = false;
            GameRunning = false;

            MediaPlayer.Stop();
            wolfyGameControl.UnloadScene();
            wolfyGameControl.UnloadGui();
            wolfyGameControl.Visible = false;
            gameEditorControl.Visible = true;
            
            RefreshButtons();
        }

        private void RemoveEntityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var coordinates = gameEditorControl.TileCoordinates;

            var layer = gameEditorControl.GetCurrentLayer<EntityLayer>();
            var entity = layer.GetEntity(coordinates);

            if (entity != Entity.Player)
            {
                entity.Destroy();
                layer.RemoveEntity(coordinates);
            }
        }
    }
}
