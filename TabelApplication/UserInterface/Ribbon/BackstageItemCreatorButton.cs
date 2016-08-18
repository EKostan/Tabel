using System;
using CACore.Menu;
using DevExpress.XtraBars.Ribbon;

namespace UserInterface.Ribbon
{
    class BackstageItemCreatorButton : BaseBackstageItemCreator
    {
        protected override BackstageViewItem DoCreate(IItem item)
        {
            var bbi = new BackstageViewButtonItem()
            {
                Caption = item.DisplayName,
                Tag = item,
                Enabled = item.Enabled,
                Visible = item.Visible,
            };

            var controller = new BackstageItemControllerButton(item, bbi);

            return bbi;
        }

    }

    internal class BackstageItemControllerButton : IDisposable
    {
        private IItem _item;
        private BackstageViewButtonItem _barButtonItem;

        public BackstageItemControllerButton(IItem item, BackstageViewButtonItem barButtonItem)
        {
            _item = item;
            _barButtonItem = barButtonItem;

            SignEvents();
        }

        private void SignEvents()
        {
            _item.EnableChanged += ItemEnableChanged;
            _item.VisibleChanged += _item_VisibleChanged;
            _barButtonItem.Disposed += _barButtonItem_Disposed;
        }

        void _item_VisibleChanged(object sender, EventArgs e)
        {
            _barButtonItem.Visible = _item.Visible;
        }

        void _barButtonItem_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        void ItemEnableChanged(object sender, EventArgs e)
        {
            _barButtonItem.Enabled = _item.Enabled;
        }

        public void Dispose()
        {
            _item.EnableChanged -= ItemEnableChanged;
            _item.VisibleChanged -= _item_VisibleChanged;
            _barButtonItem.Disposed -= _barButtonItem_Disposed;

        }
    }

}