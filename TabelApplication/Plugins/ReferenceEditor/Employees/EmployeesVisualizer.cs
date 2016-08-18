using System.Collections.Generic;
using CACore.Visualizers;
using InterfaceLibrary;

namespace ReferenceEditor.Employees
{
    class EmployeesVisualizer : Visualizer
    {
        public EmployeesVisualizer()
        {
            Name = "Сотрудники";
            Icon = ImageGallery.TeamIcon;

            var view = new EmployeesControl();
            var presenter = new EmployeesPresenter(view); 
            Presentation = view;
        }

       
    }
}