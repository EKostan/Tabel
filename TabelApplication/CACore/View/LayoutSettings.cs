using System;

namespace CACore.View
{
    /// <summary>
    /// Шаблон настроек для UI пользователя
    /// </summary>
    [Serializable]
    public class LayoutSettings
    {
        /// <summary>
        /// Имя шаблона
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сериализованные данные шаблона
        /// </summary>
        public byte[] SerializationData { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
