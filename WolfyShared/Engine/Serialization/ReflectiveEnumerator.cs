using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AppDomain = System.AppDomain;

namespace WolfyEngine.Engine
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
    }
}
