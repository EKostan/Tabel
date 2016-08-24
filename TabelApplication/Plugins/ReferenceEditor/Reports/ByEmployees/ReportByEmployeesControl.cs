using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CACore.Visualizers;
using Contract;
using DevExpress.Data;
using DevExpress.XtraEditors;
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

            //beiBeginDate.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            //beiEndDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            beiBeginDate.EditValue = new DateTime(2016, 7, 1);
            beiEndDate.EditValue = new DateTime(2016, 7, 16);
        }


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

        private BindingList<ReportRecord> _source;

        public void SetReportByEmployees(List<ReportRecord> items)
        {
            //gridControl1.BeginUpdate();

            _source = new BindingList<ReportRecord>(items);
            gridView1.Columns.Clear();
            
            var table = CreateDataTable();

            gridControl1.DataSource = table;
            gridControl1.RefreshDataSource();
            //gridView1.PopulateColumns();
            //gridView1.BestFitColumns();


            //var view = CreateView();
            //gridControl1.MainView = view;
            //gridControl1.ViewCollection.Clear();
            //gridControl1.ViewCollection.Add(view);
            //gridControl1.EndUpdate();
        }

        private const string EmployeeName = "EmployeeName";
        private const string ObjectName = "ObjectName";
        private const string ContractName = "ContractName";
        private const string SumHours = "SumHours";
        private const string SumCost = "SumCost";

        private DataTable CreateDataTable()
        {
            var table = new DataTable();

            var columns = new List<DataColumn>();

            var cEmployeeName = new DataColumn(EmployeeName) { Caption = "Инженер",  };
            var cObjectName = new DataColumn(ObjectName) { Caption = "Объект" };
            var cContractName = new DataColumn(ContractName) { Caption = "Проект" };
            var cSumHours = new DataColumn(SumHours) { Caption = "Итого часов1:" };
            var cSumCost = new DataColumn(SumCost) { Caption = "Итого рублей:" };

            var vcolumns = new List<GridColumn>()
            {
                new GridColumn() {Caption = "Инженер", Name = EmployeeName, FieldName = EmployeeName},
                new GridColumn() {Caption = "Объект", Name = ObjectName, FieldName = ObjectName},
                new GridColumn() {Caption = "Проект", Name = ContractName, FieldName = ContractName},
            };

            columns.AddRange(new[]
            {
                cEmployeeName, cObjectName,cContractName
            });


            var first = _source.FirstOrDefault();

            if (first != null)
            {
                foreach (var dateHourse in first.DateHours)
                {
                    var col = new DataColumn(dateHourse.Date) /*{ Caption = dateHourse.Date }*/;
                    columns.Add(col);

                    var gcol = new GridColumn() {Caption = dateHourse.Date};
                    //gcol.AppearanceHeader.TextOptions.
                    vcolumns.Add(gcol);
                }
            }

            columns.AddRange(new[]
            {
                cSumHours, cSumCost
            });
            vcolumns.AddRange(new []{
                new GridColumn() {Caption = "Итого часов:", Name = SumHours, FieldName = SumHours},
                new GridColumn() {Caption = "Итого рублей:", Name = SumCost, FieldName = SumCost},
            });


            table.Columns.AddRange(columns.ToArray());

            foreach (var reportRecord in _source)
            {
                var row = table.NewRow();
                row[EmployeeName] = reportRecord.EmployeeName;
                row[ObjectName] = reportRecord.ObjectName;
                row[ContractName] = reportRecord.ContractName;
                row[SumHours] = reportRecord.SumHours;
                row[SumCost] = reportRecord.SumCost;

                foreach (var item in reportRecord.DateHours)
                {
                    row[item.Date] = item.Hours;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private GridView CreateView()
        {
            var view = new GridView(gridControl1);

            var cEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "EmployeeName",
                Name = "colEmployeeName",
                Visible = true,
                VisibleIndex = 0
            };

            var cObjectName = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "ObjectName",
                Name = "colObjectName",
                Visible = true,
                VisibleIndex = 1
            };

            var cContractName = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "ContractName",
                Name = "colContractName",
                Visible = true,
                VisibleIndex = 2
            };



            //foreach (var reportRecord in _source)
            //{
            //    foreach (var dateHourse in reportRecord.DateHours)
            //    {
            //        var col = new DevExpress.XtraGrid.Columns.GridColumn
            //        {
            //            FieldName = "ContractName",
            //            Name = "colContractName",
            //            Visible = true,
            //            VisibleIndex = 2
            //        };

            //        dateHourse.Date

            //    }
            //}


            var cSumHours = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "SumHours",
                Name = "colSumHours",
                Visible = true,
                VisibleIndex = 3
            };

            var cSumCost = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "SumCost",
                Name = "colSumCost",
                Visible = true,
                VisibleIndex = 4
            };


            var ucol = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "",
                Caption = "Дата1",
                Name = "u1",
                Visible = true,
                VisibleIndex = 5,
                UnboundExpression = "133",
                UnboundType = UnboundColumnType.String
            };

            

            view.Columns.AddRange(new[] {
            cEmployeeName,
            cObjectName,
            cContractName,
            cSumHours,
            cSumCost,
            ucol});
            view.GridControl = this.gridControl1;
            view.Name = "gridView";


            return view;
        }

        private DataTable _tableSource;
        public void SetReportByEmployees(DataTable table)
        {
            _tableSource = table;
            gridControl1.DataSource = _tableSource;
        }


        private void bbiExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridExporter.ExportToExcel(gridControl1);
        }

        private Rectangle Transform(Graphics g, int degree, Rectangle r)
        {
            g.TranslateTransform(r.Width, r.Height);

            g.RotateTransform(degree);
            float cos = (float)Math.Round(Math.Cos(degree * (Math.PI / 180)), 2);
            float sin = (float)Math.Round(Math.Sin(degree * (Math.PI / 180)), 2);
            Rectangle r1 = r;
            r1.X = (int)(r.X * cos + r.Y * sin);
            r1.Y = (int)(r.X * (-sin) + r.Y * cos);
            return r1;
        }

        private void gridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
        //    private const string EmployeeName = "EmployeeName";
        //private const string ObjectName = "ObjectName";
        //private const string ContractName = "ContractName";
        //private const string SumHours = "SumHours";
        //private const string SumCost = "SumCost";

            if (e.Column == null
                || e.Column.Name == "col" + EmployeeName
                || e.Column.Name == "col" + ObjectName
                || e.Column.Name == "col" + ContractName
                || e.Column.Name == "col" + SumHours
                || e.Column.Name == "col" + SumCost
                )
                return;

            Rectangle r = e.Info.CaptionRect;
            e.Info.Caption = "";
            e.Painter.DrawObject(e.Info);
            System.Drawing.Drawing2D.GraphicsState state = e.Graphics.Save();
            StringFormat format = e.Appearance.GetTextOptions().GetStringFormat();
            format.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
            r = Transform(e.Graphics, 180, r);
            e.Graphics.DrawString(e.Column.ToString(), e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), r, format);
            e.Graphics.Restore(state);
            e.Handled = true;
        }
    }
}
