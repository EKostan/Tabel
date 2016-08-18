using System.Reflection;
using System.Windows.Forms;
using CACore.Settings;
using CACore.View;
using ClientApplication.Settings;
using Core;
using NLog;

namespace ClientApplication.Api
{
    public class SystemApi
    {
        public static Logger SystemLogger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Закрыть приложение
        /// </summary>
        public static void Exit()
        {
            var view = MainSystem.Instance.Services.GetService<IMainView>();
            view.CloseView();
        }

        public static void ExitWithError(string error)
        {
            var view = MainSystem.Instance.Services.GetService<IMainView>();
            view.ShowError(error + "\r\nПриложение будет закрыто.");
            view.CloseView();
        }
        
        public static void ShowError(string error)
        {
            var view = MainSystem.Instance.Services.GetService<IMainView>();
            view.ShowError(error);
        }



        /// <summary>
        /// Возвращает имя сборки.
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyName()
        {
            return Assembly.GetAssembly(typeof(SystemApi)).GetName().Name;
        }


        public static void ShowSettingsDialog()
        {
            var settingsView = MainSystem.Instance.Services.GetService<ISettingsView>();

            var presenter = new SettingsPresenter(settingsView);

            var settingsDialog = settingsView as Form;

            if (settingsDialog != null)
            {
                settingsDialog.StartPosition = FormStartPosition.CenterScreen;
                presenter.ApplyModelToView();

                if (settingsDialog.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

    }
}
