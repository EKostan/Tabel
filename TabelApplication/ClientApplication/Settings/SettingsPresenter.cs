using System;
using CACore.Settings;
using NLog;

namespace ClientApplication.Settings
{
    class SettingsPresenter : IDisposable
    {
        private readonly ISettingsView _view;

        public SettingsPresenter(ISettingsView view)
        {
            _view = view;
            _view.SettingsTabs = SettingsApi.SettingsTabs;
            SignViewEvents();
        }



        private void SignViewEvents()
        {
            _view.OkClick += view_OkClick;
            _view.CancelClick += view_CancelClick;
        }

        void view_CancelClick(object sender, EventArgs e)
        {
            foreach (var settingsTab in SettingsApi.SettingsTabs)
            {
                try
                {
                    settingsTab.CancelSettings();
                }
                catch (Exception exeption)
                {
                    _logger.Error("Ошибка отмены настроек {0}", exeption);
                }
            }
        }

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        void view_OkClick(object sender, EventArgs e)
        {
            foreach (var settingsTab in SettingsApi.SettingsTabs)
            {
                try
                {
                    settingsTab.ApplySettings();
                }
                catch (Exception exeption)
                {
                    _logger.Error("Ошибка применения настроек {0}", exeption);
                }
            }
        }



        private void UnSignViewEvents()
        {
            _view.OkClick -= view_OkClick;
            _view.CancelClick -= view_CancelClick;
        }



        #region IDisposable Members

        public void Dispose()
        {
            UnSignViewEvents();
        }

        #endregion

        internal void ApplyModelToView()
        {
            foreach (var settingsTab in SettingsApi.SettingsTabs)
            {
                try
                {
                    settingsTab.ApplySettingsToView();
                }
                catch (Exception exeption)
                {
                    _logger.Error("Ошибка применения настроек {0}", exeption);
                }
            }
        }
    }
}