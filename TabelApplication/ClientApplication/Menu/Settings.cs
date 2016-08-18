using CACore.Menu;
using ClientApplication.Api;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class SettingsItem : BaseItemButton
    {
        public SettingsItem()
        {
            this.DisplayName = "Настройки";
            this.Icon = ImageGallery.SettingsIcon;
        }


        protected override void DoExecute()
        {
            SystemApi.ShowSettingsDialog();
        }

    }
}