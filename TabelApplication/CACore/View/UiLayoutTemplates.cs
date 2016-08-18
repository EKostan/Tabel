using System;
using System.Collections.Generic;
using Core;

namespace CACore.View
{
    [Serializable]
    public class UiLayoutTemplates
    {
        //       journalType, 
        DictionaryExt<string, LayoutSettingsCollection> _dict = new DictionaryExt<string, LayoutSettingsCollection>();

        public void Add(string pluginTypeName, LayoutSettingsCollection layoutSettings)
        {
            _dict[pluginTypeName] = layoutSettings;
        }

        public LayoutSettingsCollection Get(string pluginTypeName)
        {
            if (!_dict.ContainsKey(pluginTypeName))
                return new LayoutSettingsCollection();

            return _dict[pluginTypeName];
        }

        public IEnumerator<LayoutSettingsCollection> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

    }
}