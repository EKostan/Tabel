using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ReferenceEditor.Employees
{
    class EmployeesItem : BaseItemButton
    {
        public EmployeesItem()
        {
            this.DisplayName = "Сотрудники";
            Icon = ImageGallery.ContactIcon;
            LargeIcon = ImageGallery.ContactIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new EmployeesVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}