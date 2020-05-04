using Microsoft.Xna.Framework;

namespace WolfyCore.Engine
{
    public static class Random
    {
        public static Vector2 GetRandomDirection()
        {
            var random = new System.Random();
            var values = new[] {new Vector2(0,-1), new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0) };
            return values[random.Next(values.Length)];
        }
    }
}
