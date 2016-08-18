using System;
using System.Collections.Generic;
using CACore.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using InterfaceLibrary;

namespace UserInterface.Ribbon
{
    class RibbonBuilder
    {
        public RibbonControl RibbonControl { get; set; }
        public ImageController ImageController { get; set; }

        public ImageController ImageLargeController { get; set; }
        public ICollection<IMenuTab> Tabs { get; set; }
        public List<ICategory> Categories { get; set; }

        delegate void buildDelegate();
        public void Build()
        {
            if (RibbonControl == null)
                return;

            if (RibbonControl.InvokeRequired)
            {
                RibbonControl.Invoke(new buildDelegate(Build));
                return;
            }

            _itemsDict = new Dictionary<int, BarItem>();
            
            RibbonControl.BeginInit();
            RibbonControl.Pages.Clear();

            var tabs = CreateTabs(Tabs);
            RibbonControl.Pages.AddRange(tabs.ToArray());

            foreach (var category in Categories)
            {
                var cat = new RibbonPageCategory();
                cat.Visible = category.Visible;
                cat.Text = category.Name;
                category.VisibleChanged += category_VisibleChanged;
                cat.Tag = category;

                var catTabs = CreateTabs(category.Tabs);
                cat.Pages.AddRange(catTabs.ToArray());

                RibbonControl.PageCategories.Add(cat);
            }

            RibbonControl.EndInit();
        }

        void category_VisibleChanged(object sender, EventArgs e)
        {
            var category = (ICategory) sender;
            var ribbonPageCategory = FindCategory(category);

            if(ribbonPageCategory == null)
                return;

            ribbonPageCategory.Visible = category.Visible;

            if (ribbonPageCategory.Visible && ribbonPageCategory.Pages.Count > 0)
                RibbonControl.SelectedPage = ribbonPageCategory.Pages[0];
        }

        private RibbonPageCategory FindCategory(ICategory category)
        {
            foreach (RibbonPageCategory pageCategory in RibbonControl.PageCategories)
            {
                var curCategory = pageCategory.Tag as ICategory;

                if(curCategory == null)
                    continue;

                if (curCategory.Equals(category) || curCategory.Key.Equals(category.Key))
                {
                    return pageCategory;
                }

            }

            return null;
        }

        private List<RibbonPage> CreateTabs(ICollection<IMenuTab> tabs)
        {

            var res = new List<RibbonPage>();
            foreach (var tab in tabs)
            {
                var page = CreatePage(tab);
                res.Add(page);

                foreach (var group in tab.Groups)
                {
                    var pageGroup = CreatePageGroup(group);
                    page.Groups.Add(pageGroup);

                    foreach (var item in group.Items)
                    {
                        var barItem = CreateBarItem(item);

                        if (barItem == null)
                            continue;

                        if (item.Icon != null)
                        {
                            var imageIndex = ImageController.Add(item.Icon, item.GetType());
                            barItem.ImageIndex = imageIndex;
                        }

                        if (item.LargeIcon != null)
                        {
                            var imageLargeIndex = ImageLargeController.Add(item.LargeIcon, item.GetType());
                            barItem.LargeImageIndex = imageLargeIndex;
                        }

                        barItem.Enabled = item.Enabled;

                        RibbonControl.Items.Add(barItem);
                        pageGroup.ItemLinks.Add(barItem);
                    }
                }
            }
            return res;
        }

        Dictionary<int, BarItem> _itemsDict = new Dictionary<int, BarItem>();
        private BarItem CreateBarItem(IItem item)
        {
            var key = item.GetHashCode();

            if (_itemsDict.ContainsKey(key))
                return _itemsDict[key];

            var barItem = BarItemCreatorFactory.CreateBarItem(item);
            _itemsDict[key] = barItem;
            return barItem;
        }

       

        private RibbonPageGroup CreatePageGroup(IGroup group)
        {
            var barGroupCreator = new BarGroupCreator();
            return barGroupCreator.Create(group);
        }

        private RibbonPage CreatePage(IMenuTab menuTab)
        {
            var page = new RibbonPage();
            page.Name = menuTab.Key;
            page.Text = menuTab.DisplayName;
            page.Tag = menuTab;
            return page;
        }
    }
}
