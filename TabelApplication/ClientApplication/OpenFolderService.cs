using System.Diagnostics;
using System.IO;
using CACore.FolderOpener;
using Core;
using InterfaceLibrary;

namespace ClientApplication
{
    internal class OpenFolderService : IOpenFolderService
    {
        readonly IOpenFolder _explorer = new ExplorerFolderOpener();

        public IOpenFolder GetFolderOpener(OpenFolderSettings settings)
        {
            return settings.UseExplorer
                ? _explorer
                : new ExternalProgramFolderOpener(SettingsController<OpenFolderSettings>.Settings.PathToTC);
        }

        public IOpenFolder GetFolderOpenerForDownload(OpenFolderSettings settings)
        {
            return settings.UseExplorerForDownload
                ? _explorer
                : new ExternalProgramFolderOpener(SettingsController<OpenFolderSettings>.Settings.PathToTC);
        }

        private class ExplorerFolderOpener : IOpenFolder
        {
            public void OpenFolder(string path)
            {
                Process.Start(path);
            }

            public void OpenFolderWithFile(string path)
            {
                if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", " /select, \"" + path + "\""));
                }
            }
        }
        private class ExternalProgramFolderOpener : IOpenFolder
        {
            private readonly string _path;

            public ExternalProgramFolderOpener(string path)
            {
                _path = path;
            }

            public void OpenFolder(string path)
            {
                if (!File.Exists(_path))
                {
                    Dialogs.WarningMessageBox("Не задан или задан неверно путь к исполняемому файлу,\nнеобходимо задать его в настройках");
                    return;
                }
                if (Directory.Exists(path))
                {
                    Process.Start(_path, " /T /O \"" + path + "\"");
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }

            public void OpenFolderWithFile(string path)
            {
                OpenFolder(path);
            }
        }
    }
}