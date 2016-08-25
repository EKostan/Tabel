using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CACore;
using CACore.FolderOpener;
using CACore.Splash;
using CACore.View;
using ClientApplication.Api;
using Core;
using Core.Module;
using InterfaceLibrary;
using UserInterface;
using UserInterface.Splash;

namespace ClientApplication
{
    static class Program
    {

        private static MainForm _view;
        private static Presenter _presenter;

        private static ManualResetEvent _mre = new ManualResetEvent(false);
        private static Mutex _mutex;

        private static bool InstanceExists()
        {
            bool createdNew;
            _mutex = new Mutex(false, "SomeApplication1", out createdNew);
            return (!createdNew);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (InstanceExists())
            {
                Dialogs.ErrorMessageBox("Приложение уже запущено!");
                return;
            }

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

                SystemApi.SystemLogger.Info("#start Программа запущена");
                SystemApi.SystemLogger.Info(string.Format("Версия {0}", GetAssemblyVersion()));
                SystemApi.SystemLogger.Info(string.Format("Билд {0}", GetAssemblyBuild()));



                _view = new MainForm();
                MainSystem.Instance.Services.SetService(typeof(IMainView), _view);

                var splash = new MainSplashScreen();
                MainSystem.Instance.Services.SetService(typeof(ISplashView), splash);

                splash.Show();
                splash.ShowStatus("Начат процесс инициализации модуля.");

                _presenter = new Presenter(_view, splash);

                if (args != null && args.Length > 0)
                {
                    _presenter.UserName = args[0];
                }

                _presenter.InitPresenter();
                
                splash.ShowStatus("Процесс инициализации модуля завершен.");
                splash.Hide();

                using (_presenter)
                {
                    Application.Run(_view);
                }

            }
            finally
            {
                SettingsController<MainSettings>.SaveSettings();
            }

        }

       

        private static string GetAssemblyVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyFileVersionAttribute versionAttribute =
                (AssemblyFileVersionAttribute)
                Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute));

            string s = versionAttribute.Version;

            return s;
        }

        private static string GetAssemblyBuild()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string s = (assembly.GetName()).Version.ToString();
            return s;
        }

    }
}
