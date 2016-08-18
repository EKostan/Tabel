using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.FileHelper
{
    public partial class ChooseFilesForm : XtraForm
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
                openFileDialog1.InitialDirectory = _folderBrowserDir;
            }
        }

        public ChooseFilesForm()
        {
            InitializeComponent();

            _textQuotationRegex = new Regex("\"(.*?)\"|([^\\s]+)", RegexOptions.Compiled);
            _foldersPath = new List<string>();
            _filesPath = new List<string>();

            tePath.OnPaste += tePath_OnPaste;
        }


        private readonly Regex _textQuotationRegex;
        private IReadOnlyList<string> _foldersPath;
        private IReadOnlyList<string> _filesPath;

        void tePath_OnPaste(object sender, PasteEventArgs e)
        {
            var textEdit1 = sender as TextEditWithPasteEvent;

            if (textEdit1 == null) return;

            var paths = _textQuotationRegex.Matches(e.Text).Cast<Match>()
                .Select(x =>
                {
                    var g = x.Groups.OfType<Group>().Skip(1).FirstOrDefault(y => y.Success);
                    return g == null ? string.Empty : g.Value;
                })
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            Paste(paths);
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = _folderBrowserDir;
            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = string.Empty;

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileNames.Length > 0)
            {
                tePath.Text = string.Join(";", openFileDialog1.FileNames);
            }
        }

        public IReadOnlyList<string> FoldersPath
        {
            get { return _foldersPath; }
            private set { _foldersPath = value; }
        }

        public IReadOnlyList<string> FilesPath
        {
            get { return _filesPath; }
            private set { _filesPath = value; }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var error = false;
            var p = tePath.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> foldersPath = new List<string>();
            List<string> filesPath = new List<string>();

            for (var i = 0; i < p.Length; i++)
            {
                if (!File.Exists(p[i]))
                {
                    error = true;
                    if (!Directory.Exists(p[i]))
                    {
                        continue;
                    }
                }

                FileAttributes attr = File.GetAttributes(p[i]);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    if (!foldersPath.Contains(p[i]))
                        foldersPath.Add(p[i]);
                }
                else
                {
                    if (!filesPath.Contains(p[i]))
                        filesPath.Add(p[i]);
                }
            }

            if (filesPath.Count == 0)
            {
                Dialogs.WarningMessageBox("Не указан или неправильно указан путь!");
                return;
            }

            if (foldersPath.Count > 0)
            {
                Dialogs.WarningMessageBox("Выбранн путь до каталога!\nВыберите путь до файлов");
                return;
            }

            if (error &&
                Dialogs.Question(
                    "Один или более путь к файлу задан неверно и скопирован не будет.\nПродолжить копирование?") ==
                DialogResult.No)
            {
                return;
            }

            FoldersPath = foldersPath.AsReadOnly();
            FilesPath = filesPath.AsReadOnly();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ChooseFilesForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            Paste(files);
        }

        private void Paste(string[] files)
        {
            var t = tePath.Text;
            if (!string.IsNullOrEmpty(t))
            {
                t += ";";
            }
            var @join = string.Join(";", files);
            if (tePath.SelectionLength == tePath.Text.Length)
            {
                t = @join;
            }
            else
            {
                t += @join;
            }

            tePath.Text = t;
        }

        private void ChooseFilesForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}