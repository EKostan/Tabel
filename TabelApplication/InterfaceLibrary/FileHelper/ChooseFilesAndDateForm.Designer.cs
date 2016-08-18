namespace InterfaceLibrary.FileHelper
{
    partial class ChooseFilesAndDateForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChoosePath = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.deDateForName = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tePath = new InterfaceLibrary.FileHelper.TextEditWithPasteEvent();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(416, 50);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(100, 23);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "Выбрать файлы";
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(186, 93);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(145, 31);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Загрузить данные";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // deDateForName
            // 
            this.deDateForName.EditValue = null;
            this.deDateForName.Location = new System.Drawing.Point(260, 13);
            this.deDateForName.Name = "deDateForName";
            this.deDateForName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateForName.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateForName.Size = new System.Drawing.Size(177, 20);
            this.deDateForName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Дата получения материала от заказчика:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.ValidateNames = false;
            // 
            // tePath
            // 
            this.tePath.AllowDrop = true;
            this.tePath.Location = new System.Drawing.Point(12, 53);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(398, 20);
            this.tePath.TabIndex = 0;
            // 
            // ChooseFilesAndDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 136);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deDateForName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.tePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseFilesAndDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор данных";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ChooseFilesAndDateForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ChooseFilesAndDateForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextEditWithPasteEvent tePath;
        private DevExpress.XtraEditors.SimpleButton btnChoosePath;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.DateEdit deDateForName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}