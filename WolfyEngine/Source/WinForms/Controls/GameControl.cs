using System;
using System.Drawing;
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
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;
using Color = Microsoft.Xna.Framework.Color;
using ControlEventHandler = WolfyCore.Engine.ControlEventHandler;
using Image = WolfyCore.Engine.Image;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WolfyEngine.Controls
{
    public class GameControl : InvalidationControl
    {
        public enum EditorMode { Tiles, Entities }
        public enum Tools { Pencil, Fill }

        public event ControlEventHandler OnInitialize;
        public event EventHandler<Vector2> OnCoordinatesChanged;
        public event MouseEventHandler OnRightClick;
        public event EntityEventHandler OnEntitySelect;

        public bool StartingMap { get; private set; }
        public new Vector2 MousePosition { get; private set; }
        public Rectangle SelectedTileRegion { get; private set; }
        public bool MouseOnScreen { get; private set; }
        public new bool MouseDown { get; private set; }

        public Image EntityImage { get; private set; }
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
                OnCoordinatesChanged?.Invoke(this, value);
            }
        }
        public Color Color { get; set; } = new Color(60, 63, 65);

        public GameControl()
        {
            Selector = new Selector();

            Mode = EditorMode.Entities;
            Tool = Tools.Pencil;

            SelectedTileRegion = new Rectangle(0, 0, 1, 1);

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
                var entity = ((EntityLayer)CurrentLayer).
                    GetEntity(new Vector2(TileCoordinates.X, TileCoordinates.Y));
                OnEntitySelect?.Invoke(entity, TileCoordinates);
            }
        }

        private void GameControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (CurrentMap == null)
                return;

            if (Mode == EditorMode.Entities)
            {
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
            MousePosition = new Vector2((int)(e.X / TileSize.X), (int)(e.Y / TileSize.Y));
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
            Selector.Initialize(Editor.graphics);
            OnInitialize?.Invoke();
        }

        protected void LoadContent(ContentManager content)
        {
            EntityImage = new Image("Assets/Icons/EntityIcon")
            {
                Scale = (float)Runtime.GridSize / 64
            };
            EntityGridImage = new Image("Assets/Icons/EntityGridIcon")
            {
                Scale = (float)Runtime.GridSize / 64
            };
            SelectedTileImage = new Image("Assets/Icons/SelectedTileIcon")
            {
                Scale = (float)Runtime.GridSize / 64,
                Alpha = .5f
            };
            StartingPointImage = new Image("Assets/Icons/StartingPointIcon")
            {
                Scale = (float)Runtime.GridSize / 64
            };

            EntityImage.LoadContent(content);
            EntityGridImage.LoadContent(content);
            SelectedTileImage.LoadContent(content);
            Selector.LoadContent(content);
            StartingPointImage.LoadContent(content);
        }

        protected override void Draw()
        {
            base.Draw();
            if (Editor == null) return;

            // Draw background color to imitate control transparency
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
                DrawEntityLayerGrid(CurrentLayer as EntityLayer);

            Editor.spriteBatch.End();
        }

        private void DrawEntityLayerGrid(EntityLayer layer)
        {
            for (var y = 0; y < CurrentLayer.Size.Y; y++)
            {
                for (var x = 0; x < CurrentLayer.Size.X; x++)
                {
                    EntityGridImage.Position = new Vector2(x * TileSize.X,
                        y * TileSize.Y);
                    EntityGridImage.Draw(Editor.spriteBatch);

                    var entity = layer.Rows[y].Tiles[x].Entity;
                    if (entity == Entity.Empty) 
                        continue;
                    
                    if (entity == Entity.Player)
                    {
                        StartingPointImage.Position = new Vector2(x * TileSize.X, y * TileSize.Y);
                        StartingPointImage.Draw(Editor.spriteBatch);
                    }
                    else
                    {
                        EntityImage.Position = new Vector2(x * TileSize.X, y * TileSize.Y);
                        EntityImage.Draw(Editor.spriteBatch);
                    }
                }
            }

            SelectedTileImage.Position = new Vector2(
                TileCoordinates.X * TileSize.X,
                TileCoordinates.Y * TileSize.Y);
            SelectedTileImage.Draw(Editor.spriteBatch);
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
                Size = new Size(10, 10);
                Invalidate();
                return;
            }

            StartingMap = CurrentMap.Id == Entity.Player.GetComponent<TransformComponent>().CurrentMap;

            Width = map.Size.X * TileSize.X;
            Height = map.Size.Y * TileSize.Y;

            map.Initialize(Editor.graphics, World);
            map.LoadContent(Editor.Content);

            if(map.Layers.Any())
                CurrentLayer = map.Layers[0];

            Invalidate();
        }

        public void LoadWorld(World world)
        {
            World = world;
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
