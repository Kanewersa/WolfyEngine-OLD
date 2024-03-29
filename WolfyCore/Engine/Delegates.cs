﻿using Microsoft.Xna.Framework;
using WolfyCore.Game;
using WolfyECS;
using WolfyEngine;

namespace WolfyCore.Engine
{
    public delegate void LayerEventHandler(BaseLayer layer);

    public delegate void AssetPathHandler(string assetName, string fullPath, string relativePath, string extension);

    public delegate void ControlEventHandler();

    public delegate void IntEventHandler(int i);

    public delegate void EntityEventHandler(Entity entity, Vector2 position);

    public delegate void EntitySchemeHandler(EntityScheme scheme);

    public delegate void TransformEvent(int mapId, Vector2 transform);
}
