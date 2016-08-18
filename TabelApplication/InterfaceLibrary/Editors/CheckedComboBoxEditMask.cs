using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace InterfaceLibrary.Editors
{
    public class CheckedComboBoxEditMask : CheckedComboBoxEdit
    {
        public CheckedComboBoxEditMask()
        {
            KeyUp += CheckedComboBoxEditEx_KeyUp;
            Closed += CheckedComboBoxEditEx_Closed;
            MouseEnter += CheckedComboBoxEditMask_MouseEnter;
        }

        void CheckedComboBoxEditMask_MouseEnter(object sender, EventArgs e)
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
            MouseEnter -= CheckedComboBoxEditMask_MouseEnter;
            base.Dispose(disposing);
        }

        void CheckedComboBoxEditEx_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode != PopupCloseMode.Cancel)
            {
                OnItemsCheckedChenged();
            }
        }

        void UncheckAllItems(CheckedListBoxItemCollection items)
        {
            foreach (CheckedListBoxItem item in items)
            {
                item.CheckState = CheckState.Unchecked;
            }
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
                    var itemTrim = item.Trim();
                    Regex regex = new Regex("^" + itemTrim.Replace("*", ".*") + "$", RegexOptions.Compiled);
                    

                    foreach (CheckedListBoxItem itemListBox in Properties.Items)
                    {
                        var itemListBoxString = itemListBox.Value.ToString().Trim();

                        if (regex.IsMatch(itemListBoxString))
                        {
                            itemListBox.CheckState = CheckState.Checked;
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
            var oldItems = oldText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

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