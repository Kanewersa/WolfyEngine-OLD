using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract] public class TransformComponent : EntityComponent
    {
        [ProtoMember(1)] public Vector2 Transform;
        [ProtoMember(2)] public Vector2 GridTransform;
        [ProtoMember(3)] public int CurrentMap;

        public TransformComponent() { }
    }
}