using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Forms
{
    public partial class CommentForm : XtraForm
    {
        /// <summary>
        /// Если значение true, то указывать комментарий необязательно
        /// </summary>
        public bool IsCommentOptional { get; set; }

        public string Comment { get { return tbComment.Text; } }

        public CommentForm()
        {
            InitializeComponent();
        }

        private bool IsCommentOk()
        {
            if (IsCommentOptional)
            {
                return true;
            }
            if (string.IsNullOrEmpty(tbComment.Text))
            {
                Dialogs.WarningMessageBox("Не указан комментарий.");
                return false;
            }
            return true;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (IsCommentOk())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}