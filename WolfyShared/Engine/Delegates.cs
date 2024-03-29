﻿using Microsoft.Xna.Framework;
using WolfyECS;
using WolfyEngine;
using WolfyShared.Game;

namespace WolfyShared.Engine
{
    public delegate void LayerEventHandler(BaseLayer layer);

    public delegate void AssetPathHandler(string assetName, string fullPath, string extension);

    public delegate void ControlEventHandler();

    public delegate void IntEventHandler(int i);

    public delegate void EntityEventHandler(Entity entity, Vector2 position);

    public delegate void EntitySchemeHandler(EntityScheme scheme);

    public delegate void Vector2EventHandler(Vector2 vector);
}
