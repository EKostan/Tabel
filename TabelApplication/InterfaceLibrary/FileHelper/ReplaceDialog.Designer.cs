namespace InterfaceLibrary.FileHelper
{
    partial class ReplaceDialog
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lcMessage = new DevExpress.XtraEditors.LabelControl();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbSkipAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbOwerriteAll = new DevExpress.XtraEditors.SimpleButton();
            this.sbSkip = new DevExpress.XtraEditors.SimpleButton();
            this.sbOwerrite = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.sbCancel);
            this.layoutControl1.Controls.Add(this.sbSkipAll);
            this.layoutControl1.Controls.Add(this.sbOwerriteAll);
            this.layoutControl1.Controls.Add(this.sbSkip);
            this.layoutControl1.Controls.Add(this.sbOwerrite);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 23);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(590, 137);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lcMessage
            // 
            this.lcMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lcMessage.Location = new System.Drawing.Point(0, 0);
            this.lcMessage.Name = "lcMessage";
            this.lcMessage.Padding = new System.Windows.Forms.Padding(5);
            this.lcMessage.Size = new System.Drawing.Size(136, 23);
            this.lcMessage.TabIndex = 9;
            this.lcMessage.Text = "message ds sd sd sd ds ds";
            // 
            // sbCancel
            // 
            this.sbCancel.Location = new System.Drawing.Point(285, 64);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(293, 22);
            this.sbCancel.StyleController = this.layoutControl1;
            this.sbCancel.TabIndex = 8;
            this.sbCancel.Text = "Отмена";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbSkipAll
            // 
            this.sbSkipAll.Location = new System.Drawing.Point(285, 38);
            this.sbSkipAll.Name = "sbSkipAll";
            this.sbSkipAll.Size = new System.Drawing.Size(293, 22);
            this.sbSkipAll.StyleController = this.layoutControl1;
            this.sbSkipAll.TabIndex = 7;
            this.sbSkipAll.Text = "Пропустить все";
            this.sbSkipAll.Click += new System.EventHandler(this.sbSkipAll_Click);
            // 
            // sbOwerriteAll
            // 
            this.sbOwerriteAll.Location = new System.Drawing.Point(12, 38);
            this.sbOwerriteAll.Name = "sbOwerriteAll";
            this.sbOwerriteAll.Size = new System.Drawing.Size(269, 22);
            this.sbOwerriteAll.StyleController = this.layoutControl1;
            this.sbOwerriteAll.TabIndex = 6;
            this.sbOwerriteAll.Text = "Перезаписать все";
            this.sbOwerriteAll.Click += new System.EventHandler(this.sbOwerriteAll_Click);
            // 
            // sbSkip
            // 
            this.sbSkip.Location = new System.Drawing.Point(285, 12);
            this.sbSkip.Name = "sbSkip";
            this.sbSkip.Size = new System.Drawing.Size(293, 22);
            this.sbSkip.StyleController = this.layoutControl1;
            this.sbSkip.TabIndex = 5;
            this.sbSkip.Text = "Пропустить";
            this.sbSkip.Click += new System.EventHandler(this.sbSkip_Click);
            // 
            // sbOwerrite
            // 
            this.sbOwerrite.Location = new System.Drawing.Point(12, 12);
            this.sbOwerrite.Name = "sbOwerrite";
            this.sbOwerrite.Size = new System.Drawing.Size(269, 22);
            this.sbOwerrite.StyleController = this.layoutControl1;
            this.sbOwerrite.TabIndex = 4;
            this.sbOwerrite.Text = "Перезаписать";
            this.sbOwerrite.Click += new System.EventHandler(this.sbOwerrite_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(590, 137);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbSkip;
            this.layoutControlItem2.Location = new System.Drawing.Point(273, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(297, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sbOwerrite;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(273, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbOwerriteAll;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(273, 91);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sbSkipAll;
            this.layoutControlItem4.Location = new System.Drawing.Point(273, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(297, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sbCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(273, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(297, 65);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // ReplaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 160);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.lcMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ReplaceDialog";
            this.Text = "Копирование файлов";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lcMessage;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbSkipAll;
        private DevExpress.XtraEditors.SimpleButton sbOwerriteAll;
        private DevExpress.XtraEditors.SimpleButton sbSkip;
        private DevExpress.XtraEditors.SimpleButton sbOwerrite;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}