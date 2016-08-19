using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Reports.ByEmployees
{
    class ReportByEmployeesVisualizer : Visualizer
    {
        private ReportByEmployeesPresenter _presenter;

        public ReportByEmployeesVisualizer()
        {
            Name = "Отчет по сотрудникам";
            Icon = ImageGallery.ReportIcon;

            var view = new ReportByEmployeesControl();
            _presenter = new ReportByEmployeesPresenter(view); 
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<ReportByEmployeesVisualizer>();

            if (!Equals(vis, this))
                return;

            _presenter.ReloadData();
        }

        public override void Dispose()
        {
            Workspace.Instance.Updated -= Instance_Updated;

            _presenter.Dispose();
        }
    }
}