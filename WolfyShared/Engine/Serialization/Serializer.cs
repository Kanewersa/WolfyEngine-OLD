using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;

namespace WolfyEngine.Engine
{
    public static class Serialization
    {
        /// <summary>
        /// Serializes object using Protobuf and saves it to desired path.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void ProtoSerialize(object obj, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new InvalidOperationException());
            using (var file = File.Create(path))
            {
                Serializer.Serialize(file, obj);
            }
        }

        /// <summary>
        /// Serializes object using Xml and saves it to desired path.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void XmlSerialize(object obj, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new InvalidOperationException());
            XmlSerializer xml = new XmlSerializer(obj.GetType());
            using (StreamWriter writer = new StreamWriter(path))
            {
                xml.Serialize(writer, obj);
            }
        }

        public static void JsonSerialize<T>(T obj, string file)
        {
            using (var fs = File.CreateText(file))
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(new StringEnumConverter());
                serializer.Formatting = Formatting.Indented;

                serializer.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Returns the deserialized object of given Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T ProtoDeserialize<T>(string path)
        {
            using (var file = File.OpenRead(path))
            {
                return Serializer.Deserialize<T>(file);
            }
        }

        /// <summary>
        /// Returns the deserialized object of given Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(path))
            {
                return (T)xml.Deserialize(reader);
            }
        }

        public static T JsonDeserialize<T>(string path) where T : class
        {
            using (var fs = File.OpenText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(new StringEnumConverter());

                var result = serializer.Deserialize(fs, typeof(T));
                return result as T;
            }
        }
    }
}
