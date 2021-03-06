using System;
using System.Collections.Generic;
using CACore.View;
using Contract;

namespace ReferenceEditor.Employees
{
    class EmployeesPresenter : IDisposable
    {
        private EmployeesControl _view;

        public EmployeesPresenter(EmployeesControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;
        }

        

        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Employees.Set(_view.GetEmployees());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var data = Project.Current.Employees.Get();
            _view.SetEmployees(data);
        }
        public void Dispose()
        {
            _view.Load -= _view_Load;
            _view.SaveButtonClick -= _view_SaveButtonClick;
        }
    }
}