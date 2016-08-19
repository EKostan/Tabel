using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ReferenceEditor.Jobs
{
    class JobsItem : BaseItemButton
    {
        public JobsItem()
        {
            this.DisplayName = "Работы";
            Icon = ImageGallery.JobIcon;
            LargeIcon = ImageGallery.JobIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new JobsVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}