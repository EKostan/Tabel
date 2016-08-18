using System;
using System.Reflection;
using CACore.About;
using CACore.Menu;
using Core;
using Core.Module;

namespace ClientApplication.Menu.About
{
    class AboutItem : BaseItemButton
    {
        public AboutItem()
        {
            this.DisplayName = "О программе";
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

        protected override void DoExecute()
        {
            var aboutDialog = (IAboutView)MainSystem.Instance.Services.GetService(typeof(IAboutView));
            aboutDialog.AboutInfo = new AboutInfo()
            {
                Version = GetAssemblyVersion(),
                Build =  GetAssemblyBuild(),
                UserName = ModuleApi.UserName,
            };

            aboutDialog.ShowAbout();
        }

    }
}
