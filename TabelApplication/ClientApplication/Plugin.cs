using System.Collections.Generic;
using CACore;
using CACore.FolderOpener;
using CACore.Menu;
using CACore.View;
using ClientApplication.Menu;
using ClientApplication.Menu.About;
using Core;
using Core.Module;
using Core.Plugins;
using Core.Users.Settings;

namespace ClientApplication
{
    public class Plugin
    {
        [Install]
        public static void Install()
        {
            InicializeMenu();

            SettingsController<MainSettings>.SettingsDirectory = ModuleApi.ExecutableDirectory;
            SettingsController<MainSettings>.LoadSettings();

            UserSettings.Register<UiLayoutTemplates>();

        }

        [SystemInstall]
        public static void SystemInstall()
        {
            MainMenu.AddBackstageItem(new AboutItem());
        }

        private static void InicializeMenu()
        {
            var groups = new List<IGroup>()
            {
                new Group() { Key = CommonGroupKeys.File, DisplayName = "Файл" },
                new Group() { Key = CommonGroupKeys.Search, DisplayName = "Поиск" },
                new Group() { Key = CommonGroupKeys.Journals, DisplayName = "Журналы" },
                new Group() { Key = CommonGroupKeys.Data, DisplayName = "Данные" },
                new Group() { Key = CommonGroupKeys.References, DisplayName = "Справочники" },
                new Group() { Key = CommonGroupKeys.WorkGroup, DisplayName = "Рабочая группа" },
                new Group() { Key = CommonGroupKeys.Settings, DisplayName = "Настройки" },
                new Group() { Key = CommonGroupKeys.Actions, DisplayName = "Действия" },
            };

            MainMenu.AddGroups(groups);

            var tab = new MenuTab()
            {
                Key = CommonTabKeys.General,
                DisplayName = "Главная",
                Groups = new List<IGroup>(groups)
            };

            MainMenu.AddTab(tab);

            // мешает, можно случайно ее нажать
            MainMenu.AddMenuItem(new UpdateItem(), CommonGroupKeys.Data);
            MainMenu.AddMenuItem(new SettingsItem(), CommonGroupKeys.Settings);


            MainMenu.AddBackstageItem(new HelpItem());
            MainMenu.AddBackstageItem(new ExitItem());

        }

    }
}
