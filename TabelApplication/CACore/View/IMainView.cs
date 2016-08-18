using System;
using System.Collections.Generic;
using System.Drawing;
using CACore.Menu;
using CACore.Trees;
using Core;

namespace CACore.View
{
    public interface IMainView
    {
        void CloseView();

        Tree Tree { get; set; }
        ICollection<IMenuTab> MainMenuTabs { get; set; }

        ICollection<ICategory> MenuCategories { get; set; }


        // рабочее пространство
        void AddNewTab(Tab tab);
        void DeleteTab(Tab tab);
        void ActivateTab(Tab tab);

        // дерево
        void CheckNode(INode node, bool check);

        event EventHandler MainViewLoad;
        event EventHandler MainViewClose;

        event EventHandler<BaseEventArgs<IItem>> MenuItemClick;
        event EventHandler<BaseEventArgs<Tab>> CloseTabClick;
        event EventHandler<BaseEventArgs<Tab>> TabSelected;
        event EventHandler<CheckNodeEventArgs> NodeChecked;
        void ShowMessage(string message);
        void ShowError(string error);
        void SetIcon(Icon icon);

        void UpdateView();

        void ToastMessage(IToastMessage message);
        void Init();
    }
}
