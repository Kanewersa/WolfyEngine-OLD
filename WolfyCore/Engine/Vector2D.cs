using System;
using Microsoft.Xna.Framework;
using ProtoBuf;

namespace WolfyShared.Engine
{
    /// <summary>
    /// 2D vector with integer coordinates
    /// </summary>
    [ProtoContract]
    public struct Vector2D
    {
        [ProtoMember(1)] public int X { get; set; }
        [ProtoMember(2)] public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static explicit operator Vector2(Vector2D vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static bool operator ==(Vector2D a, Vector2D b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector2D a, Vector2D b)
        {
            return !(a == b);
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }

        public static Vector2D operator *(Vector2D a, int b)
        {
            return new Vector2D(a.X * b, a.Y * b);
        }

        public static Vector2D operator /(Vector2D a, int b)
        {
            return new Vector2D(a.X / b, a.Y / b);
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        public bool Equals(Vector2D other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2D other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
