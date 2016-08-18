using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CACore.Settings;
using DevExpress.XtraEditors;

namespace UserInterface.SettingsForm
{
    public partial class SettingsForm : XtraForm, ISettingsView
    {
        private SettingsBuilder _settingsBuilder;
        public SettingsForm()
        {
            InitializeComponent();
            _settingsBuilder = new SettingsBuilder(xtraTabControl1);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            if (CancelClick != null)
                CancelClick(this, null);
            
            Close();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
            if (OkClick != null)
                OkClick(this, null);

            Close();
        }

        public event EventHandler OkClick;
        public event EventHandler CancelClick;


        private List<ISettingsTab> _settingsTabs = new List<ISettingsTab>();

        public List<ISettingsTab> SettingsTabs
        {
            get { return _settingsTabs; }
            set
            {
                _settingsTabs = value;
                Build();
            }
        }

        

        private void Build()
        {

            _settingsBuilder.Build(_settingsTabs);
        }
    }
}
