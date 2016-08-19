using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;
using ReferenceEditor.Employees;

namespace ReferenceEditor.Time
{
    class TimeVisualizer : Visualizer
    {
        private TimePresenter _presenter;

        public TimeVisualizer()
        {
            Name = "Табель";
            Icon = ImageGallery.TimeIcon;

            var view = new TimeControl();
            _presenter = new TimePresenter(view);
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<TimeVisualizer>();

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
