using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AppDomain = System.AppDomain;

namespace WolfyEngine
{
    public static class ReflectiveEnumerator
    {
        public static List<Type> GetSubTypes<T>(params object[] constructorArgs)
            where T : class
        {
            List<Type> subTypes = new List<Type>();

            try
            {
                subTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(type => type.IsClass
                                   && !type.IsGenericType
                                   && !type.IsAbstract
                                   && type.IsSubclassOf(typeof(T)))
                    .ToList();
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                throw new Exception(errorMessage);
            }

            
            return subTypes;
        }
    }
}
