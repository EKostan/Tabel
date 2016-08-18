using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Editors
{
    public class ComboBoxDynamicSearch : ComboBoxEdit
    {
        private List<object> _items = null; 

        public ComboBoxDynamicSearch()
        {
            Init();
        }


        void ComboBoxDynamicSearch_Disposed(object sender, EventArgs e)
        {
            EditValueChanged -= OnEditValueChanged;
            SelectedValueChanged -= ComboBoxDynamicSearch_SelectedValueChanged;
            CloseUp -= ComboBoxDynamicSearch_CloseUp;
            Disposed -= ComboBoxDynamicSearch_Disposed;
            this.Leave -= ComboBoxDynamicSearch_Leave;
            MouseEnter -= ComboBoxDynamicSearch_MouseEnter;
        }

        private void Init()
        {
            Properties.AutoComplete = false;
            EditValueChanged += OnEditValueChanged;
            SelectedValueChanged += ComboBoxDynamicSearch_SelectedValueChanged;
            CloseUp += ComboBoxDynamicSearch_CloseUp;
            Disposed += ComboBoxDynamicSearch_Disposed;
            this.Leave += ComboBoxDynamicSearch_Leave;
            MouseEnter += ComboBoxDynamicSearch_MouseEnter;
            
        }

        void ComboBoxDynamicSearch_MouseEnter(object sender, EventArgs e)
        {
            var info = GetViewInfo() as DevExpress.XtraEditors.ViewInfo.ComboBoxViewInfo;

            using (var g = CreateGraphics())
            {
                int buttonWidth = 0;
                
                if(info != null)
                    buttonWidth = info.LeftButtons.Width + info.RightButtons.Width;
                
                ToolTip = g.MeasureString(Text, Font).Width > (Width - buttonWidth) ? Text : string.Empty;
            }
        }

     

        void ComboBoxDynamicSearch_Leave(object sender, EventArgs e)
        {
        }

        void ComboBoxDynamicSearch_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            FillAll();
        }

        private void ComboBoxDynamicSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsPopupOpen && SelectedIndex >= 0)
            {
                ClosePopup();
                FillAll();
            }
        }

        private void FillAll()
        {
            Properties.Items.Clear();
            Properties.Items.AddRange(_items);
        }

        public void SetItems(List<object> items)
        {
            EditValueChanged -= OnEditValueChanged;

            Text = string.Empty;
            _items = new List<object>(items);
            _items = _items.OrderBy(x => x.ToString()).ToList();
            FillAll();

            EditValueChanged += OnEditValueChanged;
        }

        /// <summary>
        /// Возвращает текущую коллекцию элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetItems<T>()
        {
            return _items.Select(x => (T) x).ToList();
        }

        /// <summary>
        /// Возвращает текущую коллекцию элементов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetItemIndexBy<T>(Func<T, bool> func) 
            where T : class
        {

            int i = 0;
            foreach (var item in _items)
            {
                var curItem = item as T;
                if (func(curItem))
                {
                    return i;
                }
                i++;
            }

            return -1;
        }

        private void OnEditValueChanged(object sender, EventArgs eventArgs)
        {
            if (_items == null || EditValue == null)
                return;



            BeginUpdate();
            var selectedText = EditValue.ToString().ToLower();

            List<object> filteredItems = _items.Where(
                x => x.ToString().ToLower().Contains(selectedText)).ToList();

            CloseUp -= ComboBoxDynamicSearch_CloseUp;
            Properties.Items.BeginUpdate();
            bool p = IsPopupOpen;
            int s = SelectedIndex;
            Properties.Items.Clear();

            if (filteredItems.Count < 1 || (!p && s >= 0))
                Properties.Items.AddRange(_items);
            else
                Properties.Items.AddRange(filteredItems);

            Properties.Items.EndUpdate();
            CloseUp += ComboBoxDynamicSearch_CloseUp;

            if (!IsPopupOpen && Properties.Items.Count > 0 && SelectedIndex < 0)
            {
                ShowPopup();
            }

            EndUpdate();
        }
    }
}
