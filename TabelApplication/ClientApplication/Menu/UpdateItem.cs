using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class UpdateItem : BaseItemButton
    {
        public UpdateItem()
        {
            this.DisplayName = "��������";
            this.Icon = ImageGallery.RefreshIcon;
        }

        protected override void DoExecute()
        {
            // ��������� ��� ������� ��������� ���� ��������
            Workspace.Instance.Update();
        }

    }
}