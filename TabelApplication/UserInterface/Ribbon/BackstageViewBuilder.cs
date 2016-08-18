using CACore.Menu;
using DevExpress.XtraBars.Ribbon;
using InterfaceLibrary;

namespace UserInterface.Ribbon
{
    /// <summary>
    /// Класс генерирует контролы для главное меню (BackstageView - за кулисами)
    /// </summary>
    class BackstageViewBuilder
    {
        public BackstageViewControl BackstageViewControl { get; set; }
        public ImageController ImageController { get; set; }

        delegate void buildDelegate();
        public void Build()
        {
            if(BackstageViewControl == null)
                return;

            if (BackstageViewControl.InvokeRequired)
            {
                BackstageViewControl.Invoke(new buildDelegate(Build));
                return;
            }

            var items = MainMenu.GetBackstageItems();

            BackstageViewControl.BeginUpdate();
            foreach (var item in items)
            {
                var backstageViewItem = CreateItem(item);
                BackstageViewControl.Items.Add(backstageViewItem);
            }
            BackstageViewControl.EndUpdate();

        }

        BackstageViewItem CreateItem(IItem item)
        {
            var backstageViewItem = BackstageItemCreatorFactory.CreateBarItem(item);

            // картинки не смотрятся на синем фоне
            //if (item.Icon != null)
            //{
            //    var imageIndex = ImageController.Add(item.Icon, item.GetType());
            //    backstageViewItem.ImageIndex = imageIndex;
            //}

            return backstageViewItem;
        }

    }
}