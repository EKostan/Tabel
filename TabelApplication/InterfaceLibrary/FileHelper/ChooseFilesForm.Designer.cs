namespace InterfaceLibrary.FileHelper
{
    partial class ChooseFilesForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tePath = new InterfaceLibrary.FileHelper.TextEditWithPasteEvent();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(431, 20);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(98, 23);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "Выбрать файлы";
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(187, 62);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(145, 31);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Загрузить данные";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.ValidateNames = false;
            // 
            // tePath
            // 
            this.tePath.Location = new System.Drawing.Point(13, 22);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(407, 20);
            this.tePath.TabIndex = 0;
            // 
            // ChooseFilesForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 105);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.tePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseFilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор данных";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ChooseFilesForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ChooseFilesForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextEditWithPasteEvent tePath;
        private DevExpress.XtraEditors.SimpleButton btnChoosePath;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}