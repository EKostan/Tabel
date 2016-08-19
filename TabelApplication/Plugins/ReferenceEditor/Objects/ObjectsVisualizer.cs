using System.Collections.Generic;
using CACore.View;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Objects
{
    class ObjectsVisualizer : Visualizer
    {

        private ObjectsPresenter _presenter;

        public ObjectsVisualizer()
        {
            Name = "Объекты";
            Icon = ImageGallery.ObjectIcon;

            var view = new ObjectsControl();
            _presenter = new ObjectsPresenter(view); 
            Presentation = view;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            var vis = Workspace.Instance.GetActiveVisualizer<ObjectsVisualizer>();

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