﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Docking;
using DarkUI.Win32;
using WolfyEngine.Controls;
using WolfyEngine.Engine;
using WolfyEngine.Properties;
using WolfyCore;
using WolfyCore.Controllers;
using WolfyCore.Game;
using WolfyECS;
using Timer = System.Windows.Forms.Timer;

namespace WolfyEngine.Forms
{
    public partial class MainForm : WolfyForm
    {
        private readonly List<DarkDockContent> _toolWindows = new List<DarkDockContent>();

        private GamePanel GamePanel { get; }
        private TilesetEditorPanel TilesetEditorPanel { get; }
        private TilesetPainterPanel TilesetPainterPanel { get; }
        private LayersPanel LayersPanel { get; }
        private TilesetsPanel TilesetsPanel { get; }
        private MapsPanel MapsPanel { get; }

        private List<IController> Controllers { get; } = new List<IController>
        {
            ProjectsController.Instance,
            EntityController.Instance,
            GameController.Instance,
            InventoryController.Instance,
            MapsController.Instance,
            TilesetsController.Instance,
            VariablesController.Instance,
        };

        public MainForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            LoadTitle();

            // Add the control scroll message filter to re-route all mousewheel events
            // to the control the user is currently hovering over with their cursor.
            Application.AddMessageFilter(new ControlScrollFilter());

            // Add the dock content drag message filter to handle moving dock content around.
            Application.AddMessageFilter(darkDockPanel.DockContentDragFilter);

            // Add the dock panel message filter to filter through for dock panel splitter
            // input before letting events pass through to the rest of the application.
            Application.AddMessageFilter(darkDockPanel.DockResizeFilter);

            // Build the tool windows and add them to the list
            _toolWindows.Add(GamePanel = new GamePanel());
            _toolWindows.Add(TilesetPainterPanel = new TilesetPainterPanel());
            _toolWindows.Add(LayersPanel = new LayersPanel());
            _toolWindows.Add(MapsPanel = new MapsPanel());
            _toolWindows.Add(TilesetEditorPanel = new TilesetEditorPanel());
            _toolWindows.Add(TilesetsPanel = new TilesetsPanel());

            // TODO: Deserialize the last tool windows state if it exists

            // Add the tool window list contents to the dock panel
            foreach (var window in _toolWindows) darkDockPanel.AddContent(window);

            // Set the dock group of controls
            darkDockPanel.AddContent(TilesetEditorPanel, TilesetPainterPanel.DockGroup);
            darkDockPanel.AddContent(TilesetsPanel, LayersPanel.DockGroup);
            darkDockPanel.ActiveContent = TilesetPainterPanel;
            darkDockPanel.ActiveContent = LayersPanel;

            // Create events for form
            FormClosing += MainForm_FormClosing;
            MapsPanel.OnMapChanged += LoadMap;
            LayersPanel.OnLayerChanged += LoadLayer;
            TilesetsPanel.OnTilesetSelected += LoadTileset;
            TilesetPainterPanel.OnControlClick += TilesetPanel_OnControlClick;
            darkDockPanel.ContentAdded += DarkDockPanel_ContentAdded;
            darkDockPanel.ContentRemoved += DarkDockPanel_ContentRemoved;
            GamePanel.OnGameStateChanged += GamePanel_OnGameStateChanged;

            BuildViewMenu();

            ProjectsController.Instance.OnProjectChanged += InitializeProject;
            ProjectsController.Instance.LoadLastProject();

            SetMemoryTimer();

            // Maximize the form after start
            //WindowState = FormWindowState.Maximized;

            // Load all panels containing monogame controls by showing them for a while
            darkDockPanel.ActiveContent = TilesetEditorPanel;
            darkDockPanel.ActiveContent = TilesetPainterPanel;

            // Set shortcuts
            saveProjectMenuItem.ShortcutKeys = Keys.Control | Keys.S; // Save project
        }

        private void GamePanel_OnGameStateChanged(object sender, bool gameRunning)
        {
            if (gameRunning)
            {
                SaveProjectMenuItem_Click(this, null);
            }

            foreach (var window in _toolWindows.Where(window => !(window is GamePanel)))
            {
                window.Enabled = !gameRunning;
            }

            if (!gameRunning)
            {
                ProjectsController.Instance.ReloadProject();
            }
        }

