using System;

namespace Core.Users.Settings
{
    /// <summary>
    /// Класс хранит сериализованный класс с настройками пользователя
    /// </summary>
    [Serializable]
    public class UserSettingsItemItem : ISettings
    {
        public string SettingsType { get; set; }

        public byte[] XmlSerializedData { get; set; }
        public event EventHandler Changed;
    }
}