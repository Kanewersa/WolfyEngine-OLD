using Microsoft.Xna.Framework;
using WolfyEngine;
using WolfyShared.Game;

namespace WolfyShared.Engine
{
    public delegate void LayerEventHandler(BaseLayer layer);

    public delegate void StringEventHandler(string str);

    public delegate void ControlEventHandler();

    public delegate void IntEventHandler(int i);

    public delegate void EntitySchemeHandler(EntityScheme scheme);

    public delegate void Vector2EventHandler(Vector2 vector);
}
