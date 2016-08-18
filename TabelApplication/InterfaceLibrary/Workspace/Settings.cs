using System;
using System.Collections.Generic;
using CACore.View;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Workspace
{
    public partial class Settings : XtraForm
    {
        public Settings()
        {
            InitializeComponent();
        }

        private LayoutSettingsCollection _layoutSettingsCollection;
        public LayoutSettingsCollection LayoutSettingsCollection
        {
            get { return _layoutSettingsCollection; }
            set
            {
                _layoutSettingsCollection = value;
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
           
            if (_layoutSettingsCollection == null)
            {
                listBox1.EndUpdate();
                return;
            }

            foreach (LayoutSettings item in _layoutSettingsCollection)
            {
                if (item.Name.Equals(WorkspaceController.DefaultLayoutName))
                    continue;

                listBox1.Items.Add(item);
            }

            listBox1.EndUpdate();
        }

        private void sbDelete_Click(object sender, EventArgs e)
        {
            var selectedItems = GetSelectedItems();
            OnDeleteEvent(selectedItems);
            //_layoutSettingsCollection.Remove(selectedItems);
            //UpdateListBox();
        }

        private List<LayoutSettings> GetSelectedItems()
        {
            var res = new List<LayoutSettings>();
            foreach (var item in listBox1.SelectedItems)
            {
                var layoutSettings = item as LayoutSettings;

                if(layoutSettings == null)
                    continue;

                res.Add(layoutSettings);
            }
            return res;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public event EventHandler<List<LayoutSettings>> DeleteEvent;

        protected virtual void OnDeleteEvent(List<LayoutSettings> e)
        {
            var handler = DeleteEvent;
            if (handler != null) handler(this, e);
        }
    }
}