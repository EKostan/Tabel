using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.FileHelper
{
    public partial class ChooseDirForm : XtraForm
    {
        public string Title
        {
            set
            {
                if (value != null)
                    Text = value;
            }
        }

        public string ButtonName
        {
            set
            {
                if (value != null)
                    btnLoad.Text = value;
            }
        }

        public string Path
        {
            get
            {
                return tePath.Text;
            }
            set
            {
                tePath.Text = value;
            }
        }

        string _folderBrowserDir = String.Empty;
        public string FolderBrowserDir
        {
            get { return _folderBrowserDir; }
            set
            {
                _folderBrowserDir = value;
                DirBrowser.SelectedPath = _folderBrowserDir;
            }
        }

        public ChooseDirForm()
        {
            InitializeComponent();
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            DirBrowser.SelectedPath = _folderBrowserDir;
            DirBrowser.ShowDialog();
            if (DirBrowser.SelectedPath != null)
            {
                tePath.Text = DirBrowser.SelectedPath;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tePath.Text) || !Directory.Exists(tePath.Text))
            {
                Dialogs.WarningMessageBox("Неправильно указан каталог!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}