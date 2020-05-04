﻿using System;
using Microsoft.Xna.Framework;

namespace WolfyEngine
{
    /// <summary>
    /// Contains some helpful, not category specific methods
    /// </summary>
    public static class WolfyHelper
    {
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
            {
                return y > 0 ? 2 : 0;
            }
            return x == 1 ? 1 : 3;
        }
    }
}
