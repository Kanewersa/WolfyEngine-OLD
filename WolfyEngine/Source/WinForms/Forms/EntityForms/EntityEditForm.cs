using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyEngine.Controls;
using WolfyCore.ECS;
using WolfyCore.Engine;
using WolfyCore.Game;

namespace WolfyEngine.Forms
{
    public partial class EntityEditForm : DarkForm
    {
        public Entity Entity { get; private set; }
        public EntityScheme Scheme { get; private set; }
        public World World { get; private set; }

        public event EntityEventHandler OnSave;

        public bool SavedEntity;

        private List<ComponentPanel> _componentWindows = new List<ComponentPanel>();

        public EntityEditForm()
        {
            InitializeComponent();

            FormClosing += EntityEditForm_FormClosing;
        }

        private void EntityEditForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if(!SavedEntity)
                World.DestroyEntity(Entity);
        }

        public void Initialize(EntityScheme scheme, World world)
        {
            World = world;
            Scheme = scheme;

            Entity = World.CreateEntity();

            foreach (var type in scheme.ComponentTypes)
            {
                var panel = CreateComponentPanel(type, Entity);
                if (panel != null)
                    _componentWindows.Add(panel);
            }

            _componentWindows =_componentWindows.
                OrderBy(x => x.Name).ToList();

            foreach (var panel in _componentWindows)
                ComponentsDockPanel.AddContent(panel);

            DisplayEntityInfo();
        }

        public void Initialize(Entity entity, List<EntityComponent> entityComponents, World world)
        {
            World = world;
            Entity = entity;

            foreach (var component in entityComponents)
            {
                var panel = CreateComponentPanel(component, entity);
                if (panel != null)
                    _componentWindows.Add(panel);
            }

            _componentWindows = _componentWindows.
                OrderBy(x => x.Name).ToList();

            foreach (var panel in _componentWindows)
                ComponentsDockPanel.AddContent(panel);

            DisplayEntityInfo();
        }

        private void DisplayEntityInfo()
        {
            MainSection.SectionHeader =
                "Entity " + Entity.Id + "  |  " + "Name unavailable"; //Entity.Name;
            EntityNameTextBox.Text = "Name unavailable"; //Entity.Name;
            LoadComponentsList();
        }

        private ComponentPanel CreateComponentPanel(ComponentType type, Entity entity)
        {
            var panel = ComponentBinding.GetPanelInstance(type);
            panel.Initialize(entity);
            return panel;
        }

        private ComponentPanel CreateComponentPanel(EntityComponent component, Entity entity)
        {
            var componentPanel = ComponentBinding.GetPanelInstance(component);
            if (componentPanel == null) return null;
            componentPanel.Initialize(entity);
            return componentPanel;
        }

        private void RemoveComponentPanel(ComponentType type, Entity entity)
        {
            ComponentPanel panel = null;
            panel = _componentWindows.SingleOrDefault(x => x.GetType() == ComponentBinding.GetPanelType(type));
            if (panel != null)
            {
                _componentWindows.Remove(panel);
                panel.Unload(entity);
            }
        }

        private void LoadComponentsList()
        {
            ComponentsListView.Items.Clear();
            foreach (var panel in _componentWindows)
            {
                var name = panel.GetType().Name;
                name = string.Concat(name.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
                var lastSpace = name.LastIndexOf(" ", StringComparison.Ordinal);
                name = name.Substring(0, lastSpace);
                ComponentsListView.Items.Add(new DarkListItem(name));
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var panel in _componentWindows)
                panel.Save();
            
            SavedEntity = true;
            //Entity.Name = EntityNameTextBox.Text;

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

        private void DebugButton_Click(object sender, EventArgs e)
        {

        }
    }
}
