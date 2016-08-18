using System.Collections.Generic;

namespace CACore.Menu
{
    public class MainMenu
    {
        static Dictionary<string, IGroup> groups = new Dictionary<string, IGroup>();
        static Dictionary<string, IMenuTab> tabs = new Dictionary<string, IMenuTab>();
        static Dictionary<string, ICategory> _categories = new Dictionary<string, ICategory>();
        static List<IItem> _backstage = new List<IItem>();


        static MainMenu()
        {

        }

        public static void AddBackstageItem(IItem item)
        {
            _backstage.Add(item);
        }

        public static List<IItem> GetBackstageItems()
        {
            return new List<IItem>(_backstage);
        }


        public static void AddGroup(IGroup group)
        {
            groups[group.Key] = group;
        }

        public static void AddGroups(ICollection<IGroup> groups)
        {
            foreach (var menuItemGroup in groups)
            {
                AddGroup(menuItemGroup);
            }
        }

        public static void AddCategory(ICategory category)
        {
            _categories[category.Key] = category;
        }

        public static ICollection<ICategory> GetCategories()
        {
            return new List<ICategory>(_categories.Values);
        }


        public static void AddMenuItem(IItem item, IGroup group)
        {
            if(!groups.ContainsKey(group.Key))
                groups.Add(group.Key, group);

            groups[group.Key].AddItem(item);
        }

       
        public static void AddMenuItem(IItem item, string groupKey)
        {
            var group = GetGroupByName(groupKey);
            group.AddItem(item);
        }

        public static IGroup GetGroupByName(string groupKey)
        {
            return groups[groupKey];
        }

        public static ICollection<IGroup> GetGroups()
        {
            return new List<IGroup>(groups.Values);
        }


        public static void AddTab(IMenuTab menuTab)
        {
            tabs[menuTab.Key] = menuTab;
        }

        private static IMenuTab GetTabByKey(string tabName)
        {
            return tabs[tabName];
        }

        public static ICollection<IMenuTab> GetTabs()
        {
            return new List<IMenuTab>(tabs.Values);
        }

        public static void SetOnlyThisCategoryVisible(string key, bool visible = true)
        {
            if(!_categories.ContainsKey(key))
                return;

            HideAllCatogory();

            _categories[key].Visible = visible;
        }

        public static void HideAllCatogory()
        {
            foreach (var cat in _categories.Values)
            {
                cat.Visible = false;
            }
        }
    }
} 
