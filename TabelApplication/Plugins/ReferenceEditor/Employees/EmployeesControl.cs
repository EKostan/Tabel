using System;
using System.Collections.Generic;
using System.ComponentModel;
using CACore.Visualizers;
using Contract;

namespace ReferenceEditor.Employees
{
    public partial class EmployeesControl : DevExpress.XtraEditors.XtraUserControl, IPresentation
    {
        public EmployeesControl()
        {
            InitializeComponent();
        }

        private BindingList<EmployeeRecord> _source;
        
        public event EventHandler SaveButtonClick;


        public List<EmployeeRecord> GetEmployees()
        {
            return new List<EmployeeRecord>(_items);
        }

        private List<EmployeeRecord> _items = new List<EmployeeRecord>();

        public void SetEmployees(List<EmployeeRecord> items)
        {
            _items = items;
            _source = new BindingList<EmployeeRecord>(new List<EmployeeRecord>(items));
            gridControl1.DataSource = _source;
            
        }

        protected virtual void OnSaveButtonClick()
        {
            var handler = SaveButtonClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveButtonClick();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var record = _source.AddNew();
            record.Status = Status.Insert;
            _items.Add(record);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var record = e.Row as EmployeeRecord;

            if(record == null)
                return;

            if (record.Status != Status.Insert)
                record.Status = Status.Update;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var emp = e.Row as EmployeeRecord;

            if (emp == null)
                return;

            emp.Status = Status.Delete;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var emps = GetSelectedItems();

            foreach (var emp in emps)
            {
                emp.Status = Status.Delete;
                _source.Remove(emp);
            }
        }

        private List<EmployeeRecord> GetSelectedItems()
        {
            var res = new List<EmployeeRecord>();
            var indexes = gridView1.GetSelectedRows();

            foreach (var index in indexes)
            {
                var emp = gridView1.GetRow(index) as EmployeeRecord;

                if(emp == null)
                    continue;

                res.Add(emp);
            }
            return res;
        }
    }
}
