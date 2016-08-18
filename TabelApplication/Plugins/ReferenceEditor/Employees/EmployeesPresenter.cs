using System.Collections.Generic;
using CACore.View;
using Contract;

namespace ReferenceEditor.Employees
{
    class EmployeesPresenter
    {
        private EmployeesControl _view;

        public EmployeesPresenter(EmployeesControl view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.SaveButtonClick += _view_SaveButtonClick;
            _view.ReloadButtonClick += _view_ReloadButtonClick;
            Workspace.Instance.Updated += Instance_Updated;
        }

        void Instance_Updated(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        void _view_ReloadButtonClick(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        void _view_SaveButtonClick(object sender, System.EventArgs e)
        {
            Project.Current.Employees.SetEmployees(_view.GetEmployees());
            ReloadData();
        }

        void _view_Load(object sender, System.EventArgs e)
        {
            ReloadData();
        }

        void ReloadData()
        {
            var data = Project.Current.Employees.GetEmployees();
            _view.SetEmployees(data);
        }

    }
}