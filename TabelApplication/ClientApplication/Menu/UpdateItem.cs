using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class UpdateItem : BaseItemButton
    {
        public UpdateItem()
        {
            DisplayName = "Обновить";
            Icon = ImageGallery.RefreshIcon;
            LargeIcon = ImageGallery.RefreshIcon32;
        }

        protected override void DoExecute()
        {
            // обновляем все текущие настройки всех плагинов
            Workspace.Instance.Update();
        }

    }
}