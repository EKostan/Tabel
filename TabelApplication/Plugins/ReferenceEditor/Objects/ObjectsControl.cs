using System;
using System.Collections.Generic;
using System.ComponentModel;
using CACore.Visualizers;
using Contract;
using DevExpress.XtraEditors;

namespace ReferenceEditor.Objects
{
    public partial class ObjectsControl : XtraUserControl, IPresentation
    {
        public ObjectsControl()
        {
            InitializeComponent();
        }


        public event EventHandler SaveButtonClick;
        protected virtual void OnSaveButtonClick()
        {
            var handler = SaveButtonClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private List<ObjectRecord> _items = new List<ObjectRecord>();
        private BindingList<ObjectRecord> _source;

        public List<ObjectRecord> GetObjects()
        {
            return new List<ObjectRecord>(_items);
        }

        public void SetObjects(List<ObjectRecord> items)
        {
            _items = items;
            _source = new BindingList<ObjectRecord>(new List<ObjectRecord>(items));
            gridControl1.DataSource = _source;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveButtonClick();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var record = _source.AddNew();
            record.Status = Status.Insert;
            _items.Add(record);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var record = e.Row as ObjectRecord;

            if (record == null)
                return;

            if (record.Status != Status.Insert)
                record.Status = Status.Update;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var emp = e.Row as ObjectRecord;

            if (emp == null)
                return;

            emp.Status = Status.Delete;
        }

        private List<ObjectRecord> GetSelectedItems()
        {
            var res = new List<ObjectRecord>();
            var indexes = gridView1.GetSelectedRows();

            foreach (var index in indexes)
            {
                var emp = gridView1.GetRow(index) as ObjectRecord;

                if (emp == null)
                    continue;

                res.Add(emp);
            }
            return res;
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var emps = GetSelectedItems();

            foreach (var emp in emps)
            {
                emp.Status = Status.Delete;
                _source.Remove(emp);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
