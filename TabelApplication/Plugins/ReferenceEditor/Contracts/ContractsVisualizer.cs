using System.Collections.Generic;
using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Contracts
{
    class ContractsVisualizer : Visualizer
    {
        private ContractsPresenter _presenter;

        public ContractsVisualizer()
        {
            Name = "Договора";
            Icon = ImageGallery.TaskIcon;

            var view = new ContractsControl();
            _presenter = new ContractsPresenter(view); 
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<ContractsVisualizer>();

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