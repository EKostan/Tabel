using System;
using System.Collections.Generic;
using CACore.View;
using Contract;

namespace ReferenceEditor.Jobs
{
    class JobsPresenter : IDisposable
    {
        private JobsControl _view;

        public JobsPresenter(JobsControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;
        }


        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Jobs.Set(_view.GetJobs());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var data = Project.Current.Jobs.Get();
            _view.SetJobs(data);
        }

        public void Dispose()
        {
            _view.Load -= _view_Load;
            _view.SaveButtonClick -= _view_SaveButtonClick;
        }
    }
}