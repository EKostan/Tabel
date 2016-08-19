using System;
using System.Collections.Generic;
using System.ComponentModel;
using CACore.Visualizers;
using Contract;
using DevExpress.XtraEditors;
using InterfaceLibrary;

namespace ReferenceEditor.Reports.ByEmployees
{
    partial class ReportByEmployeesControl : XtraUserControl, IPresentation
    {
        public ReportByEmployeesControl()
        {
            InitializeComponent();

            beiYear.EditValue = DateTime.Now.Year;
        }


        public int Year 
        {
            get
            {
                return Convert.ToInt32(beiYear.EditValue);
            }
            set { beiYear.EditValue = value; }
        }

        private BindingList<Record> _source;

        public void SetReportByEmployees(List<Record> items)
        {
            _source = new BindingList<Record>(items);
            gridControl1.DataSource = _source;
        }


        private void bbiExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridExporter.ExportToExcel(gridControl1);
        }
    }
}