        private void DarkDockPanel_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if (_toolWindows.Contains(e.Content))
                BuildViewMenu();
        }

        private void DarkDockPanel_ContentAdded(object sender, DockContentEventArgs e)
        {
            if (_toolWindows.Contains(e.Content))
                BuildViewMenu();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeDockPanel();
        }

        private void SerializeDockPanel()
        {
            var state = darkDockPanel.GetDockPanelState();
            Serialization.JsonSerialize(state, "dock.config");
        }

        private void DeserializeDockPanel()
        {
            var state = Serialization.JsonDeserialize<DockPanelState>("dock.config");
            darkDockPanel.RestoreDockPanelState(state, GetContentBySerializationKey);
        }

        private DarkDockContent GetContentBySerializationKey(string key)
        {
            foreach (var window in _toolWindows)
            {
                if (window.SerializationKey == key)
                    return window;
            }

            return null;
        }

        private void TilesetPanel_OnControlClick(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            GamePanel.ChangeSelection(rectangle);
        }

        private void LoadMap(Map map)
        {
            // Firstly, the TilesetPainterPanel loads the tilesets for the map...
            TilesetPainterPanel.LoadMap(map);
            // Than the GamePanel initializes the map...
            GamePanel.LoadMap(map);
            LayersPanel.LoadMap(map);
        }

        private void LoadLayer(BaseLayer layer)
        {
            darkDockPanel.ActiveContent = TilesetPainterPanel;
            TilesetPainterPanel.LoadLayer(layer);
            GamePanel.LoadLayer(layer);
        }

        private void LoadTileset(Tileset tileset)
        {
            TilesetEditorPanel.LoadTileset(tileset);
            darkDockPanel.ActiveContent = TilesetEditorPanel;
        }
        
        private void InitializeProject(Project project)
        {
            bool isProjectEmpty = project == null;

            if (isProjectEmpty)
            {
                currentProjectLabel.Text = "Current project: None";
            }
            else
            {
                currentProjectLabel.Text = "Current project: " + project.Name;
                Controllers.ForEach(controller => controller.InitializeProject());
            }

            // Initialize project in controllers
            // TODO Empty project should not be allowed
            // TODO Add controllers inheritance
            
            // Load content builder
            ContentBuilder.Instance.Initialize();

            // Initialize project in controls
            MapsPanel.Initialize(project == null);
            TilesetsPanel.InitializeProject(project);
            GamePanel.InitializeProject(project);
        }

        #region Memory display
        
        private void SetMemoryTimer()
        {
            var timer = new Timer {Interval = (1 * 1000)}; // 1 sec
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            using var proc = Process.GetCurrentProcess();
            memoryUsageLabel.Text = "Memory: " + proc.PrivateMemorySize64/1048576 + " MB";
        }

        #endregion

        private void OpenProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = StaticPaths.ProjectsFolder;
            openFileDialog.Filter = Resources.file_dialog_project_files;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                ProjectsController.Instance.OpenProject(openFileDialog.FileName);
        }

        private void AssetManagerButton_Click(object sender, EventArgs e)
        {
            using var assetForm = new AssetManagerForm();
            assetForm.ShowDialog();
        }

        private void NewProjectMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new CreateProject();
            form.ShowDialog();
        }

        private void SaveProjectMenuItem_Click(object sender, EventArgs e)
        {
            Controllers.ForEach(controller => controller.SaveData());
        }

        #region ToolStrip - ToolWindow Functions

        private void TilesetEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolWindow(TilesetPainterPanel);
            BuildViewMenu();
        }

        private void LayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolWindow(LayersPanel);
            BuildViewMenu();
        }

        private void GameEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolWindow(GamePanel);
            BuildViewMenu();
        }

        private void MapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleToolWindow(MapsPanel);
            BuildViewMenu();
        }
        private void ToggleToolWindow(DarkDockContent toolWindow)
        {
            if (toolWindow.DockPanel == null)
                darkDockPanel.AddContent(toolWindow);
            else
                darkDockPanel.RemoveContent(toolWindow);
        }

        private void BuildViewMenu()
        {
            tilesetEditorToolStripMenuItem.Checked = darkDockPanel.ContainsContent(TilesetPainterPanel);
            layersToolStripMenuItem.Checked = darkDockPanel.ContainsContent(LayersPanel);
            gameEditorToolStripMenuItem.Checked = darkDockPanel.ContainsContent(GamePanel);
            mapsToolStripMenuItem.Checked = darkDockPanel.ContainsContent(MapsPanel);
        }

        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var form = new WolfyForm())
            {
                form.ShowDialog();
            }
        }

        private void PlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new EntityEditForm();
            var player = new Entity(1);
            /*var comp = player.GetComponent<MovementComponent>();
                comp.Speed = 5;*/
            form.Initialize(player, World.WorldInstance);
            form.ShowDialog();
        }

        private void variablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new WolfyForm())//using (var form = new VariablesForm())
            {
                form.ShowDialog();
            }
        }

        private void lookupTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new LookupTablesForm())
            {
                form.ShowDialog();
            }
        }
    }
}
