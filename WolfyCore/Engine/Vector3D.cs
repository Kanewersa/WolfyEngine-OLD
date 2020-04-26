using ProtoBuf;

namespace WolfyShared.Engine
{
    
    [ProtoContract]
    public struct Vector3D
    {
        [ProtoMember(1)] public int X { get; }
        [ProtoMember(2)] public int Y { get; }
        [ProtoMember(3)] public int Z { get; }

        public Vector3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator ==(Vector3D a, Vector3D b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vector3D a, Vector3D b)
        {
            return !(a == b);
        }
    }
}
