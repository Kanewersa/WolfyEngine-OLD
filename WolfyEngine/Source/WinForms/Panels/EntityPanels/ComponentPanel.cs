﻿using DarkUI.Docking;
using WolfyECS;

namespace WolfyEngine.Controls
{
    public partial class ComponentPanel : DarkToolWindow
    {
        protected Entity Entity { get; set; }
        public ComponentPanel()
        {
            InitializeComponent();
        }

        public virtual void Initialize(Entity entity) { }

        public virtual void Unload(Entity entity) { }

        public virtual void Save() { }
    }
}
