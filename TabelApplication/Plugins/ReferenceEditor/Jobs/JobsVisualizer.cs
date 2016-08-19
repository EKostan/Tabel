using System.Collections.Generic;
using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Jobs
{
    class JobsVisualizer : Visualizer
    {
        private JobsPresenter _presenter;

        public JobsVisualizer()
        {
            Name = "Работы";
            Icon = ImageGallery.JobIcon;

            var view = new JobsControl();
            _presenter = new JobsPresenter(view); 
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<JobsVisualizer>();

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