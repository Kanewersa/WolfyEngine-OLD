using System;
using System.Collections.Generic;
using System.Linq;
using AppDomain = System.AppDomain;

namespace WolfyEngine
{
    public static class ReflectiveEnumerator
    {
        public static List<Type> GetSubTypes<T>(params object[] constructorArgs)
            where T : class
        {
            var subTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => type.IsClass
                               && !type.IsGenericType
                               && !type.IsAbstract
                               && type.IsSubclassOf(typeof(T)))
                .ToList();
            return subTypes;
        }

        public static int GetUniqueId(string s)
        {
            string str = s;
            if (str.EndsWith("Component"))
                str = str.Substring(0, str.Length - 9);

            str = str.ToUpper();
            var length = str.Length;
            int id = 0;
            
            for (int i = 0; i < length; i++)
            {
                id += GetCharId(str[i]) * i;
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
                'V' => 21,
                'W' => 22,
                'X' => 23,
                'Y' => 24,
                'Z' => 25,
                _ => throw new ArgumentOutOfRangeException("Unknown character.")
            };
        }
    }
}
