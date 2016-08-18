using CACore.Menu;
using ClientApplication.Api;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class ExitItem : BaseItemButton
    {
        public ExitItem()
        {
            this.DisplayName = "Выход";
            this.Icon = ImageGallery.CloseIcon;
        }


        protected override void DoExecute()
        {
            SystemApi.Exit();
        }

    }
}
