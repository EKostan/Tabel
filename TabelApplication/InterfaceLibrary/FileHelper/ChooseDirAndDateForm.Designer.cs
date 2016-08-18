namespace InterfaceLibrary.FileHelper
{
    partial class ChooseDirAndDateForm
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
            this.tePath = new DevExpress.XtraEditors.TextEdit();
            this.btnChoosePath = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.DirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.deDateForName = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tePath
            // 
            this.tePath.Location = new System.Drawing.Point(12, 53);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(425, 20);
            this.tePath.TabIndex = 0;
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(457, 50);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(59, 23);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "Путь";
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
            // ChooseDirAndDateForm
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
            this.Name = "ChooseDirAndDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор директории с данными";
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateForName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tePath;
        private DevExpress.XtraEditors.SimpleButton btnChoosePath;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.FolderBrowserDialog DirBrowser;
        private DevExpress.XtraEditors.DateEdit deDateForName;
        private System.Windows.Forms.Label label1;
    }
}