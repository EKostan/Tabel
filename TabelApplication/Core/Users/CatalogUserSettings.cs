using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Users.Settings;

namespace Core.Users
{
    [Serializable]
    public class CatalogUserSettings : ISerializeSupport, ISettings
    {
        public CatalogUserSettings()
        {
        }

        List<UserSettingsCollection> _list = new List<UserSettingsCollection>();

        [NonSerialized]
        Dictionary<string, UserSettingsCollection> _dict = new Dictionary<string, UserSettingsCollection>();

        public void AddSettings(UserSettingsCollection settings)
        {
            if (settings == null)
                return;

            _dict[settings.UserName] = settings;
        }

        public UserSettingsCollection GetSettings(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            if (!_dict.ContainsKey(userName))
                _dict[userName] = new UserSettingsCollection() { UserName = userName };

            return _dict[userName];
        }

        [OnDeserialized]

        internal void OnDeserialized(StreamingContext sc)
        {
            ((ISerializeSupport)this).Deserialized();
        }

        void ISerializeSupport.Deserialized()
        {
            _dict = new Dictionary<string, UserSettingsCollection>();
            foreach (var item in _list)
            {
                _dict[item.UserName] = item;
            }
        }

        [OnSerializing]
        internal void Serializing(StreamingContext sc)
        {
            ((ISerializeSupport)this).Serializing();
        }


        public void Serializing()
        {
            _list = new List<UserSettingsCollection>(_dict.Values);
        }


        public event EventHandler Changed;
    }
}