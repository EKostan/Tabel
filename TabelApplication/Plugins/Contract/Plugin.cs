using Core;
using Core.Plugins;

namespace Contract
{
    public class Plugin
    {
        [Install]
        public static void Install()
        {
            MainSystem.Instance.Services.SetService<Project>(new Project());
        }

    }
}
