using System;
using System.Xml.Serialization;

namespace Core.Users.Autentification
{
    [Serializable]
    public class User
    {
        public User()
        {
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [XmlElement]
        public string SamName { get; set; }

        /// <summary>
        /// Отображаемое имя пользователя
        /// </summary>
        [XmlElement]
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return SamName + " " + DisplayName;
        }


        [XmlElement]
        public string Id { get; set; }

        /// <summary>
        /// Функция генерации уникального ключа для пользователя
        /// </summary>
        /// <returns></returns>
        public static string GenerateUserId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}