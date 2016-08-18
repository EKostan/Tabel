using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace InterfaceLibrary.Editors
{
    public class CheckedComboBoxEditEx : CheckedComboBoxEdit
    {
        public CheckedComboBoxEditEx()
        {
            Properties.IncrementalSearch = true;
            KeyUp += CheckedComboBoxEditEx_KeyUp;
            Closed += CheckedComboBoxEditEx_Closed;
            MouseEnter += CheckedComboBoxEditEx_MouseEnter;
            this.MouseEnter += TextEditExt_MouseEnter;
            this.LostFocus += CheckedComboBoxEditEx_LostFocus;
        }

        void CheckedComboBoxEditEx_LostFocus(object sender, EventArgs e)
        {
            
        }

        void TextEditExt_MouseEnter(object sender, EventArgs e)
        {
            var info = GetViewInfo() as DevExpress.XtraEditors.ViewInfo.ComboBoxViewInfo;

            using (var g = CreateGraphics())
            {
                int buttonWidth = 0;

                if (info != null)
                    buttonWidth = info.LeftButtons.Width + info.RightButtons.Width;

                ToolTip = g.MeasureString(Text, Font).Width > (Width - buttonWidth) ? Text : string.Empty;
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.KeyUp -= CheckedComboBoxEditEx_KeyUp;
            this.Closed -= CheckedComboBoxEditEx_Closed;
            MouseEnter -= CheckedComboBoxEditEx_MouseEnter;
            this.MouseEnter -= TextEditExt_MouseEnter;
            base.Dispose(disposing);
        }
        void CheckedComboBoxEditEx_MouseEnter(object sender, EventArgs e)
        {
            using (var g = CreateGraphics())
            {
                ToolTip = g.MeasureString(Text, Font).Width > Width ? Text : string.Empty;
            }
        }

        void CheckedComboBoxEditEx_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode != PopupCloseMode.Cancel)
            {
                OnItemsCheckedChenged();
            }
        }

        public void UncheckAllItems()
        {
            UncheckAllItems(Properties.Items);
        }

        void UncheckAllItems(CheckedListBoxItemCollection items)
        {
            BeginUpdate();
            foreach (CheckedListBoxItem item in items)
            {
                item.CheckState = CheckState.Unchecked;
            }
            EndUpdate();
        }

        void SetCheckedFromString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                UncheckAllItems(Properties.Items);
            }
            else
            {
                var items = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                UncheckAllItems(Properties.Items);

                foreach (var item in items)
                {
                    foreach (CheckedListBoxItem itemListBox in Properties.Items)
                    {
                        if (itemListBox.Value.ToString().Equals(item))
                        {
                            itemListBox.CheckState = CheckState.Checked;
                            break;
                        }
                    }
                }
            }
        }

        void CheckedComboBoxEditEx_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SetCheckedFromString(Text);
                OnItemsCheckedChenged();
            }
        }

        public List<T> GetCheckedValues<T>()
        {
            return Properties.Items.GetCheckedValues().Cast<T>().ToList();
        }

        public void SetCheckedValues<T>(List<T> items)
        {
            BeginUpdate();

            foreach (CheckedListBoxItem item in Properties.Items)
            {
                if (items.Contains((T)item.Value))
                    item.CheckState = CheckState.Checked;
            }
            EndUpdate();
        }

        public event EventHandler ItemsCheckedChenged;


        protected virtual void OnItemsCheckedChenged()
        {
            var handler = ItemsCheckedChenged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void UpdateItems<T>(List<T> items)
        {
            BeginUpdate();
            var oldText = Text;
            var oldItems = oldText.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var newItemsDict = new Dictionary<string, string>();
            foreach (var item in items)
            {
                var key = item.ToString();
                newItemsDict[key] = key;
            }

            var newStringList = new List<string>();
            foreach (var oldItem in oldItems)
            {
                if (newItemsDict.ContainsKey(oldItem))
                    newStringList.Add(oldItem);
            }


            Properties.Items.BeginUpdate();
            Properties.Items.Clear();
            foreach (var item in items)
            {
                Properties.Items.Add(item);
            }
            Properties.Items.EndUpdate();

            Text = string.Join(",", newStringList);
            SetCheckedFromString(Text);
            EndUpdate();
        }

        
    }
}
