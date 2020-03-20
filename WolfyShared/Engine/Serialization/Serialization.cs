using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;
using Salar.Bois;

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
        /// Serializes object using BinaryFormatter and saves it to desired path.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        public static void BinarySerialize(object obj, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new InvalidOperationException());
            var bf = new BinaryFormatter();
            var file = File.Create(path);
            bf.Serialize(file, obj);
            file.Close();
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
            //Directory.CreateDirectory(Path.GetDirectoryName(file) ?? throw new InvalidOperationException());
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
        public static T BinaryDeserialize<T>(string path)
        {
            if(!File.Exists(path)) throw new Exception("Could not find file " + path);
            var bf = new BinaryFormatter();
            var file = File.Open(path, FileMode.Open);
            var obj = (T)bf.Deserialize(file);
            file.Close();
            return obj;
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

        public static void BoisSerialize<T>(T obj, string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? throw new InvalidOperationException());

            var serializer = new BoisSerializer();
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(obj, stream);
            }
        }

        public static T BoisDeserialize<T>(string path)
        {
            var serializer = new BoisSerializer();
            var file = File.Open(path, FileMode.Open);
            var obj = serializer.Deserialize<T>(file);
            file.Close();
            return obj;
        }
    }
}
