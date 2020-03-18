using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using WolfyEngine.Utils;
using WolfyShared.Controllers;
using WolfyShared.Engine;
using WolfyShared.Game;
using ControlEventHandler = WolfyShared.Engine.ControlEventHandler;

namespace WolfyEngine.Controls
{
    public class GameControl : InvalidationControl
    {
        public enum EditorMode
        {
            Tiles,
            Entities
        }

        public event ControlEventHandler OnInitialize;
        public event Vector2EventHandler OnCoordinatesChanged;
        public event MouseEventHandler OnRightClick;
        public event EntityEventHandler OnEntitySelect;


        public EditorMode Mode { get; private set; }
        private Map _currentMap;
        private bool _startingMap;
        private Selector _selector;
        private Vector2 _mousePosition;
        private Rectangle _selectedTileRegion;
        private float _currentZoom;
        private bool _mouseOnScreen, _mouseDown;
        private Image _entityGridImage;
        private Image _selectedTileImage;
        private Image _startingPointImage;

        public BaseLayer CurrentLayer { get; private set; }

        public bool Paused { get; set; } = false;

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

        // Editor background color
        public Color Color { get; set; } = new Color(60, 63, 65);

        public GameControl()
        {
            Mode = EditorMode.Entities;
            _currentZoom = 1f;
            _selectedTileRegion = new Rectangle(0, 0, 1, 1);
            _entityGridImage = new Image("Assets/Icons/EntityGridIcon.png")
            {
                Scale = .5f
            };
            _selectedTileImage = new Image("Assets/Icons/SelectedTileIcon.png")
            {
                Scale = .5f,
                Alpha = .5f
            };
            _startingPointImage = new Image("Assets/Icons/StartingPointIcon.png")
            {
                Scale = .5f
            };
            

            _selector = new Selector(0.666f);

            MouseEnter += delegate { _mouseOnScreen = true; };
            MouseLeave += delegate
            {
                _mouseOnScreen = false;
                Draw();
                Invalidate();
            };

            MouseMove += GameControl_MouseMove;
            MouseDown += GameControl_MouseDown;
            MouseUp += delegate { _mouseDown = false; };
            MouseClick += GameControl_MouseClick;
            MouseDoubleClick += GameControl_MouseDoubleClick;
        }

        private void GameControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Mode == EditorMode.Entities)
            {
                // Get selected entity
                var entity = (CurrentLayer as EntityLayer)?
                    .Rows[(int) TileCoordinates.Y].Tiles[(int) TileCoordinates.X].Entity;

                OnEntitySelect?.Invoke(entity);
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
                (CurrentLayer as TileLayer)?.ReplaceTiles(_mousePosition, _selectedTileRegion);

            _mouseDown = true;
        }

        private void GameControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(_mouseDown)
                GameControl_MouseDown(this, null);

            HandleSelector(e);
        }

        private void HandleSelector(MouseEventArgs e)
        {
            if (_currentMap == null || CurrentLayer == null) return;
            _mousePosition = new Vector2((int)(e.X / _currentMap.TileSize.X / _currentZoom), (int)(e.Y / _currentMap.TileSize.Y / _currentZoom));
            TileCoordinates = _mousePosition;
            _mousePosition *= _currentMap.TileSize.X;
            var width = _selectedTileRegion.Width * _currentMap.TileSize.X;
            var height = _selectedTileRegion.Height * _currentMap.TileSize.Y;

            _selector.SetPosition(_mousePosition,
                new Vector2(_mousePosition.X + width, _mousePosition.Y),
                new Vector2(_mousePosition.X, _mousePosition.Y + height),
                new Vector2(_mousePosition.X + width, _mousePosition.Y + height));

            Invalidate();
        }

        protected override void Initialize()
        {
            base.Initialize();

            _entityGridImage.Initialize(GraphicsDevice);
            _selectedTileImage.Initialize(GraphicsDevice);
            _selector.Initialize(GraphicsDevice);
            _startingPointImage.Initialize(GraphicsDevice);

            OnInitialize?.Invoke();
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor == null) return;

            GraphicsDevice.Clear(Color);

            Editor.spriteBatch.Begin();

            _currentMap?.Draw(Editor.spriteBatch);

            if(_mouseOnScreen && CurrentLayer is TileLayer)
                _selector.Draw(Editor.spriteBatch);

            if (CurrentLayer is EntityLayer)
            {
                for (var y = 0; y < CurrentLayer.Size.Y; y++)
                {
                    for (var x = 0; x < CurrentLayer.Size.X; x++)
                    {
                        _entityGridImage.Position = new Vector2(x * _currentMap.TileSize.X,
                            y * _currentMap.TileSize.Y);
                        _entityGridImage.Draw(Editor.spriteBatch);
                    }
                }

                if(_selectedTile != null)
                {
                    _selectedTileImage.Position = new Vector2(
                        _selectedTileCords.X * _currentMap.TileSize.X,
                        _selectedTileCords.Y * _currentMap.TileSize.Y);
                    _selectedTileImage.Draw(Editor.spriteBatch);
                }

                if (_startingMap)
                    _startingPointImage.Draw(Editor.spriteBatch);
                
            }

            Editor.spriteBatch.End();
        }

        public void SetTileRegion(Rectangle rect)
        {
            _selectedTileRegion = rect;
        }

        public void LoadMap(Map map)
        {
            _currentMap = map;

            // Set control size to fit the map
            if (map == null)
            {
                Width = 10;
                Height = 10;
                Invalidate();
                return;
            }

            SetStartingPosition();

            Width = map.Size.X * map.TileSize.X;
            Height = map.Size.Y * map.TileSize.Y;

            map?.Initialize(Editor.graphics);

            if(map.Layers.Any())
                CurrentLayer = map.Layers[0];

            Invalidate();
        }

        public void SetStartingPosition()
        {
            _startingMap = _currentMap.Id == GameController.Instance.Settings.StartingMap;

            if (!_startingMap) return;
            var coordinates = GameController.Instance.Settings.StartingCoordinates;
            _startingPointImage.Position =
                new Vector2(coordinates.X * _currentMap.TileSize.X, coordinates.Y * _currentMap.TileSize.Y);
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
        }
    }
}
