using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CACore.Settings;
using DevExpress.XtraTab;
using NLog;

namespace UserInterface.SettingsForm
{
    class SettingsBuilder
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private XtraTabControl _tabControl;
        public SettingsBuilder(XtraTabControl tabControl)
        {
            _tabControl = tabControl;
        }


        public void Build(List<ISettingsTab> tabs)
        {
            _tabControl.TabPages.Clear();

            foreach (var settingsTab in tabs)
            {
                try
                {
                    Control control = (Control)settingsTab.Control;

                    var tabPage = new XtraTabPage();
                    tabPage.Text = settingsTab.Name;
                    tabPage.Tag = settingsTab;
                    control.Dock = DockStyle.Fill;
                    tabPage.Controls.Add(control);
                    _tabControl.TabPages.Add(tabPage);
                }
                catch (Exception e)
                {
                    _logger.Error("Ошибка создания страницы настроек {0}", e);
                }
            }
        }
    }
}