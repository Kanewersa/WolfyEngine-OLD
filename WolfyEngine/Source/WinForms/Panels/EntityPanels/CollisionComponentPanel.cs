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
            _collisionComponent = entity.AddComponent<CollisionComponent>();
        }

        public override void Unload(Entity entity)
        {
            entity.RemoveComponent<CollisionComponent>();
            Close();
        }

        private void IsColliderCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            _collisionComponent.IsCollider = IsColliderCheckBox.Checked;
        }
    }
}
