using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class UpdateItem : BaseItemButton
    {
        public UpdateItem()
        {
            this.DisplayName = "Обновить";
            this.Icon = ImageGallery.RefreshIcon;
        }

        protected override void DoExecute()
        {
            // обновляем все текущие настройки всех плагинов
            Workspace.Instance.Update();
        }

    }
}