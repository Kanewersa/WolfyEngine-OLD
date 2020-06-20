using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Forms.Controls;
using WolfyEngine.Utils;
using WolfyCore;
using WolfyCore.Engine;
using WolfyCore.Game;
using ControlEventHandler = WolfyCore.Engine.ControlEventHandler;

namespace WolfyEngine.Controls
{
    public delegate void RectangleEvent(Rectangle rectangle);
    public class TilesetControl : InvalidationControl
    {
        private TileLayer _currentLayer;
        private Image _currentImage => _currentLayer.Tileset.Image;
        public event ControlEventHandler OnInitialize;

        private Selector _selector;

        private bool _mouseOnScreen;
        private bool _mouseDown;
        private Vector2 _mousePosition, _clickPosition;
        public Vector2 _tileCoordinates;
        private Rectangle _selectedTileRegion;

        private float _currentZoom;

        public event RectangleEvent OnControlClick;

        public Vector2D TileSize => Runtime.TileSize;
        public int GridSize => Runtime.GridSize;


        // Editor background color
        public Color Color { get; set; } = new Color(60,63,65);

        public TilesetControl()
        {
            _currentZoom = 1f;
            _selectedTileRegion = new Rectangle(0,0,0,0);

            _selector = new Selector();
        }

        private void TilesetControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HandleSelector(e);
        }

        private void HandleSelector(MouseEventArgs e)
        {
            if (_currentLayer == null) return;
            _mousePosition = new Vector2((int)(e.X / TileSize.X), (int)(e.Y / TileSize.Y));
            _mousePosition *= 32;

            if (_mousePosition != _clickPosition && _mouseDown)
            {

                for (var i = 0; i < 4; i++)
                {
                    if (i % 2 == 0 && _mousePosition.X < _clickPosition.X)
                        _selector.SetPositionX(i, _mousePosition.X);
                    else if (i % 2 != 0 && _mousePosition.X > _clickPosition.X)
                        _selector.SetPositionX(i, _mousePosition.X);
                    if (i < 2 && _mousePosition.Y < _clickPosition.Y)
                        _selector.SetPositionY(i, _mousePosition.Y);
                    else if (i >= 2 && _mousePosition.Y > _clickPosition.Y)
                        _selector.SetPositionY(i, _mousePosition.Y);
                }
                Invalidate();
            }
            else if (_mouseDown)
            {
                var width = 0;
                var height = 0;

                _selector.SetPosition(_mousePosition, new Vector2(_mousePosition.X + width, _mousePosition.Y),
                    new Vector2(_mousePosition.X, _mousePosition.Y + height), new Vector2(_mousePosition.X + width, _mousePosition.Y + height));

                Invalidate();
            }
        }

        private void TilesetControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_mouseDown)
            {
                _clickPosition = _mousePosition;
                _selector.SetPosition(_mousePosition);
            }

            _mouseDown = true;
            Invalidate();
        }

        protected override void Initialize()
        {
            base.Initialize();

            _selector.Initialize(GraphicsDevice);

            MouseEnter += delegate { _mouseOnScreen = true; };
            MouseLeave += delegate
            {
                _mouseOnScreen = false;
                Draw();
                Invalidate();
            };

            MouseMove += TilesetControl_MouseMove;
            MouseDown += TilesetControl_MouseDown;
            MouseUp += delegate
            {
                _mouseDown = false;

                var rect = new Rectangle(
                    (int)_selector.GetPositionX(0), (int)_selector.GetPositionY(0),
                    (int)(_selector.GetPositionX(1) - _selector.GetPositionX(0)),
                    (int)(_selector.GetPositionY(2) - _selector.GetPositionY(0)));

                rect.X /= GridSize;
                rect.Y /= GridSize;
                rect.Width /= GridSize;
                rect.Height /= GridSize;

                OnControlClick?.Invoke(rect);
            };

            _selector.Initialize(GraphicsDevice);
            LoadContent(Editor.Content);
            OnInitialize?.Invoke();
        }

        protected void LoadContent(ContentManager content)
        {
            _selector.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor == null) return;

            GraphicsDevice.Clear(Color);
            Editor.spriteBatch.Begin();

            if (_currentLayer != null)
            {
                _currentImage.Draw(Editor.spriteBatch);
                _selector.Draw(Editor.spriteBatch);
            }

            Editor.spriteBatch.End();
        }

        public void LoadLayer(TileLayer layer)
        {
            _currentLayer = layer;

            if (layer == null)
            {
                Width = 10;
                Height = 10;
                Invalidate();
                return;
            }

            layer.Initialize(GraphicsDevice);
            layer.LoadContent(Editor.Content);
            //_currentImage.Initialize(GraphicsDevice);
            // Set control size to fit the texture
            Width = _currentImage.Texture.Width;
            Height = _currentImage.Texture.Height;
            

            Invalidate();
        }
    }
}
