using CACore.View;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceEditor.Time
{
    class TimePresenter : IDisposable
    {
        private TimeControl _view;

        public TimePresenter(TimeControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;
        }

       

        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Times.Set(_view.GetTime());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {

            var employees = Project.Current.Employees.Get();
            _view.Employees = employees;

            var jobs = Project.Current.Jobs.Get();
            _view.Jobs = jobs;

            var objects = Project.Current.Objects.Get();
            _view.Objects = objects;

            var contracts = Project.Current.Contracts.Get();
            _view.Contracts = contracts;


            var data = Project.Current.Times.Get();
            _view.SetTime(data);
            
        }

        public void Dispose()
        {
            _view.Load -= _view_Load;
            _view.SaveButtonClick -= _view_SaveButtonClick;
        }
    }
}
