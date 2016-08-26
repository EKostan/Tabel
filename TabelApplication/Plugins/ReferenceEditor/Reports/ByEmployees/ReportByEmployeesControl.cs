using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CACore.Visualizers;
using Contract;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using InterfaceLibrary;
using DevExpress.XtraGrid.Columns;

namespace ReferenceEditor.Reports.ByEmployees
{
    partial class ReportByEmployeesControl : XtraUserControl, IPresentation
    {
        public ReportByEmployeesControl()
        {
            InitializeComponent();

            beiBeginDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            var nowBegin = DateTime.Now.AddMonths(1);
            beiEndDate.EditValue = new DateTime(nowBegin.Year, nowBegin.Month, 1);
            
            //beiBeginDate.EditValue = new DateTime(2016, 7, 1);
            //beiEndDate.EditValue = new DateTime(2016, 7, 16);

            repositoryItemComboBox1.Items.Clear();
            repositoryItemComboBox1.Items.AddRange(new []
            {
                Date, Month, Quart
            });
        }

        private const string Date = "День";
        private const string Month = "Месяц";
        private const string Quart = "Квартал";

        public DateTime BeginDate
        {
            get
            {
                return (DateTime)beiBeginDate.EditValue;
            }
            set { beiBeginDate.EditValue = value; }
        }

        public DateTime EndDate
        {
            get
            {
                return (DateTime)beiEndDate.EditValue;
            }
            set { beiEndDate.EditValue = value; }
        }

        private BindingList<ReportByEmployeesRecord> _source;

        public void SetReportByEmployees(List<ReportByEmployeesRecord> items)
        {
            _source = new BindingList<ReportByEmployeesRecord>(items);

            pivotGridControl1.DataSource = _source;
            pivotGridControl1.BestFit();
            fieldDate.CollapseAll();
            fieldDate.Options.AllowExpand = DefaultBoolean.False;
            fieldDate.Width = 30;
        }



      


        private void bbiExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridExporter.ExportToExcel(pivotGridControl1);
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs e)
        {
            if (e.Field == fieldDate)
            {
                string caption = e.Info.Caption;
                e.Info.Caption = string.Empty;
                e.Painter.DrawObject(e.Info);
                Rectangle rec = new Rectangle(e.Bounds.X + 3, e.Bounds.Y - 10, e.Bounds.Width, e.Bounds.Height);
                e.GraphicsCache.DrawVString(caption, e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.GraphicsCache),
                    rec, e.Appearance.GetStringFormat(), -90);
                e.Handled = true;
            }
        }

      
        private void repositoryItemRadioGroup2_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
