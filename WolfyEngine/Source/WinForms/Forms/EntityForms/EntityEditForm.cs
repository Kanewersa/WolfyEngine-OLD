using System;
using System.Collections.Generic;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyCore.ECS;
using WolfyECS;
using WolfyEngine.Controls;
using WolfyCore.Engine;

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
                var panel = ComponentBinding.GetPanelInstance(type);
                if (panel == null) continue;
                panel.Initialize(entity);
                _componentWindows.Add(panel);
            }

            SetDockContent();
            DisplayEntityInfo();
        }

        private void SetDockContent()
        {
            _componentWindows = _componentWindows.
                OrderBy(x => x.Name).ToList();

            foreach (var panel in _componentWindows)
                ComponentsDockPanel.AddContent(panel);

            ComponentsDockPanel.ActiveContent = _componentWindows.First();
        }

        private void DisplayEntityInfo()
        {
            string name = "";

            if (Entity.GetIfHasComponent(out InGameNameComponent component))
                name = component.Name;
            
            MainSection.SectionHeader =
                "Entity " + Entity.Id + "  |  " + name;
            EntityNameTextBox.Text = name;
            LoadComponentsList();
        }

        private void RemoveComponentPanel(EntityComponent component, Entity entity)
        {
            // TODO: Add component panels removal in entity edit form.
            /*ComponentPanel panel = null;
            panel = _componentWindows.SingleOrDefault(
                x => x.GetType() == ComponentBinding.GetPanelType(component));
            if (panel != null)
            {
                _componentWindows.Remove(panel);
                panel.Unload(entity);
            }*/
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
    }
}
