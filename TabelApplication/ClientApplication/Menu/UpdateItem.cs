using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class UpdateItem : BaseItemButton
    {
        public UpdateItem()
        {
            DisplayName = "��������";
            Icon = ImageGallery.RefreshIcon;
            LargeIcon = ImageGallery.RefreshIcon32;
        }

        protected override void DoExecute()
        {
            // ��������� ��� ������� ��������� ���� ��������
            Workspace.Instance.Update();
        }

    }
}