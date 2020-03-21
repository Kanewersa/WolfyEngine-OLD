using Microsoft.Xna.Framework;
using WolfyShared.Game;

namespace WolfyShared.Engine
{
    public delegate void LayerEventHandler(BaseLayer layer);

    public delegate void StringEventHandler(string str);

    public delegate void ControlEventHandler();

    public delegate void Vector2EventHandler(Vector2 vector);

    public delegate void EntityEventHandler(Entity entity);

    public delegate void EntityTypeEventHandler(EntityType type);

    
    //public delegate bool MovementEventHandler(Vector2 position);

    public delegate bool MovementEventHandler(Entity entity, Vector2D position);
}
