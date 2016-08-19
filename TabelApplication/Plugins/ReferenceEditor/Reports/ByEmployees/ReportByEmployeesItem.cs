using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ReferenceEditor.Reports.ByEmployees
{
    class ReportByEmployeesItem : BaseItemButton
    {
        public ReportByEmployeesItem()
        {
            this.DisplayName = "Отчет по сотрудникам";
            Icon = ImageGallery.ReportIcon;
            LargeIcon = ImageGallery.ReportIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new ReportByEmployeesVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}