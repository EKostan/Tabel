using System;
using CACore.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;

namespace UserInterface.Ribbon
{
    class BarItemCreatorDateEdit : BaseBarItemCreator
    {
        protected override BarItem DoCreate(IItem item)
        {
            var menuDateEditItem = item as IItemDateEdit;

            if(menuDateEditItem == null)
                throw new Exception("BarDateEditItemCreator может принимать только IMenuDateEditItem");

            var bei =  new BarEditItem()
            {
                Caption = item.DisplayName,
                Hint = item.Hint,
                Tag = menuDateEditItem,
                Enabled = item.Enabled,
                Visibility = item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never
            };

            var dec = new DateEditController(bei, menuDateEditItem);

            return bei;
        }
    }

    class DateEditController : IDisposable
    {
        private BarEditItem _barItem;
        private IItemDateEdit _item;
        private RepositoryItemDateEdit _repositoryItemDateEdit;

        public DateEditController(BarEditItem barItem, IItemDateEdit item)
        {
            _repositoryItemDateEdit = new RepositoryItemDateEdit();

            _barItem = barItem;
            _item = item;

            _barItem.Width = 90;
            _barItem.Edit = _repositoryItemDateEdit;
            _barItem.EditValue = item.Date;

            SignEvents();
        }

        private RepositoryItemDateEdit DateEdit
        {
            get { return _repositoryItemDateEdit; }
        }

        private void SignEvents()
        {
            
            DateEdit.EditValueChanging += DateEdit_EditValueChanging;
            _barItem.Disposed += BarItemDisposed;
            _item.EnableChanged += ItemEnableChanged;
            _item.VisibleChanged += _item_VisibleChanged;
            _item.DateChanged += _item_DateChanged;

        }

        void _item_DateChanged(object sender, DateTime e)
        {
            _barItem.BeginUpdate();
            _barItem.EditValue = e;
            _barItem.EndUpdate();
        }

        void _item_VisibleChanged(object sender, EventArgs e)
        {
            _barItem.Visibility = _item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        void ItemEnableChanged(object sender, EventArgs e)
        {
            _barItem.Enabled = _item.Enabled;
        }

        void DateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
                _item.Date = (DateTime)e.NewValue;
        }

        void BarItemDisposed(object sender, EventArgs e)
        {
            Dispose();
        }

       

        private void UnSignEvents()
        {
            DateEdit.EditValueChanging -= DateEdit_EditValueChanging;
            _barItem.Disposed -= BarItemDisposed;
            _item.EnableChanged -= ItemEnableChanged;
            _item.VisibleChanged -= _item_VisibleChanged;
            _item.DateChanged -= _item_DateChanged;
        }

        public void Dispose()
        {
            UnSignEvents();
        }
    }
}