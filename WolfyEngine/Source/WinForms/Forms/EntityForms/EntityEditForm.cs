using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyEngine.Controls;
using WolfyShared.ECS;
using WolfyShared.Engine;
using WolfyShared.Game;

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

            Entity = World.CreateEntity("Entity " + (World.EntityCount() + 1));

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

        public void Initialize(Entity entity, List<EntityComponent> components, World world)
        {
            World = world;
            Entity = entity;

            foreach (var component in components)
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
                "Entity " + Entity.Id + "  |  " + Entity.Name;
            EntityNameTextBox.Text = Entity.Name;
            LoadComponentsList();
        }

        private ComponentPanel CreateComponentPanel(ComponentType type, Entity entity)
        {
            switch (type)
            {
                case ComponentType.Movement:
                    var panel = new MovementComponentPanel();
                    panel.Initialize(entity);
                    return panel;
                case ComponentType.Collision:
                    var panel2 = new CollisionComponentPanel();
                    panel2.Initialize(entity);
                    return panel2;
                case ComponentType.Animation:
                    var panel3 = new AnimationComponentPanel();
                    panel3.Initialize(entity);
                    return panel3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private ComponentPanel CreateComponentPanel(EntityComponent component, Entity entity)
        {
            switch (component)
            {
                case EntityComponent<MovementComponent> gc1:
                    var gpanel = new MovementComponentPanel();
                    gpanel.Initialize(entity);
                    return gpanel;
                case EntityComponent<CollisionComponent> gc2:
                    var gpanel2 = new CollisionComponentPanel();
                    gpanel2.Initialize(entity);
                    return gpanel2;
                case EntityComponent<AnimationComponent> gc3:
                    var gpanel3 = new AnimationComponentPanel();
                    gpanel3.Initialize(entity);
                    return gpanel3;
                case MovementComponent c1:
                    var panel = new MovementComponentPanel();
                    panel.Initialize(entity);
                    return panel;
                case CollisionComponent c2:
                    var panel2 = new CollisionComponentPanel();
                    panel2.Initialize(entity);
                    return panel2;
                case AnimationComponent c3:
                    var panel3 = new AnimationComponentPanel();
                    panel3.Initialize(entity);
                    return panel3;
                default:
                    return null;
            }
        }

        private void RemoveComponentPanel(ComponentType type, Entity entity)
        {
            ComponentPanel panel = null;

            switch (type)
            {
                case ComponentType.Movement:
                    panel = _componentWindows.SingleOrDefault(
                        x => x.GetType() == typeof(MovementComponentPanel));
                    break;
                case ComponentType.Collision:
                    break;
                case ComponentType.Animation:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

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
            {
                panel.Save();
            }
            SavedEntity = true;

            Entity.Name = EntityNameTextBox.Text;

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
