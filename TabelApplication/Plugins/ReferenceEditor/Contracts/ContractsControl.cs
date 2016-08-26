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

namespace ReferenceEditor.Contracts
{
    public partial class ContractsControl : DevExpress.XtraEditors.XtraUserControl, IPresentation
    {
        public ContractsControl()
        {
            InitializeComponent();
        }


        public event EventHandler SaveButtonClick;
        protected virtual void OnSaveButtonClick()
        {
            var handler = SaveButtonClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private List<ContractRecord> _items = new List<ContractRecord>();
        private BindingList<ContractRecord> _source;

        public List<ContractRecord> GetContracts()
        {
            return new List<ContractRecord>(_items);
        }

        public void SetContracts(List<ContractRecord> items)
        {
            _items = items;
            _source = new BindingList<ContractRecord>(new List<ContractRecord>(items));
            gridControl1.DataSource = _source;
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        ContractRecord GetSelectedRecord()
        {
            return gridView1.GetFocusedRow() as ContractRecord;
        }


        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var record = _source.AddNew();
            record.Status = Status.Insert;
            _items.Add(record);
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var record = e.Row as ContractRecord;

            if (record == null)
                return;

            if (record.Status != Status.Insert)
                record.Status = Status.Update;
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var emp = e.Row as ContractRecord;

            if (emp == null)
                return;

            emp.Status = Status.Delete;
        }

        private List<ContractRecord> GetSelectedItems()
        {
            var res = new List<ContractRecord>();
            var indexes = gridView1.GetSelectedRows();

            foreach (var index in indexes)
            {
                var emp = gridView1.GetRow(index) as ContractRecord;

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

        private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCode)
            {
                if (!CheckCodeUniq(e.Value.ToString()))
                {
                    throw new Exception("Ошибка: Проект с таким кодом уже существует, введите другой код.");
                }
            }
        }

        private bool CheckCodeUniq(string code)
        {
            int f = 0;
            foreach (var record in _source)
            {
                if (record.Code == code)
                {
                    f++;

                    if(f>=2)
                        return false;
                }
            }

            return true;
        }
    }
}
