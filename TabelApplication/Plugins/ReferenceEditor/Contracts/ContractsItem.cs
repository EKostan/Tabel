using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ReferenceEditor.Contracts
{
    class ContractsItem : BaseItemButton
    {
        public ContractsItem()
        {
            this.DisplayName = "Проекты и объекты";
            Icon = ImageGallery.TaskIcon;
            LargeIcon = ImageGallery.TaskIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new ContractsVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}