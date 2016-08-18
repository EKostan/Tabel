using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Users.Settings
{
    [Serializable]
    public class UserSettings : ISerializeSupport
    {
        public UserSettings()
        {

        }

        public string UserName { get; set; }

        List<object> _list = new List<object>();

        [NonSerialized]
        Dictionary<string, object> _dict = new Dictionary<string, object>();

        public void AddSettings(object settings)
        {
            var key = settings.GetType().ToString();
            _dict[key] = settings;
        }

       

        public T Get<T>()
            where T : class, new() 
        {
            var key = typeof (T).ToString();

            if (!_dict.ContainsKey(key))
            {
                _dict[key] = new T();
            }    
                
            return _dict[key] as T;
        }



        [OnDeserialized]

        internal void OnDeserialized(StreamingContext sc)
        {
            ((ISerializeSupport) this).Deserialized();
        }

        void ISerializeSupport.Deserialized()
        {
            _dict = new Dictionary<string, object>();
            foreach (var item in _list)
            {
                var key = item.GetType().ToString();
                _dict[key] = item;
            }
        }

        [OnSerializing]
        internal void Serializing(StreamingContext sc)
        {
            ((ISerializeSupport) this).Serializing();
        }


        public void Serializing()
        {
            _list = new List<object>(_dict.Values);
        }

        public void ApplySettings(UserSettings settings)
        {
            foreach (var item in settings._dict)
            {
                var type = item.Value.GetType();

                _dict[type.ToString()] = item.Value;
            }

            OnChanged();
        }

        [field:NonSerialized]
        public event EventHandler Changed;

        protected virtual void OnChanged()
        {
            var handler = Changed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public static UserSettings DeserializeUserSettings(UserSettingsCollection collection)
        {
            var userSettings = new UserSettings();

            foreach (var item in collection)
            {
                if (!_dictUserSettingsTypes.ContainsKey(item.SettingsType))
                    continue;

                var type = _dictUserSettingsTypes[item.SettingsType];
                var obj = Serializer.DeserializeBin(item.XmlSerializedData);
                userSettings.AddSettings(obj);
            }

            return userSettings;
        }


        public static UserSettingsCollection SerializeUserSettings(UserSettings settings)
        {
            var res = new UserSettingsCollection {UserName = settings.UserName};

            foreach (var item in settings)
            {
                var type = item.GetType();
                var typeString = type.ToString();

                if (!_dictUserSettingsTypes.ContainsKey(typeString))
                    continue;

                var s = Serializer.SerializeBin(item);
                res.AddSettings(new UserSettingsItemItem() { SettingsType = typeString, XmlSerializedData = s });
            }

            return res;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return _dict.Values.GetEnumerator();
        }


        static Dictionary<string, Type> _dictUserSettingsTypes = new Dictionary<string, Type>();

        public static void Register<T>()
        {
            var type = typeof (T);
            _dictUserSettingsTypes[type.ToString()] = type;
        }
    }
}
