using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Forms.Controls;
using WolfyECS;
using WolfyEngine.Utils;
using WolfyCore;
using WolfyCore.Controllers;
using WolfyCore.Engine;
using WolfyCore.Game;
using ControlEventHandler = WolfyCore.Engine.ControlEventHandler;

namespace WolfyEngine.Controls
{
    public class GameControl : InvalidationControl
    {
        public enum EditorMode { Tiles, Entities }
        public enum Tools { Pencil, Fill }

        public event ControlEventHandler OnInitialize;
        public event Vector2EventHandler OnCoordinatesChanged;
        public event MouseEventHandler OnRightClick;
        public event EntityEventHandler OnEntitySelect;

        public bool StartingMap { get; private set; }
        public new Vector2 MousePosition { get; private set; }
        public Rectangle SelectedTileRegion { get; private set; }
        public bool MouseOnScreen { get; private set; }
        public new bool MouseDown { get; private set; }
        public Image EntityGridImage { get; private set; }
        public Image SelectedTileImage { get; private set; }
        public Image StartingPointImage { get; private set; }
        public World World { get; private set; }

        public EditorMode Mode { get; private set; }
        public Tools Tool { get; set; }
        public Map CurrentMap { get; set; }
        public Vector2D TileSize => Runtime.TileSize;
        public BaseLayer CurrentLayer { get; private set; }
        public Selector Selector { get; private set; }

        private Vector2 _tileCoordinates;
        public Vector2 TileCoordinates
        {
            get => _tileCoordinates;
            private set
            {
                _tileCoordinates = value;
                OnCoordinatesChanged?.Invoke(value);
            }
        }
        public Color Color { get; set; } = new Color(60, 63, 65);

        public GameControl()
        {
            Selector = new Selector((float)Runtime.GridSize/48);

            Mode = EditorMode.Entities;
            Tool = Tools.Pencil;

            SelectedTileRegion = new Rectangle(0, 0, 1, 1);
            EntityGridImage = new Image("Assets/Icons/EntityGridIcon")
            {
                Scale = .5f
            };
            SelectedTileImage = new Image("Assets/Icons/SelectedTileIcon")
            {
                Scale = .5f,
                Alpha = .5f
            };
            StartingPointImage = new Image("Assets/Icons/StartingPointIcon")
            {
                Scale = .5f
            };
            
            MouseEnter += delegate { MouseOnScreen = true; };
            MouseLeave += delegate
            {
                MouseOnScreen = false;
                Draw();
                Invalidate();
            };

            MouseMove += GameControl_MouseMove;
            ((Control) this).MouseDown += GameControl_MouseDown;
            MouseUp += delegate { MouseDown = false; };
            MouseClick += GameControl_MouseClick;
            MouseDoubleClick += GameControl_MouseDoubleClick;
        }

