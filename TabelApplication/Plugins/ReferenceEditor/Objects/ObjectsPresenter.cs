using System;
using System.Collections.Generic;
using CACore.View;
using Contract;

namespace ReferenceEditor.Objects
{
    class ObjectsPresenter : IDisposable
    {
        private ObjectsControl _view;

        public ObjectsPresenter(ObjectsControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;
        }

        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Objects.Set(_view.GetObjects());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var data = Project.Current.Objects.Get();
            _view.SetObjects(data);
        }

        public void Dispose()
        {
            _view.Load -= _view_Load;
            _view.SaveButtonClick -= _view_SaveButtonClick;
        }
    }
}