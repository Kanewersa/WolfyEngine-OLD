using System;
using System.IO;
using Microsoft.Xna.Framework;

namespace WolfyEngine
{
    /// <summary>
    /// Contains some helpful, not category specific methods
    /// </summary>
    public static class WolfyHelper
    {
        /// <summary>
        /// Returns true if file is being written to, doesn't exist or is being used by another process.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        public static int GetUniqueInt(string str)
        {
            if(str == null)
                throw new NullReferenceException("Given string was null.");

            if(str.Length < 5)
                throw new Exception("This word should have more than 5 characters: " + str);

            str = str.ToUpper(); 
            var space = 0;

            space = str.Length < 10 ? 0 : 1;
            space = str.Length < 15 ? space : 2;

            var currentSpace = 0;

            var id = 1;
            var iterations = 5;
            foreach (var ch in str)
            {
                if (space != 0 && currentSpace == space)
                {
                    currentSpace = 0;
                    continue;
                }

                id *= GetCharId(ch);

                currentSpace++;
                iterations--;
                if (iterations == 0) break;
            }

            return id;
        }

        private static int GetCharId(char ch)
        {
            return ch switch
            {
                'A' => 1,
                'B' => 2,
                'C' => 3,
                'D' => 4,
                'E' => 5,
                'F' => 6,
                'G' => 7,
                'H' => 8,
                'I' => 9,
                'J' => 10,
                'K' => 11,
                'L' => 12,
                'M' => 13,
                'N' => 14,
                'O' => 15,
                'P' => 16,
                'Q' => 17,
                'R' => 18,
                'S' => 19,
                'T' => 20,
                'U' => 21,
                'V' => 22,
                'W' => 23,
                'X' => 24,
                'Y' => 25,
                'Z' => 26,
                _ => throw new ArgumentOutOfRangeException("Unknown character used: " + ch)
            };
        }

        /// <summary>
        /// Translates Vector2 to int direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static int GetDirection(Vector2 direction)
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
        public static Vector2 GetDirection(int direction)
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
        public static int GetDirection(string direction)
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

        public static Random Random = new Random();

        /// <summary>
        /// Roles a number based on chance modifier.
        /// </summary>
        /// <param name="chanceModifier">The chance of rolling 'true' (reciprocal).
        /// e.g. 2 => 50%, 3 => 33%, 4 => 25% etc.</param>
        /// <returns>True if chance modifier was rolled. False otherwise.</returns>
        public static bool RollChance(int chanceModifier)
        {
            int rInt = Random.Next(1, chanceModifier);

            if (rInt == chanceModifier) return true;
            
            return false;
        }
    }
}