        private void GameControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Mode == EditorMode.Entities)
            {
                // ReSharper disable once PossibleNullReferenceException
                var entity = (CurrentLayer as EntityLayer).Rows[(int) TileCoordinates.Y]
                    .Tiles[(int) TileCoordinates.X].Entity;

                OnEntitySelect?.Invoke(entity, TileCoordinates);
            }
        }

        private EntityTile _selectedTile;
        private Vector2D _selectedTileCords;

        private void GameControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (Mode == EditorMode.Entities)
            {
                var (x, y) = TileCoordinates;
                if(_selectedTile != null)
                    _selectedTile.Selected = false;
                _selectedTile = ((EntityLayer) CurrentLayer).Rows[(int)y].Tiles[(int)x];
                _selectedTile.Selected = true;
                _selectedTileCords = new Vector2D((int)x,(int)y);

                if (e.Button == MouseButtons.Right)
                {
                    OnRightClick?.Invoke(this, e);
                }
            }
        }

        private void GameControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (Mode == EditorMode.Tiles)
            {
                switch (Tool)
                {
                    case Tools.Pencil:
                        (CurrentLayer as TileLayer)?.ReplaceTiles(MousePosition, SelectedTileRegion);
                        break;
                    case Tools.Fill:
                        if (SelectedTileRegion.Width > 0 || SelectedTileRegion.Height > 0)
                        {
                            DarkMessageBox.ShowWarning(
                                "To use Fill tool select just one tile in tileset view!",
                                "Too big region selected.");
                            return;
                        }
                        (CurrentLayer as TileLayer)?.FillTiles(MousePosition, SelectedTileRegion);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            MouseDown = true;
        }

        private void GameControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(MouseDown)
                GameControl_MouseDown(this, null);

            HandleSelector(e);
        }

        private void HandleSelector(MouseEventArgs e)
        {
            if (CurrentMap == null || CurrentLayer == null) return;
            MousePosition = new Vector2((int)(e.X / TileSize.X), (int)(e.Y / CurrentMap.TileSize.Y));
            TileCoordinates = MousePosition;
            MousePosition *= TileSize.X;
            var width = SelectedTileRegion.Width * TileSize.X;
            var height = SelectedTileRegion.Height * TileSize.Y;

            Selector.SetPosition(MousePosition,
                new Vector2(MousePosition.X + width, MousePosition.Y),
                new Vector2(MousePosition.X, MousePosition.Y + height),
                new Vector2(MousePosition.X + width, MousePosition.Y + height));

            Invalidate();
        }

        protected override void Initialize()
        {
            base.Initialize();

            LoadContent(Editor.Content);
            OnInitialize?.Invoke();
        }

        protected void LoadContent(ContentManager content)
        {
            EntityGridImage.LoadContent(content);
            SelectedTileImage.LoadContent(content);
            Selector.LoadContent(content);
            StartingPointImage.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            if (Editor == null) return;

            // Draw background color to imitate transparency
            GraphicsDevice.Clear(Color);

            Editor.spriteBatch.Begin();

            if (CurrentMap == null)
            {
                Editor.spriteBatch.End();
                return;
            }

            CurrentMap?.Draw(Editor.spriteBatch);

            if (MouseOnScreen && CurrentLayer is TileLayer)
                Selector.Draw(Editor.spriteBatch);
            else if (CurrentLayer is EntityLayer)
                DrawEntityLayer();

            Editor.spriteBatch.End();
        }

        private void DrawEntityLayer()
        {
            for (var y = 0; y < CurrentLayer.Size.Y; y++)
            {
                for (var x = 0; x < CurrentLayer.Size.X; x++)
                {
                    EntityGridImage.Position = new Vector2(x * TileSize.X,
                        y * TileSize.Y);
                    EntityGridImage.Draw(Editor.spriteBatch);
                }
            }

            if (_selectedTile != null)
            {
                SelectedTileImage.Position = new Vector2(
                    _selectedTileCords.X * TileSize.X,
                    _selectedTileCords.Y * TileSize.Y);
                SelectedTileImage.Draw(Editor.spriteBatch);
            }

            if (StartingMap)
                StartingPointImage.Draw(Editor.spriteBatch);
        }

        public void SetTileRegion(Rectangle rect)
        {
            SelectedTileRegion = rect;
        }

        public void LoadMap(Map map)
        {
            CurrentMap = map;

            // Set control size to fit the map
            if (map == null)
            {
                Width = 10;
                Height = 10;
                Invalidate();
                return;
            }

            SetStartingPosition();

            Width = map.Size.X * TileSize.X;
            Height = map.Size.Y * TileSize.Y;

            map?.Initialize(Editor.graphics, World);
            map?.LoadContent(Editor.Content);

            if(map.Layers.Any())
                CurrentLayer = map.Layers[0];

            Invalidate();
        }

        public void LoadWorld(World world)
        {
            World = world;
        }

        public void SetStartingPosition()
        {
            StartingMap = CurrentMap.Id == GameController.Instance.Settings.StartingMap;

            if (!StartingMap) return;
            var coordinates = GameController.Instance.Settings.StartingCoordinates;
            StartingPointImage.Position =
                new Vector2(coordinates.X * TileSize.X, coordinates.Y * TileSize.Y);
        }

        public void LoadLayer(BaseLayer layer)
        {
            switch (layer)
            {
                case null:
                    return;
                case EntityLayer _:
                    Mode = EditorMode.Entities;
                    break;
                case TileLayer _:
                    Mode = EditorMode.Tiles;
                    break;
            }

            CurrentLayer = layer;
            layer.Initialize(GraphicsDevice);
            layer.LoadContent(Editor.Content);
        }

        public T GetCurrentLayer<T>() where T : BaseLayer
        {
            if(CurrentLayer is T layer)
                return layer;
            throw new Exception("Current layer was not " + typeof(T));
        }
    }
}
