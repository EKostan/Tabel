using System.Collections.Generic;
using CACore;
using CACore.FolderOpener;
using CACore.Menu;
using CACore.View;
using Core;
using Core.Module;
using Core.Plugins;
using Core.Users.Settings;
using ReferenceEditor.Employees;
using ReferenceEditor.Time;

namespace ReferenceEditor
{
    public class Plugin
    {
        [Install]
        public static void Install()
        {
            MainMenu.AddMenuItem(new EmployeesItem(), CommonGroupKeys.Journals);
            MainMenu.AddMenuItem(new TimeItem(), CommonGroupKeys.Journals);
        }

       

    }
}
