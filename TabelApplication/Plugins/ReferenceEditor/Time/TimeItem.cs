using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CACore.Menu;
using CACore.View;
using InterfaceLibrary;
using ReferenceEditor.Employees;

namespace ReferenceEditor.Time
{
    class TimeItem : BaseItemButton
    {
        public TimeItem()
        {
            this.DisplayName = "Табель";
            Icon = ImageGallery.TimeIcon;
            LargeIcon = ImageGallery.TimeIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new TimeVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}
