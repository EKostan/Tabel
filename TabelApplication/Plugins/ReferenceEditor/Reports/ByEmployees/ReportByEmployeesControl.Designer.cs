namespace ReferenceEditor.Reports.ByEmployees
{
    partial class ReportByEmployeesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportByEmployeesControl));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.recordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJune = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reportByEmployeesRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contractRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.beiYear = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByEmployeesRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.recordBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(638, 481);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // recordBindingSource
            // 
            this.recordBindingSource.DataSource = typeof(ReferenceEditor.Reports.ByEmployees.Record);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeName,
            this.colJan,
            this.colFeb,
            this.colMarch,
            this.colApr,
            this.colMay,
            this.colJune,
            this.colJule,
            this.colAug,
            this.colSep,
            this.colOct,
            this.colNov,
            this.colDec});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Сотрудник";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 0;
            // 
            // colJan
            // 
            this.colJan.Caption = "Январь";
            this.colJan.FieldName = "Jan";
            this.colJan.Name = "colJan";
            this.colJan.Visible = true;
            this.colJan.VisibleIndex = 1;
            // 
            // colFeb
            // 
            this.colFeb.Caption = "Февраль";
            this.colFeb.FieldName = "Feb";
            this.colFeb.Name = "colFeb";
            this.colFeb.Visible = true;
            this.colFeb.VisibleIndex = 2;
            // 
            // colMarch
            // 
            this.colMarch.Caption = "Март";
            this.colMarch.FieldName = "March";
            this.colMarch.Name = "colMarch";
            this.colMarch.Visible = true;
            this.colMarch.VisibleIndex = 3;
            // 
            // colApr
            // 
            this.colApr.Caption = "Апрель";
            this.colApr.FieldName = "Apr";
            this.colApr.Name = "colApr";
            this.colApr.Visible = true;
            this.colApr.VisibleIndex = 4;
            // 
            // colMay
            // 
            this.colMay.Caption = "Май";
            this.colMay.FieldName = "May";
            this.colMay.Name = "colMay";
            this.colMay.Visible = true;
            this.colMay.VisibleIndex = 5;
            // 
            // colJune
            // 
            this.colJune.Caption = "Июнь";
            this.colJune.FieldName = "June";
            this.colJune.Name = "colJune";
            this.colJune.Visible = true;
            this.colJune.VisibleIndex = 6;
            // 
            // colJule
            // 
            this.colJule.Caption = "Июль";
            this.colJule.FieldName = "Jule";
            this.colJule.Name = "colJule";
            this.colJule.Visible = true;
            this.colJule.VisibleIndex = 7;
            // 
            // colAug
            // 
            this.colAug.Caption = "Август";
            this.colAug.FieldName = "Aug";
            this.colAug.Name = "colAug";
            this.colAug.Visible = true;
            this.colAug.VisibleIndex = 8;
            // 
            // colSep
            // 
            this.colSep.Caption = "Сентябрь";
            this.colSep.FieldName = "Sep";
            this.colSep.Name = "colSep";
            this.colSep.Visible = true;
            this.colSep.VisibleIndex = 9;
            // 
            // colOct
            // 
            this.colOct.Caption = "Октябрь";
            this.colOct.FieldName = "Oct";
            this.colOct.Name = "colOct";
            this.colOct.Visible = true;
            this.colOct.VisibleIndex = 10;
            // 
            // colNov
            // 
            this.colNov.Caption = "Ноябрь";
            this.colNov.FieldName = "Nov";
            this.colNov.Name = "colNov";
            this.colNov.Visible = true;
            this.colNov.VisibleIndex = 11;
            // 
            // colDec
            // 
            this.colDec.Caption = "Декабрь";
            this.colDec.FieldName = "Dec";
            this.colDec.Name = "colDec";
            this.colDec.Visible = true;
            this.colDec.VisibleIndex = 12;
            // 
            // reportByEmployeesRecordBindingSource
            // 
            this.reportByEmployeesRecordBindingSource.DataSource = typeof(Contract.ReportByEmployeesRecord);
            // 
            // contractRecordBindingSource
            // 
            this.contractRecordBindingSource.DataSource = typeof(Contract.ContractRecord);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiExportToExcel,
            this.beiYear});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.beiYear),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToExcel)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiExportToExcel
            // 
            this.bbiExportToExcel.Caption = "Add";
            this.bbiExportToExcel.Id = 0;
            this.bbiExportToExcel.ImageIndex = 3;
            this.bbiExportToExcel.Name = "bbiExportToExcel";
            this.bbiExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportToExcel_ItemClick);
            // 
            // beiYear
            // 
            this.beiYear.Caption = "Укажите год";
            this.beiYear.Edit = this.repositoryItemTextEdit1;
            this.beiYear.EditValue = 2016;
            this.beiYear.EditWidth = 66;
            this.beiYear.Id = 3;
            this.beiYear.Name = "beiYear";
            this.beiYear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(638, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Size = new System.Drawing.Size(638, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 481);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(638, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 481);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("additem_16x16.png", "office2013/actions/additem_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/additem_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "additem_16x16.png");
            this.imageCollection1.InsertGalleryImage("removeitem_16x16.png", "office2013/actions/removeitem_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/removeitem_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "removeitem_16x16.png");
            this.imageCollection1.InsertGalleryImage("save_16x16.png", "office2013/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/save/save_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "save_16x16.png");
            this.imageCollection1.Images.SetKeyName(3, "microsoft_office_2003_excel (1).png");
            // 
            // ReportByEmployeesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportByEmployeesControl";
            this.Size = new System.Drawing.Size(638, 505);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportByEmployeesRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiExportToExcel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.BindingSource contractRecordBindingSource;
        private System.Windows.Forms.BindingSource reportByEmployeesRecordBindingSource;
        private System.Windows.Forms.BindingSource recordBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colJan;
        private DevExpress.XtraGrid.Columns.GridColumn colFeb;
        private DevExpress.XtraGrid.Columns.GridColumn colMarch;
        private DevExpress.XtraGrid.Columns.GridColumn colApr;
        private DevExpress.XtraGrid.Columns.GridColumn colMay;
        private DevExpress.XtraGrid.Columns.GridColumn colJune;
        private DevExpress.XtraGrid.Columns.GridColumn colJule;
        private DevExpress.XtraGrid.Columns.GridColumn colAug;
        private DevExpress.XtraGrid.Columns.GridColumn colSep;
        private DevExpress.XtraGrid.Columns.GridColumn colOct;
        private DevExpress.XtraGrid.Columns.GridColumn colNov;
        private DevExpress.XtraGrid.Columns.GridColumn colDec;
        private DevExpress.XtraBars.BarEditItem beiYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
