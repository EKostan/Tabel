using System.Collections.Generic;

namespace CACore.Settings
{
    public class SettingsApi
    {
        static List<ISettingsTab> _tabs = new List<ISettingsTab>();

        public static void AddTab(ISettingsTab tab)
        {
            _tabs.Add(tab);
            
        }

        public static List<ISettingsTab> SettingsTabs
        {
            get { return new List<ISettingsTab>(_tabs); }
        }

    }
}