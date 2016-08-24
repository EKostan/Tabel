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
            Init();
            //beiBeginDate.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            //beiEndDate.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleIfExpanded;
            beiBeginDate.EditValue = new DateTime(2016, 7, 1);
            beiEndDate.EditValue = new DateTime(2016, 7, 16);
        }

        private GridGroupSummaryItemCollection gsiSummary;

        void Init()
        {
            gsiSummary = new GridGroupSummaryItemCollection(gridView1);
            gsiSummary.Add(SummaryItemType.Sum, "Cost");
            gridView1.GroupSummary.Assign(gsiSummary);
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
            gridControl1.BeginUpdate();

            _source = new BindingList<ReportRecord>(items);
            
            var table = CreateDataTable();

            CreateViewColumn();
            gridControl1.DataSource = table;
            //gridControl1.RefreshDataSource();
            //gridView1.PopulateColumns();
            //gridView1.BestFitColumns();


            //var view = CreateView();
            //gridControl1.MainView = view;
            //gridControl1.ViewCollection.Clear();
            //gridControl1.ViewCollection.Add(view);
            gridControl1.EndUpdate();
        }

        private const string EmployeeName = "EmployeeName";
        private const string RowType = "RowType";
        
        private const string ObjectName = "ObjectName";
        private const string ContractName = "ContractName";
        private const string SumHours = "SumHours";
        private const string SumCost = "SumCost";

        private DataTable CreateDataTable()
        {
            var table = new DataTable();

            var columns = new List<DataColumn>();

            var cRowType = new DataColumn(RowType);
            var cEmployeeName = new DataColumn(EmployeeName) { Caption = "Инженер",  };
            var cObjectName = new DataColumn(ObjectName) { Caption = "Объект" };
            var cContractName = new DataColumn(ContractName) { Caption = "Проект" };
            var cSumHours = new DataColumn(SumHours, typeof(int)) { Caption = "Итого часов1:" };
            var cSumCost = new DataColumn(SumCost, typeof(int)) { Caption = "Итого рублей:" };

            

            columns.AddRange(new[]
            {
                cRowType, cEmployeeName, cObjectName,cContractName
            });


            var first = _source.FirstOrDefault();

            if (first != null)
            {
                foreach (var dateHourse in first.DateHours)
                {
                    var col = new DataColumn(dateHourse.Date) /*{ Caption = dateHourse.Date }*/;
                    columns.Add(col);

                    
                }
            }

            columns.AddRange(new[]
            {
                cSumHours, cSumCost
            });

           


            table.Columns.AddRange(columns.ToArray());

            foreach (var reportRecord in _source)
            {
                var row = table.NewRow();
                row[RowType] = reportRecord.RecordType;
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

        private void CreateViewColumn()
        {
            int i = 0;
            var vcolumns = new List<GridColumn>()
            {
                new GridColumn() {Caption = "Инженер", Name = EmployeeName, FieldName = EmployeeName, Visible = true, VisibleIndex = i++},
                new GridColumn() {Caption = "Объект", Name = ObjectName, FieldName = ObjectName, Visible = true, VisibleIndex = i++},
                new GridColumn() {Caption = "Проект", Name = ContractName, FieldName = ContractName, Visible = true, VisibleIndex = i++},
            };


            var first = _source.FirstOrDefault();

            if (first != null)
            {
                foreach (var dateHourse in first.DateHours)
                {
                    var gcol = new GridColumn() { FieldName = dateHourse.Date, Caption = dateHourse.Date, Visible = true, VisibleIndex = i++ };
                    gcol.Width = 30;
                    vcolumns.Add(gcol);
                }
            }

            var colSumHours = new GridColumn()
            {
                Caption = "Итого часов:",
                Name = SumHours,
                FieldName = SumHours,
                Visible = true,
                VisibleIndex = i++
                //SummaryItem =
                //{
                //    FieldName = SumHours,
                //    SummaryType = SummaryItemType.Sum,
                //    DisplayFormat = @"SUM={0:c}"
                //}
            };

            vcolumns.AddRange(new[]
            {
                colSumHours,
                new GridColumn() {Caption = "Итого рублей:", Name = SumCost, FieldName = SumCost, Visible = true, VisibleIndex = i++},
            });

            gridView1.BeginUpdate();
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(vcolumns.ToArray());
            gridView1.EndUpdate();
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
                || e.Column.Name == EmployeeName
                || e.Column.Name == ObjectName
                || e.Column.Name == ContractName
                || e.Column.Name == SumHours
                || e.Column.Name == SumCost
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var s = e.CellValue as string;
            if (s != null && s ==  "0")
            {
                e.DisplayText = "";
            }

            var row = gridView1.GetDataRow(e.RowHandle) as DataRow;

            if(row == null)
                return;

            var rowType = row[RowType] is string ? (string) row[RowType] : "";



            if (rowType == "Sum")
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

        }
    }
}
