using System;
using System.Collections.Generic;
using System.Linq;
using DarkUI.Docking;
using DarkUI.Forms;
using WolfyECS;
using WolfyEngine.Controls;
using WolfyShared.ECS;

namespace WolfyEngine.Forms
{
    public partial class EntityEditForm : DarkForm
    {
        public Entity Entity { get; private set; }
        public EntityScheme Scheme { get; private set; }
        public World World { get; private set; }

        private List<ComponentPanel> _componentWindows = new List<ComponentPanel>();

        public EntityEditForm()
        {
            InitializeComponent();
        }

        public void Initialize(Entity entity, EntityScheme scheme, World world)
        {
            World = world;
            Scheme = scheme;
            Entity = entity;

            foreach (var type in scheme.ComponentTypes)
            {
                var panel = CreateComponentPanel(type, entity);
                if (panel != null)
                {
                    ComponentsDockPanel.AddContent(panel);
                    _componentWindows.Add(panel);
                }
            }
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
                    return null;
                case ComponentType.Animation:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
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
    }
}
