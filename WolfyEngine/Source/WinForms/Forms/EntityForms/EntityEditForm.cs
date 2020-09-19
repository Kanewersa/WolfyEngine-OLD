using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Controls;
using WolfyCore.Engine;

namespace WolfyEngine.Forms
{
    public partial class EntityEditForm : WolfyForm
    {
        public Entity Entity { get; private set; }
        public EntityScheme Scheme { get; private set; }
        public World World { get; private set; }

        public event EntityEventHandler OnSave;

        public bool SavedEntity;

        private Dictionary<DarkListItem, ComponentPanel> ListViewComponentBinding { get; set; }
        private List<Type> PresentComponents { get; set; }
        private List<ComponentPanel> ComponentWindows { get; set; } = new List<ComponentPanel>();
        private List<ComponentPanel> RemovedWindows { get; set; } = new List<ComponentPanel>();
        private int SelectedItemIndex { get; set; }
        private DarkListItem SelectedItem => ComponentsListView.Items[SelectedItemIndex];

        public EntityEditForm()
        {
            InitializeComponent();
            PresentComponents = new List<Type>();
            ListViewComponentBinding = new Dictionary<DarkListItem, ComponentPanel>();
            FormClosing += EntityEditForm_FormClosing;
        }

        private void EntityEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!SavedEntity)
                World.DestroyEntity(Entity);
        }

        public void Initialize(EntityScheme scheme, World world, TransformComponent transform)
        {
            World = world;
            Scheme = scheme;

            Entity = World.CreateEntity();
            Entity.AddComponent(transform);

            LoadPanels(scheme.ComponentTypes, Entity);
        }

        public void Initialize(Entity entity, World world)
        {
            World = world;
            Entity = entity;

            var componentTypes = entity.GetComponents().Select(x => x.GetType()).ToList();

            LoadPanels(componentTypes, entity);
        }

        private void LoadPanels(List<Type> types, Entity entity)
        {
            foreach (var type in types)
            {
                AddComponentPanel(type);
            }

            SetDockContent();
            LoadComponentsList();
            ResetAddComponentStrip();
            DisplayEntityInfo();
        }

        /// <summary>
        /// Adds all component windows to dock panel.
        /// </summary>
        private void SetDockContent()
        {
            ComponentWindows = ComponentWindows.
                OrderBy(x => x.Name).ToList();

            foreach (var panel in ComponentWindows)
                ComponentsDockPanel.AddContent(panel);

            ComponentsDockPanel.ActiveContent = ComponentWindows.First();

            ComponentsDockPanel.ContentAdded += delegate(object sender, DockContentEventArgs args)
            {
                ComponentsDockPanel.ActiveContent = args.Content;
            };
        }

        /// <summary>
        /// Displays the name and id of the entity in the header.
        /// </summary>
        private void DisplayEntityInfo()
        {
            string name = "";

            if (Entity.GetIfHasComponent(out InGameNameComponent component))
                name = component.Name;
            
            MainSection.SectionHeader =
                "Entity " + Entity.Id + "  |  " + name;
            EntityNameTextBox.Text = name;
        }

        /// <summary>
        /// Creates components list from component windows.
        /// </summary>
        private void LoadComponentsList()
        {
            ComponentsListView.Items.Clear();
            ListViewComponentBinding.Clear();

            foreach (var panel in ComponentWindows.OrderBy(x => x.ComponentType.Name))
            {
                var name = panel.GetType().Name;
                name = string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
                var lastSpace = name.LastIndexOf(" ", StringComparison.Ordinal);
                name = name.Substring(0, lastSpace);
                var item = new DarkListItem(name);
                ComponentsListView.Items.Add(item);
                ListViewComponentBinding.Add(item, panel);
            }
        }

        /// <summary>
        /// Saves the entity and all it's components.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Unload all removed windows
            foreach (var panel in RemovedWindows)
                panel.Unload(Entity);

            // Save all panels
            foreach (var panel in ComponentWindows)
                panel.Save();

            SavedEntity = true;
            if (EntityNameTextBox.Text.Length > 0)
                Entity.GetOrCreateComponent<InGameNameComponent>().Name = EntityNameTextBox.Text;
            else Entity.RemoveComponent<InGameNameComponent>();

            OnSave?.Invoke(Entity, Vector2.Zero);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EntityNameTextBox_TextChanged(object sender, EventArgs e)
        {
            MainSection.SectionHeader =
                "Entity " + Entity.Id + "  |  " + EntityNameTextBox.Text;
        }

        /// <summary>
        /// Creates the list of components in drop down strip.
        /// </summary>
        private void ResetAddComponentStrip()
        {
            AddComponentStrip.DropDownItems.Clear();
            var notPresentTypes = ComponentBinding.DefinedTypes().Except(PresentComponents);

            foreach (var type in notPresentTypes)
            {
                ToolStripItem item = new ToolStripMenuItem(SplitByCapital(type.Name));
                item.Click += delegate
                {
                    var panel = AddComponentPanel(type);
                    if (panel == null)
                        throw new NullReferenceException("Components panel was not successfully created.");
                    
                    ComponentsDockPanel.AddContent(panel);
                    ResetAddComponentStrip();
                    LoadComponentsList();
                };
                AddComponentStrip.DropDownItems.Add(item);
            }

            if (AddComponentStrip.DropDownItems.Count == 0)
            {
                AddComponentStrip.DropDownItems.Add("No available components.");
            }
        }

        /// <summary>
        /// Creates the component panel of given type.
        /// </summary>
        /// <param name="type"></param>
        private ComponentPanel AddComponentPanel(Type type)
        {
            var panel = ComponentBinding.GetPanelInstance(type);
            if (panel == null) return null;
            PresentComponents.Add(type);
            ComponentWindows.Add(panel);
            panel.Initialize(Entity);
            return panel;
        }

        private string SplitByCapital(string input)
        {
            var output = "";

            foreach (var letter in input)
            {
                if (char.IsUpper(letter) && output.Length > 0)
                    output += " " + letter;
                else output += letter;
            }

            return output;
        }

        private void ComponentsListClick(object sender, MouseEventArgs e)
        {
            // Check if cursor was clicked over an item in a list.
            var cursorOnItem = ComponentsListView.ItemHeight * ComponentsListView.Items.Count >= e.Y;
            if (!cursorOnItem) return;

            if (e.Button == MouseButtons.Right)
            {
                SelectedItemIndex = e.Y / ComponentsListView.ItemHeight;
                ComponentsListView.SelectItem(SelectedItemIndex);
                ComponentContextMenu.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                SelectedItemIndex = e.Y / ComponentsListView.ItemHeight;
                ComponentsDockPanel.ActiveContent = ListViewComponentBinding[SelectedItem];
            }
        }

        private void RemoveComponentMenuItem_Click(object sender, EventArgs e)
        {
            var result = DarkMessageBox.ShowWarning("Are you sure you want to delete this component? All its content will be lost.",
                "Confirmation prompt.",
                DarkDialogButton.YesNo);

            if (result == DialogResult.Yes)
            {
                var panel = ListViewComponentBinding[SelectedItem];

                // Add panel to removed windows.
                RemovedWindows.Add(panel);
                // Remove panel from windows list.
                ComponentWindows.Remove(panel);
                // Remove panel from dock panel.
                ComponentsDockPanel.RemoveContent(panel);
                // Remove component type from present components.
                PresentComponents.Remove(panel.ComponentType);
                // Reset components list
                LoadComponentsList();

                ResetAddComponentStrip();
            }
        }

        private void ShowComponentMenuItem_Click(object sender, EventArgs e)
        {
            var panel = ListViewComponentBinding[SelectedItem];

            if (!ComponentsDockPanel.ContainsContent(panel))
                ComponentsDockPanel.AddContent(panel);
            
            ComponentsDockPanel.ActiveContent = panel;
        }
    }
}
