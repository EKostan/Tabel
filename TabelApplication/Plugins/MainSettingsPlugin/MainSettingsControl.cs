using System;
using System.IO;
using System.Windows.Forms;
using CACore;
using CACore.View;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MainSettingsPlugin
{
    partial class MainSettingsControl : XtraUserControl, IMainSettingsView
    {
        public MainSettingsControl()
        {
            InitializeComponent();

        }

        private void MainSettingsControl_Load(object sender, EventArgs e)
        {
        }

        public string DbFilePath
        {
            get { return beDbFilePath.Text; }
            set { beDbFilePath.Text = value; }
        }
        
        
        string SelectFile(string path)
        {
            using (var openDialog = new OpenFileDialog())
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    return openDialog.FileName;
                }
            }

            return path;
        }

       

        private void beSaveKhdDefaultDir_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DbFilePath = SelectFile(DbFilePath);
        }

       

    }
}
