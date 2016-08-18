using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Users.Settings
{
    /// <summary>
    /// Коллекция настроек пользователя на стороне сервера.
    /// Тут хранятся сериализованные настройки.
    /// </summary>
    [Serializable]
    public class UserSettingsCollection :  ISerializeSupport, ISettings
    {
        public UserSettingsCollection()
        {

        }

        public string UserName { get; set; }

        public List<UserSettingsItemItem> _list = new List<UserSettingsItemItem>();

        [NonSerialized]
        Dictionary<string, UserSettingsItemItem> _dict = new Dictionary<string, UserSettingsItemItem>();

        public void AddSettings(UserSettingsItemItem settings)
        {
            var key = settings.SettingsType;
            _dict[key] = settings;
        }



        public UserSettingsItemItem Get(string settingsType)
        {
            var key = settingsType;

            if (!_dict.ContainsKey(key))
            {
                _dict[key] = new UserSettingsItemItem() { SettingsType = settingsType };
            }

            return _dict[key];
        }

        [OnDeserialized]

        internal void OnDeserialized(StreamingContext sc)
        {
            ((ISerializeSupport)this).Deserialized();
        }

        void ISerializeSupport.Deserialized()
        {
            _dict = new Dictionary<string, UserSettingsItemItem>();
            foreach (var item in _list)
            {
                var key = item.SettingsType;
                _dict[key] = item;
            }
        }

        [OnSerializing]
        internal void Serializing(StreamingContext sc)
        {
            ((ISerializeSupport)this).Serializing();
        }


        public void Serializing()
        {
            _list = new List<UserSettingsItemItem>(_dict.Values);
        }

        public IEnumerator<UserSettingsItemItem> GetEnumerator()
        {
            return _dict.Values.GetEnumerator();
        }

        public event EventHandler Changed;
    }
}