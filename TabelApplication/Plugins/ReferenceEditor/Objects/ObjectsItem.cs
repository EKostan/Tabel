using CACore.Menu;
using CACore.View;
using InterfaceLibrary;

namespace ReferenceEditor.Objects
{
    class ObjectsItem : BaseItemButton
    {
        public ObjectsItem()
        {
            this.DisplayName = "Объекты";
            Icon = ImageGallery.ObjectIcon;
            LargeIcon = ImageGallery.ObjectIcon32;
        }

        protected override void DoExecute()
        {
            var refBook = new ObjectsVisualizer();
            var tab = Workspace.Instance.NewTab(refBook);
        }

    }
}