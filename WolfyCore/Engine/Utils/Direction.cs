using System;
using Microsoft.Xna.Framework;

namespace WolfyCore
{
    public static class Direction
    {
        /// <summary>
        /// Translates Vector2 to int direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int Get(Vector2 direction)
        {
            var x = (int)direction.X;
            var y = (int)direction.Y;

            if (x == 0)
                return y > 0 ? 0 : 3;
            return x == 1 ? 2 : 1;
        }

        /// <summary>
        /// Translates int to Vector2 direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2 Get(int direction)
        {
            switch (direction)
            {
                case 0:
                    return new Vector2(0, 1);
                case 1:
                    return new Vector2(-1, 0);
                case 2:
                    return new Vector2(1, 0);
                case 3:
                    return new Vector2(0, -1);
                default:
                    throw new ArgumentOutOfRangeException("Unknown direction given.");
            }
        }

        /// <summary>
        /// Translates string to int direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int Get(string direction)
        {
            var c = direction[0];

            return c switch
            {
                'T' => 0,
                'R' => 1,
                'B' => 2,
                'L' => 3,
                _ => throw new ArgumentOutOfRangeException("Unknown direction.")
            };
        }

        /// <summary>
        /// Returns the opposite direction to given vector.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2 Reverse(Vector2 direction)
        {
            return direction * -1;
        }

        /// <summary>
        /// Returns the opposite direction to given integer direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int Reverse(int direction)
        {
            switch (direction)
            {
                case 0:
                    return 3;
                case 3:
                    return 0;
                case 1:
                    return 2;
                case 2:
                    return 1;
                default:
                    return -1;
            }
        }
    }
}
