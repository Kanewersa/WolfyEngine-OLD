using Microsoft.Xna.Framework;
using ProtoBuf;
using WolfyECS;

namespace WolfyCore.ECS
{
    [ProtoContract]
    public class PathRequestComponent : EntityComponent
    {
        [ProtoMember(1)] public int StartingMap { get; private set; }
        [ProtoMember(2)] public int TargetMap { get; private set; }
        [ProtoMember(3)] public Vector2 Start { get; private set; }
        [ProtoMember(4)] public Vector2 End { get; private set; }

        public PathRequestComponent() { }

        public PathRequestComponent(int startingMap, int targetMap, Vector2 start, Vector2 end)
        {
            StartingMap = startingMap;
            TargetMap = targetMap;
            Start = start;
            End = end;
        }
    }
}