using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Forms.Controls;
using WolfyCore;
using WolfyCore.Engine;
using WolfyCore.Game;

namespace WolfyEngine.Controls
{
    public delegate Image ImageTileHandler(Tile tile);
    public delegate int TileHandler(Tile tile);

    class TilesetEditorControl : InvalidationControl
    {
        // Editor background color
        public Color Color { get; set; } = new Color(60, 63, 65);

        private Tileset _currentTileset;

        private Tile _currentTile;
        private Tile _lastTile = new Tile();

        public Vector2D TileSize => Runtime.TileSize;
        private float _imageScale;
        private float _imageAlpha = 0.7f;

        private Vector2 mousePosition;

        public TileHandler CurrentBool { get; private set; }
        public ImageTileHandler CurrentImage { get; private set; }

        #region Images
        private Image _currentImage => _currentTileset.Image;

        public Image PassageFalse { get; private set; }
        public Image PassageTrue { get; private set; }
        public Image Bush { get; private set; }
        public Image Dot { get; private set; }

        public Image ShadowNone { get; private set; }
        public Image ShadowOne { get; private set; }
        public Image ShadowTwo { get; private set; }
        public Image ShadowThree { get; private set; }

        #endregion

        protected override void Initialize()
        {
            base.Initialize();

            _imageScale = TileSize.X / 64;
            PassageFalse = new Image
                {Path = "Assets/Icons/PassageFalseIcon", Scale = _imageScale, Alpha = _imageAlpha};
            PassageTrue = new Image
                {Path = "Assets/Icons/PassageTrueIcon", Scale = _imageScale, Alpha = _imageAlpha};
            Bush = new Image {Path = "Assets/Icons/BushIcon", Scale = _imageScale, Alpha = _imageAlpha};
            Dot = new Image {Path = "Assets/Icons/DotIcon", Scale = _imageScale, Alpha = _imageAlpha};
            ShadowNone = new Image{Path = "Assets/Icons/Zero", Scale = _imageScale, Alpha = _imageAlpha };
            ShadowOne = new Image { Path = "Assets/Icons/One", Scale = _imageScale, Alpha = _imageAlpha };
            ShadowTwo = new Image { Path = "Assets/Icons/Two", Scale = _imageScale, Alpha = _imageAlpha };
            ShadowThree = new Image { Path = "Assets/Icons/Three", Scale = _imageScale, Alpha = _imageAlpha };

            CurrentImage = DrawPassage;
            CurrentBool = SetPassage;

            MouseMove += TilesetEditor_MouseMove;
            MouseLeave += delegate { EditorMouseLeave(); };
            MouseClick += TilesetEditorControl_MouseClick;

            LoadContent(Editor.Content);
            InitializeCurrentTileset();
        }

        protected void LoadContent(ContentManager content)
        {
            PassageFalse.LoadContent(content);
            PassageTrue.LoadContent(content);
            Bush.LoadContent(content);
            Dot.LoadContent(content);
            ShadowNone.LoadContent(content);
            ShadowOne.LoadContent(content);
            ShadowTwo.LoadContent(content);
            ShadowThree.LoadContent(content);
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

            mousePosition = new Vector2((int)(e.X / TileSize.X), (int)(e.Y / TileSize.Y));
            mousePosition *= TileSize.X;
            var indexX = (int)(mousePosition.X / TileSize.X);
            var indexY = (int)(mousePosition.Y / TileSize.Y);

            if (indexX >= _currentTileset.Size.X) { EditorMouseLeave(); return; }
            if (indexY >= _currentTileset.Size.Y) { EditorMouseLeave(); return; }

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
            for (var y = 0; y < _currentTileset.Size.Y; y++)
            {
                for (var x = 0; x < _currentTileset.Size.X; x++)
                {
                    var img = CurrentImage(_currentTileset.Rows[y].Tiles[x]);

                    img.Alpha = _currentTileset.Rows[y].Tiles[x].Hovered ? 1.0f : 0.6f;

                    img.Position = new Vector2(x * TileSize.X, y * TileSize.X);
                    img.Scale = (float)Runtime.GridSize/img.Texture.Width;
                    img.Draw(Editor.spriteBatch);
                }
            }
        }

        private Image DrawPassage(Tile tile)
        {
            return tile.Passage ? PassageTrue : PassageFalse;
        }

        private int SetPassage(Tile tile)
        {
            tile.Passage = !tile.Passage;
            return tile.Passage ? 1 : 0;
        }

        private Image DrawBush(Tile tile)
        {
            return tile.Bush ? Bush : Dot;
        }

        private int SetBush(Tile tile)
        {
            tile.Bush = !tile.Bush;
            return tile.Bush ? 1 : 0; 
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
            _currentTileset.Initialize();
            _currentTileset.LoadContent(Editor.Content);
            Width = _currentTileset.Image.Texture.Width;
            Height = _currentTileset.Image.Texture.Height;
        }
    }
}
