using System;
using System.Collections.Generic;
using System.Linq;
using CACore.Menu;
using DevExpress.XtraBars;

namespace UserInterface.Ribbon
{
    class BarItemCreatorFactory
    {
        static BarItemCreatorFactory()
        {
            _creators.Add(typeof(IItemButton), new BarItemCreatorButton());
            _creators.Add(typeof(IItemCheckBox), new BarItemCreatorCheckBox());
            _creators.Add(typeof(IItemDateEdit), new BarItemCreatorDateEdit());
            _creators.Add(typeof(IItemTextEdit), new BarItemCreatorTextEdit());
        }

        static Dictionary<Type, IBarItemCreator> _creators = new Dictionary<Type, IBarItemCreator>();

        public static BarItem CreateBarItem(IItem item)
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