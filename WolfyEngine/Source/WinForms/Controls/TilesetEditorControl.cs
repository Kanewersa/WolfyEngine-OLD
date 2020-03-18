using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using WolfyShared.Engine;
using WolfyShared.Game;

namespace WolfyEngine.Controls
{
    public delegate Image ImageTileHandler(Tile tile);
    public delegate bool BoolTileHandler(Tile tile);

    class TilesetEditorControl : InvalidationControl
    {
        // Editor background color
        public Color Color { get; set; } = new Color(60, 63, 65);

        private Tileset _currentTileset;

        private Tile _currentTile;
        private Tile _lastTile = new Tile();

        private Vector2 _tileSize;
        private float _imageScale;
        private float _imageAlpha = 0.7f;

        private Vector2 mousePosition;

        public BoolTileHandler CurrentBool { get; private set; }
        public ImageTileHandler CurrentImage { get; private set; }

        #region Images
        private Image _currentImage => _currentTileset.Image;

        public Image PassageFalse { get; private set; }
        public Image PassageTrue { get; private set; }
        public Image Bush { get; private set; }
        public Image Dot { get; private set; }

        #endregion

        protected override void Initialize()
        {
            base.Initialize();

            _tileSize = new Vector2(32,32);

            _imageScale = _tileSize.X / 64;

            PassageFalse = new Image {Path = "Assets/Icons/PassageFalseIcon.png", Scale = _imageScale, Alpha = _imageAlpha};
            PassageTrue = new Image { Path = "Assets/Icons/PassageTrueIcon.png", Scale = _imageScale, Alpha = _imageAlpha };
            Bush = new Image { Path = "Assets/Icons/BushIcon.png", Scale = _imageScale, Alpha = _imageAlpha };
            Dot = new Image { Path = "Assets/Icons/DotIcon.png", Scale = _imageScale, Alpha = _imageAlpha };

            PassageFalse.Initialize(GraphicsDevice);
            PassageTrue.Initialize(GraphicsDevice);
            Bush.Initialize(GraphicsDevice);
            Dot.Initialize(GraphicsDevice);

            CurrentImage = DrawPassage;
            CurrentBool = SetPassage;

            MouseMove += TilesetEditor_MouseMove;
            MouseLeave += delegate { EditorMouseLeave(); };
            MouseClick += TilesetEditorControl_MouseClick;

            InitializeCurrentTileset();
        }

        private void TilesetEditorControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_currentTile == null) return;
            CurrentBool(_currentTile);
            Invalidate();
        }

        private void TilesetEditor_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_currentTileset == null) return;

            mousePosition = new Vector2((int)(e.X / _tileSize.X), (int)(e.Y / _tileSize.Y));
            mousePosition *= _tileSize.X;
            var indexX = (int)(mousePosition.X / _tileSize.X);
            var indexY = (int)(mousePosition.Y / _tileSize.Y);

            if (indexX >= _currentTileset.Rows[0].Tiles.Count) { EditorMouseLeave(); return; }
            if (indexY >= _currentTileset.Rows.Count) { EditorMouseLeave(); return; }

            /*if (indexY < 0)
            {
                if (indexX >= _currentTileset.AutoTiles.Count) { EditorMouseLeave(); return; }
                _currentTile = _currentTileset.AutoTiles[indexX];
            }
            else*/
                _currentTile = _currentTileset.Rows[indexY].Tiles[indexX];


            if (_currentTile != _lastTile)
            {
                _lastTile.Hovered = false;
                _currentTile.Hovered = true;
                Invalidate();
            }
            _lastTile = _currentTile;
        }

        private void EditorMouseLeave()
        {
            if (_currentTile == null) return;
            _currentTile.Hovered = false;
            _lastTile = new Tile();
            Invalidate();
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color);

            if (_currentTileset == null || _currentImage?.Texture == null) return;

            Editor.spriteBatch.Begin();

            _currentImage.Draw(Editor.spriteBatch);
            DrawIcons();

            Editor.spriteBatch.End();

        }

        private void DrawIcons()
        {
            for (var y = 0; y < _currentTileset.Rows.Count; y++)
            {
                for (var x = 0; x < _currentTileset.Rows[y].Tiles.Count; x++)
                {
                    var img = CurrentImage(_currentTileset.Rows[y].Tiles[x]);

                    img.Alpha = _currentTileset.Rows[y].Tiles[x].Hovered ? 1.0f : 0.6f;

                    img.Position = new Vector2(x * _tileSize.X, y * _tileSize.X);
                    img.Draw(Editor.spriteBatch);
                }
            }
        }

        private Image DrawPassage(Tile tile)
        {
            return tile.Passage ? PassageTrue : PassageFalse;
        }

        private bool SetPassage(Tile tile)
        {
            tile.Passage = !tile.Passage;
            return tile.Passage;
        }

        private Image DrawBush(Tile tile)
        {
            return tile.Bush ? Bush : Dot;
        }

        private bool SetBush(Tile tile)
        {
            tile.Bush = !tile.Bush;
            return tile.Bush; 
        }

        public void LoadPassage()
        {
            CurrentImage = DrawPassage;
            CurrentBool = SetPassage;
            Invalidate();
        }

        public void LoadBush()
        {
            CurrentImage = DrawBush;
            CurrentBool = SetBush;
            Invalidate();
        }

        public void LoadTileset(Tileset tileset)
        {
            _currentTileset = tileset;
            if(_currentTileset == null) return;

            InitializeCurrentTileset();
            Invalidate();
        }

        private void InitializeCurrentTileset()
        {
            if (_currentTileset == null || _currentImage.Path == null
                                        || Editor == null) return;
            _currentTileset.Initialize(GraphicsDevice);
            Width = _currentTileset.Image.Texture.Width;
            Height = _currentTileset.Image.Texture.Height;
        }
    }
}
