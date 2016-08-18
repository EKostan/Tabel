using System;
using System.Reflection;
using CACore.About;
using CACore.Settings;
using Core;
using Core.Plugins;
using UserInterface.Menu;

namespace UserInterface
{

    public class Plugin
    {
        [Install]
        public static void Install()
        {
            Type tp = typeof(DevExpress.Utils.About.Utility);
            tp.InvokeMember("staticAboutShown", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.SetField, null, null, new object[] { true });

            //var view = new MainForm();
            //MainSystem.Instance.Services.SetServiceSafe(typeof(IMainView), view);

           

        }

        [SystemInstall]
        public static void SystemInstall()
        {
            var settingsForm = new SettingsForm.SettingsForm();
            MainSystem.Instance.Services.SetService(typeof(ISettingsView), settingsForm);

            var aboutControl = new AboutDialog();
            MainSystem.Instance.Services.SetService(typeof(IAboutView), aboutControl);

        }


    }
}
