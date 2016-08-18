using System.Windows.Forms;

namespace ReferenceEditor.Employees
{
    class ReferenceEmplyees 
    {
        public ReferenceEmplyees()
        {
            Name = "Сотрудники";
        }

        public string Name { get; set; }
        public Control TabControl 
        {
            get
            {
                var view = new EmployeesControl();
                var presenter = new EmployeesPresenter(view);
                return view;
            }
        }
    }
}
