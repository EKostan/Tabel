using CACore.Menu;
using ClientApplication.Api;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class SettingsItem : BaseItemButton
    {
        public SettingsItem()
        {
            DisplayName = "Настройки";
            Icon = ImageGallery.PropertiesIcon;
            LargeIcon = ImageGallery.PropertiesIcon32;
        }


        protected override void DoExecute()
        {
            SystemApi.ShowSettingsDialog();
        }

    }
}