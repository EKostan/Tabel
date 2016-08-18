using System;
using System.Windows.Forms;
using CACore.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace UserInterface.Ribbon
{
    class BarItemCreatorTextEdit : BaseBarItemCreator
    {
        protected override BarItem DoCreate(IItem item)
        {
            var menuDateEditItem = item as IItemTextEdit;

            if (menuDateEditItem == null)
                throw new Exception("TextEditBarItemCreator может принимать только IMenuItemTextEdit");

            var barEditItem = new BarEditItem()
            {
                Caption = item.DisplayName,
                Hint = item.Hint,
                Tag = menuDateEditItem,
                Enabled = item.Enabled,
                Visibility = item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never
            };

            var dec = new TextEditController(barEditItem, menuDateEditItem);

            return barEditItem;
        }
    }

    class TextEditController : IDisposable
    {
        private BarEditItem _barItem;
        private IItemTextEdit _item;
        private RepositoryItemButtonEdit _riButtonEdit;

        public TextEditController(BarEditItem barItem, IItemTextEdit item)
        {
            _riButtonEdit = new RepositoryItemButtonEdit();


            _barItem = barItem;
            _item = item;

            InitButtonEdit();

            _barItem.Width = 90;
            _barItem.Edit = _riButtonEdit;
            _barItem.EditValue = item.Text;


            SignEvents();
        }

        private void InitButtonEdit()
        {
            _riButtonEdit.Buttons.Clear();

            switch (_item.ButtonEdit)
            {
                case ButtonEdit.Search:

                    _riButtonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Search));
                    break;
            }
        }

       

        private void SignEvents()
        {
            _riButtonEdit.ButtonClick += _riButtonEdit_ButtonClick;
            _barItem.Disposed += BarItemDisposed;
            _item.EnableChanged += ItemEnableChanged;
            _item.VisibleChanged += _item_VisibleChanged;
            _riButtonEdit.EditValueChanging += _riButtonEdit_EditValueChanging;
            _riButtonEdit.KeyDown += _riButtonEdit_KeyDown;
        }

        void _item_VisibleChanged(object sender, EventArgs e)
        {
            _barItem.Visibility = _item.Visible ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        void _riButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                _item.Execute();
            }
        }


        void _riButtonEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            _item.Text = e.NewValue.ToString();
        }

       

        void _riButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            _item.Execute();
        }

        void ItemEnableChanged(object sender, EventArgs e)
        {
            _barItem.Enabled = _item.Enabled;
        }

        void BarItemDisposed(object sender, EventArgs e)
        {
            Dispose();
        }

        private void UnSignEvents()
        {
            _riButtonEdit.ButtonClick -= _riButtonEdit_ButtonClick;
            _barItem.Disposed -= BarItemDisposed;
            _item.EnableChanged -= ItemEnableChanged;
            _riButtonEdit.EditValueChanging -= _riButtonEdit_EditValueChanging;
        }

        public void Dispose()
        {
            UnSignEvents();
        }
    }

}