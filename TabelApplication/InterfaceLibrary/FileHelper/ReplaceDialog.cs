using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.FileHelper
{
    public partial class ReplaceDialog : DevExpress.XtraEditors.XtraForm
    {
        public ReplaceDialog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.Closed += ReplaceDialog_Closed;
            lcMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lcMessage.AutoSizeMode = LabelAutoSizeMode.Vertical;
        }

        void ReplaceDialog_Closed(object sender, EventArgs e)
        {
            if(ReplaceDialogResult == ReplaceDialogResult.None)
                ReplaceDialogResult = ReplaceDialogResult.Cancel;
        }

        public string Message
        {
            get { return lcMessage.Text; }
            set { Update(() => { lcMessage.Text = value; }); }
        }

        #region extra

        private delegate void GuiDelegate();

        void Update(GuiDelegate funk)
        {
            if (InvokeRequired)
            {
                Invoke(funk);
            }
            else
            {
                funk();
            }
        }

        #endregion

        public ReplaceDialogResult ReplaceDialogResult { get; set; }

        private void sbOwerrite_Click(object sender, EventArgs e)
        {
            ReplaceDialogResult = ReplaceDialogResult.Owerrite;
            Close();
        }

        private void sbOwerriteAll_Click(object sender, EventArgs e)
        {
            ReplaceDialogResult = ReplaceDialogResult.OwerriteAll;
            Close();
        }

        private void sbSkip_Click(object sender, EventArgs e)
        {
            ReplaceDialogResult = ReplaceDialogResult.Skip;
            Close();
        }

        private void sbSkipAll_Click(object sender, EventArgs e)
        {
            ReplaceDialogResult = ReplaceDialogResult.SkipAll;
            Close();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            ReplaceDialogResult = ReplaceDialogResult.Cancel;
            Close();
        }

    }

    public enum ReplaceDialogResult
    {
        None, 
        Cancel,
        Owerrite,
        OwerriteAll, 
        Skip,
        SkipAll
    }
}