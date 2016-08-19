using System;
using CACore;
using CACore.Settings;
using Core;

namespace MainSettingsPlugin
{
    internal class MainSettingsPresenter : ISettingsTab, IDisposable
    {
        private MainSettingsControl _view;

        public MainSettingsPresenter()
        {
            LoadSettings();
            _view = new MainSettingsControl();

            ApplySettingsToView();
            SignViewEvents();
        }



        private void SignViewEvents()
        {
        }


        private void ApplyViewToSettings()
        {
            SettingsController<MainSettings>.Settings.DbFilePath = _view.DbFilePath;
        }

        public void ApplySettingsToView()
        {
            _view.DbFilePath = SettingsController<MainSettings>.Settings.DbFilePath;
        }

        private void UnSignViewEvents()
        {
        }



        #region IDisposable Members

        public void Dispose()
        {
            UnSignViewEvents();
        }

        #endregion

        public string Name
        {
            get { return "Основные"; }
        }

        public object Control
        {
            get { return _view; }
        }

        public void ApplySettings()
        {
            ApplyViewToSettings();
            SettingsController<MainSettings>.SaveSettings();
        }


        public void CancelSettings()
        {
            
        }


        public void LoadSettings()
        {
            SettingsController<MainSettings>.LoadSettings();
        }
    }
}
