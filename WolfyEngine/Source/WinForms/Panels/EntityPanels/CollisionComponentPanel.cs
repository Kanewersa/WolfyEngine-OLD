﻿using System;
using WolfyECS;
using WolfyShared.ECS;

namespace WolfyEngine.Controls
{
    public partial class CollisionComponentPanel : ComponentPanel
    {
        private CollisionComponent _collisionComponent;

        public CollisionComponentPanel()
        {
            InitializeComponent();
        }

        public override void Initialize(Entity entity)
        {
            Entity = entity;

            if (entity.HasComponent<CollisionComponent>())
            {
                _collisionComponent = Entity.GetComponent<CollisionComponent>();

                IsColliderCheckBox.Checked = _collisionComponent.IsCollider;
            }
            else
            {
                IsColliderCheckBox.Checked = true;
            }
        }

        public override void Save()
        {
            _collisionComponent = Entity.GetIfHasComponent<CollisionComponent>();

            _collisionComponent.IsCollider = IsColliderCheckBox.Checked;
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<CollisionComponent>();
            Close();
        }
    }
}
