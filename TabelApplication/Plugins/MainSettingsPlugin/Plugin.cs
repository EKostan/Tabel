using CACore.Settings;
using Core.Plugins;

namespace MainSettingsPlugin
{
    public class Plugin
    {
        [Install]
        public static void Install()
        {
        }

        [SystemInstall]
        public static void SystemInstall()
        {
            SettingsApi.AddTab(new MainSettingsPresenter());
        }

    }
}
