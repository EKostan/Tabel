namespace InterfaceLibrary.FileHelper
{
    partial class ChooseDirForm
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
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tePath
            // 
            this.tePath.Location = new System.Drawing.Point(13, 22);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(425, 20);
            this.tePath.TabIndex = 0;
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(458, 19);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(59, 23);
            this.btnChoosePath.TabIndex = 1;
            this.btnChoosePath.Text = "Путь";
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
            // ChooseDirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 105);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnChoosePath);
            this.Controls.Add(this.tePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseDirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор директории с данными";
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tePath;
        private DevExpress.XtraEditors.SimpleButton btnChoosePath;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.FolderBrowserDialog DirBrowser;
    }
}