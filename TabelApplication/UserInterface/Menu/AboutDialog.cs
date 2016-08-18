using System;
using CACore.About;
using DevExpress.XtraEditors;

namespace UserInterface.Menu
{
    internal partial class AboutDialog : XtraForm, IAboutView
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        public AboutInfo AboutInfo { get; set; }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            propertyGridControl1.SelectedObject = AboutInfo;
        }

        public void ShowAbout()
        {
            ShowDialog();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}