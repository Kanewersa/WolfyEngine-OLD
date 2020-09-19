using System;
using DarkUI.Docking;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ComponentPanel : DarkDockContent
    {
        public Type ComponentType { get; private set; }
        protected Entity Entity { get; set; }
        public ComponentPanel(Type componentType)
        {
            ComponentType = componentType;

            InitializeComponent();
        }

        public virtual void Initialize(Entity entity) { Entity = entity; }

        public virtual void Unload(Entity entity) { }

        public virtual void Save() { }
    }
}
