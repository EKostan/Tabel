namespace ReferenceEditor.Time
{
    partial class TimeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeControl));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.timeRecordBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricbEmployees = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colContractCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricbContracts = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricbJobs = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ricbObjects = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.timeRecordBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource)).BeginInit();
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
            this.bbiAdd,
            this.bbiDelete,
            this.bbiSave});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSave)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiAdd
            // 
            this.bbiAdd.Caption = "Добавить";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageIndex = 0;
            this.bbiAdd.Name = "bbiAdd";
            this.bbiAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "удалить";
            this.bbiDelete.Id = 1;
            this.bbiDelete.ImageIndex = 1;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Сохранить";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageIndex = 2;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(695, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Size = new System.Drawing.Size(695, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 540);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(695, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 540);
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
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.timeRecordBindingSource2;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ricbJobs,
            this.ricbObjects,
            this.ricbContracts,
            this.ricbEmployees,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(695, 540);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // timeRecordBindingSource2
            // 
            this.timeRecordBindingSource2.DataSource = typeof(Contract.TimeRecord);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeName,
            this.colContractCode,
            this.colDate,
            this.colHours});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridView1_RowDeleted);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Сотрудник";
            this.colEmployeeName.ColumnEdit = this.ricbEmployees;
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 0;
            // 
            // ricbEmployees
            // 
            this.ricbEmployees.AutoHeight = false;
            this.ricbEmployees.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricbEmployees.Name = "ricbEmployees";
            this.ricbEmployees.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ricbEmployees.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ricbEmployees_EditValueChanging);
            // 
            // colContractCode
            // 
            this.colContractCode.Caption = "Код проекта";
            this.colContractCode.ColumnEdit = this.ricbContracts;
            this.colContractCode.FieldName = "ContractCode";
            this.colContractCode.Name = "colContractCode";
            this.colContractCode.Visible = true;
            this.colContractCode.VisibleIndex = 1;
            // 
            // ricbContracts
            // 
            this.ricbContracts.AutoHeight = false;
            this.ricbContracts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricbContracts.Name = "ricbContracts";
            this.ricbContracts.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ricbContracts.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ricbContracts_EditValueChanging);
            // 
            // colDate
            // 
            this.colDate.Caption = "Дата";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            // 
            // colHours
            // 
            this.colHours.Caption = "Количество отработанных часов";
            this.colHours.FieldName = "Hours";
            this.colHours.Name = "colHours";
            this.colHours.Visible = true;
            this.colHours.VisibleIndex = 3;
            // 
            // ricbJobs
            // 
            this.ricbJobs.AutoHeight = false;
            this.ricbJobs.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricbJobs.Name = "ricbJobs";
            this.ricbJobs.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ricbJobs_EditValueChanging);
            // 
            // ricbObjects
            // 
            this.ricbObjects.AutoHeight = false;
            this.ricbObjects.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricbObjects.Name = "ricbObjects";
            this.ricbObjects.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ricbObjects_EditValueChanging);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // timeRecordBindingSource1
            // 
            this.timeRecordBindingSource1.DataSource = typeof(Contract.TimeRecord);
            // 
            // timeRecordBindingSource
            // 
            this.timeRecordBindingSource.DataSource = typeof(Contract.TimeRecord);
            // 
            // TimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TimeControl";
            this.Size = new System.Drawing.Size(695, 564);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeRecordBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource timeRecordBindingSource;
        private System.Windows.Forms.BindingSource timeRecordBindingSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricbJobs;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricbObjects;
        private System.Windows.Forms.BindingSource timeRecordBindingSource2;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHours;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricbContracts;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricbEmployees;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}
