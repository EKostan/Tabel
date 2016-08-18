using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core
{
    /// <summary>
    /// Объект содержит в себе вспомогательные методы для сериализации и десериализации
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Сериализует объект obj в XML формате и возвращает строку, которая содержит в себе сериализованные данные
        /// </summary>
        /// <typeparam name="T">Тип сериализуемого объекта</typeparam>
        /// <param name="obj">Сериализуемый объект</param>
        /// <returns>Возвращает строку, которая содержит в себе сериализованные данные</returns>
        public static string SerializeXmlToString<T>(T obj)
        {
            return SerializeXmlToString(typeof(T), obj);
        }

        /// <summary>
        /// Сериализует объект obj в XML формате и возвращает строку, которая содержит в себе сериализованные данные
        /// </summary>
        /// <param name="type">Тип сериализуемого объекта</param>
        /// <param name="obj">Сериализуемый объект</param>
        /// <returns>Возвращает строку, которая содержит в себе сериализованные данные</returns>
        public static string SerializeXmlToString(Type type, object obj)
        {
            var iSerializeSupport = obj as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Serializing();
            }

            var ser = new XmlSerializer(type);
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriterWithEncoding(sb, Encoding.UTF8))
            {
                ser.Serialize(writer, obj);
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// Сериализует объект obj в XML формате и записывает в файл сериализованные данные
        /// </summary>
        /// <typeparam name="T">Тип сериализуемого объекта</typeparam>
        /// <param name="serializeFileName">Путь к файлу, куда надо сохранить сериализованные данные</param>
        /// <param name="obj">Сериализуемый объект</param>
        public static void SerializeXmlToFile<T>(string serializeFileName, T obj)
        {
            try
            {
                var iSerializeSupport = obj as ISerializeSupport;

                if (iSerializeSupport != null)
                {
                    iSerializeSupport.Serializing();
                }

                var ser = new XmlSerializer(typeof(T));

                using (var f = new FileStream(serializeFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (TextWriter writer = new StreamWriter(f, Encoding.UTF8))
                    {
                        ser.Serialize(writer, obj);
                    }
                }
            }
            catch (Exception)
            {
                // надо разобраться почему может быть отказ прав доступа к общедоступной директории пользователей
            }
        }

        /// <summary>
        /// Сериализует объект obj в бинарном формате и возвращает массив байтов, который содержит в себе сериализованные данные
        /// </summary>
        /// <param name="obj">Сериализуемый объект</param>
        /// <returns>Возвращает массив байтов, который содержит в себе сериализованные данные</returns>
        public static byte[] SerializeBin(object obj)
        {
            var iSerializeSupport = obj as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Serializing();
            }

            var ser = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// Сериализует объект obj в бинарном формате и сохраняет массив байтов, 
        /// который содержит в себе сериализованные данные,  в файл
        /// </summary>
        /// <param name="serializeFileName">Путь к файлу, куда надо сохранить сериализованные данные</param>
        /// <param name="type">Тип сериализуемого объекта</param>
        /// <param name="obj">Сериализуемый объект</param>
        public static void SerializeBinToFile(string serializeFileName, Type type, object obj)
        {
            var iSerializeSupport = obj as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Serializing();
            }

            var ser = new BinaryFormatter();

            using (FileStream ms = new FileStream(serializeFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                ser.Serialize(ms, obj);
            }

        }

        /// <summary>
        /// Сериализует объект obj в бинарном формате и возвращает строку, которая содержит в себе сериализованные данные
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeBinToString(Type type, object obj)
        {
            var iSerializeSupport = obj as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Serializing();
            }

            var ser = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                ser.Serialize(ms, obj);
                var bytes = ms.GetBuffer();
                return ByteArrayToString(bytes);
            }
        }




        
        /// <summary>
        /// Десериализовать объект из Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeXml<T>(string xml)
            where T : class
        {
            return DeserializeXml(typeof (T), xml) as T;
        }

        public static object DeserializeXml(Type type, string xml)
        {
            var ser = new XmlSerializer(type);
            object res = null;

            var bytes = Encoding.UTF8.GetBytes(xml);
            using (var memoryStream = new MemoryStream(bytes))
            {
                res = ser.Deserialize(memoryStream);
            }


            var iSerializeSupport = res as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Deserialized();
            }

            return res;
        }

        public static T DeserializeXml<T>(XmlReader xmlReader)
        {
            var ser = new XmlSerializer(typeof(T));
            T res = (T)ser.Deserialize(xmlReader);

            var iSerializeSupport = res as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Deserialized();
            }

            return res;
        }

        public static object DeserializeBin(byte[] bytes)
        {
            object res;

            var ser = new BinaryFormatter();

            using (MemoryStream f = new MemoryStream(bytes))
            {
                res = ser.Deserialize(f);
            }

            var iSerializeSupport = res as ISerializeSupport;

            if (iSerializeSupport != null)
            {
                iSerializeSupport.Deserialized();
            }

            return res;
        }

        public static object DeserializeBinFromFile(string serializeFileName)
        {
            var bytes = File.ReadAllBytes(serializeFileName);

            return DeserializeBin(bytes);
        }

        public static T DeserializeBinFromFile<T>(string serializeFileName) 
            where T : class
        {
            var bytes = File.ReadAllBytes(serializeFileName);
            return DeserializeBin(bytes) as T;
        }






      

        /// <summary>
        /// Возвращает MemoryStream для строки xml
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static MemoryStream CreateMemoryStream(string xml)
        {
            var memoryStream = new MemoryStream((byte[])StringToByteArray(xml));
            return memoryStream;
        }

        /// <summary>
        /// Конвертирует xmlString в массив байтов в кодировке 
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static Byte[] StringToByteArray(string xmlString)
        {
            var encoding = new UTF8Encoding();

            var byteArray = encoding.GetBytes(xmlString);
            return byteArray;
        }

        public static string ByteArrayToString(byte[] array)
        {
            return array != null ? Encoding.UTF8.GetString(array) : string.Empty;
        }

        public static T CopyObject<T>(T obj) 
            where T: class 
        {
            var xml = SerializeXmlToString<T>(obj);
            return DeserializeXml<T>(xml);
        }

       
    }
}
