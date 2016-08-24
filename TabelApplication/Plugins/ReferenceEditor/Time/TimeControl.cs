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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace ReferenceEditor.Time
{
    public partial class TimeControl : XtraUserControl, IPresentation
    {
        public TimeControl()
        {
            InitializeComponent();
        }

        public event EventHandler SaveButtonClick;

        protected virtual void OnSaveButtonClick()
        {
            var handler = SaveButtonClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        public List<TimeRecord> GetTime()
        {
            return new List<TimeRecord>(_items);
        }

        private BindingList<TimeRecord> _source;
        private List<TimeRecord> _items = new List<TimeRecord>();

        public void SetTime(List<TimeRecord> items)
        {
            _items = items;
            _source = new BindingList<TimeRecord>(new List<TimeRecord>(items));
            gridControl1.DataSource = _source;

        }

        List<EmployeeRecord> _Employees = new List<EmployeeRecord>();
        public List<EmployeeRecord> Employees
        {
            get { return _Employees; }
            set
            {
                _Employees = value;
                ricbEmployees.Items.Clear();
                foreach (var item in _Employees)
                {
                    ricbEmployees.Items.Add(item);
                }

            }
        }

        List<ContractRecord> _contracts = new List<ContractRecord>();
        public List<ContractRecord> Contracts
        {
            get { return _contracts; }
            set
            {
                _contracts = value;
                ricbContracts.Items.Clear();
                foreach (var item in _contracts)
                {
                    ricbContracts.Items.Add(item);
                }
            }
        }


        private void bbiAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var record = _source.AddNew();
            record.Status = Status.Insert;
            _items.Add(record);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.IsEditing)
            {
                gridView1.CloseEditor();

                var record = GetSelectedRecord();

                if (record.Status != Status.Insert)
                    record.Status = Status.Update;
            }
            OnSaveButtonClick();
        }

        TimeRecord GetSelectedRecord()
        {
           return gridView1.GetFocusedRow() as TimeRecord;
        }

        private void ricbEmployees_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;

            var time = GetSelectedRecord();

            if(time == null)
                return;

            var emp = e.NewValue as EmployeeRecord;

            if(emp == null)
                return;

            time.EmployeeId = emp.Id;
            time.EmployeeName = emp.Name;

            if (time.Status != Status.Insert)
                time.Status = Status.Update;

        }

        private void ricbContracts_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = true;

            var time = GetSelectedRecord();

            if (time == null)
                return;

            var emp = e.NewValue as ContractRecord;

            if (emp == null)
                return;

            time.ContractId = emp.Id;
            time.ContractCode = emp.Code;

            if (time.Status != Status.Insert)
                time.Status = Status.Update;

        }

        private void ricbJobs_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            

        }

        private void ricbObjects_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
           
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var record = e.Row as TimeRecord;

            if (record == null)
                return;

            if (record.Status != Status.Insert)
                record.Status = Status.Update;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var emp = e.Row as TimeRecord;

            if (emp == null)
                return;

            emp.Status = Status.Delete;
        }

    }
}
