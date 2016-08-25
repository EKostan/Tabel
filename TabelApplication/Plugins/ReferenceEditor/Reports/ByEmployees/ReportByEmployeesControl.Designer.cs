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
            DevExpress.XtraPivotGrid.PivotGridCustomTotal pivotGridCustomTotal5 = new DevExpress.XtraPivotGrid.PivotGridCustomTotal();
            DevExpress.XtraPivotGrid.PivotGridCustomTotal pivotGridCustomTotal6 = new DevExpress.XtraPivotGrid.PivotGridCustomTotal();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.beiBeginDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.beiEndDate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bbiExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemRadioGroup2 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldEmployee = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldContract = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldObjectName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
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
            this.beiBeginDate,
            this.beiEndDate});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemComboBox1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemRadioGroup2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.beiBeginDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.beiEndDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToExcel)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // beiBeginDate
            // 
            this.beiBeginDate.Caption = "C";
            this.beiBeginDate.Edit = this.repositoryItemDateEdit1;
            this.beiBeginDate.EditWidth = 139;
            this.beiBeginDate.Id = 5;
            this.beiBeginDate.Name = "beiBeginDate";
            this.beiBeginDate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // beiEndDate
            // 
            this.beiEndDate.Caption = "По";
            this.beiEndDate.Edit = this.repositoryItemDateEdit2;
            this.beiEndDate.EditWidth = 123;
            this.beiEndDate.Id = 6;
            this.beiEndDate.Name = "beiEndDate";
            this.beiEndDate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // bbiExportToExcel
            // 
            this.bbiExportToExcel.Caption = "Add";
            this.bbiExportToExcel.Id = 0;
            this.bbiExportToExcel.ImageIndex = 3;
            this.bbiExportToExcel.Name = "bbiExportToExcel";
            this.bbiExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportToExcel_ItemClick);
            // 
            // repositoryItemRadioGroup2
            // 
            this.repositoryItemRadioGroup2.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "День"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Месяц"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Квартал"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Год")});
            this.repositoryItemRadioGroup2.Name = "repositoryItemRadioGroup2";
            this.repositoryItemRadioGroup2.EditValueChanged += new System.EventHandler(this.repositoryItemRadioGroup2_EditValueChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(820, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Size = new System.Drawing.Size(820, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(820, 24);
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
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldDate,
            this.fieldEmployee,
            this.fieldContract,
            this.pivotGridField1,
            this.pivotGridField2,
            this.fieldObjectName,
            this.pivotGridField3,
            this.pivotGridField4});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 24);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(820, 481);
            this.pivotGridControl1.TabIndex = 4;
            this.pivotGridControl1.CustomDrawFieldValue += new DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventHandler(this.pivotGridControl1_CustomDrawFieldValue);
            // 
            // fieldDate
            // 
            this.fieldDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldDate.AreaIndex = 0;
            this.fieldDate.Caption = "День";
            this.fieldDate.FieldName = "Date";
            this.fieldDate.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Date;
            this.fieldDate.Name = "fieldDate";
            this.fieldDate.Options.ReadOnly = true;
            this.fieldDate.UnboundFieldName = "fieldDate";
            // 
            // fieldEmployee
            // 
            this.fieldEmployee.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldEmployee.AreaIndex = 0;
            this.fieldEmployee.Caption = "Инженер";
            this.fieldEmployee.FieldName = "EmployeeName";
            this.fieldEmployee.Name = "fieldEmployee";
            // 
            // fieldContract
            // 
            this.fieldContract.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldContract.AreaIndex = 1;
            this.fieldContract.Caption = "Проект";
            this.fieldContract.FieldName = "ContractCode";
            this.fieldContract.Name = "fieldContract";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Caption = "Часы";
            this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            pivotGridCustomTotal5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.CustomTotals.AddRange(new DevExpress.XtraPivotGrid.PivotGridCustomTotal[] {
            pivotGridCustomTotal5});
            this.pivotGridField1.FieldName = "Hours";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.Width = 60;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Caption = "Стоимость";
            this.pivotGridField2.CellFormat.FormatString = "c0";
            this.pivotGridField2.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            pivotGridCustomTotal6.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField2.CustomTotals.AddRange(new DevExpress.XtraPivotGrid.PivotGridCustomTotal[] {
            pivotGridCustomTotal6});
            this.pivotGridField2.FieldName = "Cost";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.ReadOnly = true;
            this.pivotGridField2.Options.ShowValues = false;
            this.pivotGridField2.ValueFormat.FormatString = "c0";
            this.pivotGridField2.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // fieldObjectName
            // 
            this.fieldObjectName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldObjectName.AreaIndex = 2;
            this.fieldObjectName.Caption = "Объект";
            this.fieldObjectName.FieldName = "ObjectName";
            this.fieldObjectName.Name = "fieldObjectName";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField3.AreaIndex = 1;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField3.Options.ShowGrandTotal = false;
            this.pivotGridField3.Options.ShowValues = false;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField4.AreaIndex = 2;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField4.Options.ShowGrandTotal = false;
            this.pivotGridField4.Options.ShowValues = false;
            // 
            // ReportByEmployeesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ReportByEmployeesControl";
            this.Size = new System.Drawing.Size(820, 505);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiExportToExcel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem beiBeginDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem beiEndDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldEmployee;
        private DevExpress.XtraPivotGrid.PivotGridField fieldContract;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldObjectName;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
    }
}
