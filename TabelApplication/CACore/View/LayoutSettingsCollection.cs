using System;
using System.Collections.Generic;
using Core;

namespace CACore.View
{
    [Serializable]
    public class LayoutSettingsCollection
    {

        private DictionaryExt<string, LayoutSettings> _dict = new DictionaryExt<string, LayoutSettings>();

        //private LayoutSettings _currentLayoutSettings;
        public string CurrentKey { get; set; }

        public LayoutSettings CurrentLayoutSettings
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentKey) && _dict.ContainsKey(CurrentKey))
                    return _dict[CurrentKey];

                return null;
                //return _currentLayoutSettings;
            }
            set
            {
                CurrentKey = value.Name;
                //_currentLayoutSettings = value;
            }
        }

        public void Add(LayoutSettings layoutSettings)
        {
            _dict[layoutSettings.Name] = layoutSettings;
        }

        public LayoutSettings Get(string templateName)
        {
            if (!_dict.ContainsKey(templateName))
                return null;

            return _dict[templateName];
        }

        public IEnumerator<LayoutSettings> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        public void Remove(List<LayoutSettings> list)
        {
            foreach (var layoutSettings in list)
            {
                if(_dict.ContainsKey(layoutSettings.Name))
                    _dict.Remove(layoutSettings.Name);
            }
        }

    }
}