using CACore.Menu;
using Core.Plugins;
using ReferenceEditor.Contracts;
using ReferenceEditor.Employees;
using ReferenceEditor.Time;
using ReferenceEditor.Jobs;
using ReferenceEditor.Objects;

namespace ReferenceEditor
{
    public class Plugin
    {
        [Install]
        public static void Install()
        {
            MainMenu.AddMenuItem(new TimeItem(), CommonGroupKeys.References);

            MainMenu.AddMenuItem(new EmployeesItem(), CommonGroupKeys.References);
            MainMenu.AddMenuItem(new ContractsItem(), CommonGroupKeys.References);
            MainMenu.AddMenuItem(new JobsItem(), CommonGroupKeys.References);
            MainMenu.AddMenuItem(new ObjectsItem(), CommonGroupKeys.References);
        }

       

    }
}
