using System;

namespace Core.Users.Autentification
{
    [Serializable]
    public class Rule : IRule
    {
        public bool CheckSid(string sid)
        {
            if (string.IsNullOrEmpty(Sid))
                return false;

            return Sid.Equals(sid);
        }

        public bool CheckKey(string key)
        {
            if (string.IsNullOrEmpty(Key))
                return false;

            return Key.Equals(key);
        }

        /// <summary>
        /// Уникальный идентификатор правила. Для сервисов это имя метода сервиса. Для данных это тип данных.
        /// </summary>
        public string Key { get; set; }

        public string Sid { get; set; }

        /// <summary>
        /// Отображаемое имя правила
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        
    }



}