namespace WolfyShared.Engine
{
    /// <summary>
    /// 2D vector with integer coordinates
    /// </summary>
    public struct Vector2D
    {
        public int X { get; }
        public int Y { get; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
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
    }
}
