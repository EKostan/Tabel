using CACore.Splash;
using Core;
using Core.Module;
using NLog;

namespace ClientApplication
{
    

    internal class ModuleActivator
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public ISplashView SplashView { get; set; }

        public void Activate(string userName = "")
        {
            SplashView.ShowStatus("Идет процесс сборки плагинов...");
            CoreActivator.ActivateMessage += CoreActivator_ActivateMessage;
            CoreActivator.Activate();
            CoreActivator.ActivateMessage -= CoreActivator_ActivateMessage;
            SplashView.ShowStatus("Процесс сборки плагинов завершен.");

            ModuleApi.ModuleId = ModuleApi.GenerateModuleId("Client");
            //ModuleApi.UserName = UserPrincipal.Current.SamAccountName;
            ModuleApi.UserName = string.IsNullOrEmpty(userName) ? System.Environment.UserName : userName;
            _logger.Info("Программа запущена под пользователем Windows: \"{0}\"", ModuleApi.UserName);
        }

        void CoreActivator_ActivateMessage(object sender, string e)
        {
            SplashView.ShowStatus(e);
        }

    }
}
