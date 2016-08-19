using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CACore.Visualizers;
using Contract;
using DevExpress.XtraEditors;

namespace ReferenceEditor.Jobs
{
    public partial class JobsControl : XtraUserControl, IPresentation
    {
        public JobsControl()
        {
            InitializeComponent();
        }


        public event EventHandler SaveButtonClick;
        protected virtual void OnSaveButtonClick()
        {
            var handler = SaveButtonClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private List<JobRecord> _items = new List<JobRecord>();
        private BindingList<JobRecord> _source;

        public List<JobRecord> GetJobs()
        {
            return new List<JobRecord>(_items);
        }

        public void SetJobs(List<JobRecord> items)
        {
            _items = items;
            _source = new BindingList<JobRecord>(new List<JobRecord>(items));
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
            var record = e.Row as JobRecord;

            if (record == null)
                return;

            if (record.Status != Status.Insert)
                record.Status = Status.Update;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var emp = e.Row as JobRecord;

            if (emp == null)
                return;

            emp.Status = Status.Delete;
        }

        private List<JobRecord> GetSelectedItems()
        {
            var res = new List<JobRecord>();
            var indexes = gridView1.GetSelectedRows();

            foreach (var index in indexes)
            {
                var emp = gridView1.GetRow(index) as JobRecord;

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
    }
}
