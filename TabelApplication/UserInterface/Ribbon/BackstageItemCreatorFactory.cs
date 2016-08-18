using System;
using System.Collections.Generic;
using System.Linq;
using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    class BackstageItemCreatorFactory
    {
        static BackstageItemCreatorFactory()
        {
            _creators.Add(typeof(IItemButton), new BackstageItemCreatorButton());
        }

        static Dictionary<Type, IBackstageItemCreator> _creators = new Dictionary<Type, IBackstageItemCreator>();

        public static BackstageViewItem CreateBarItem(IItem item)
        {
            var itemType = item.GetType();


            foreach (var creatorItem in _creators)
            {
                if (itemType.GetInterfaces().Contains(creatorItem.Key))
                {
                    return creatorItem.Value.Create(item);
                }
            }

            return null;
        }

    }
}