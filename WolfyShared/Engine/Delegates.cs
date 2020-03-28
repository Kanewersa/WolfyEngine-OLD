using Microsoft.Xna.Framework;
using WolfyShared.Game;

namespace WolfyShared.Engine
{
    public delegate void LayerEventHandler(BaseLayer layer);

    public delegate void StringEventHandler(string str);

    public delegate void ControlEventHandler();

    public delegate void Vector2EventHandler(Vector2 vector);
}
