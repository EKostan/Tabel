
using System.Collections.Generic;
using System.IO;

namespace InterfaceLibrary.FileHelper
{
    class FileHelperWithFilterLogic : FileHelperLogic
    {
        /// <summary>
        /// Будут скопирвоаны только файлы, содержищие в имени эту строку
        /// </summary>
        public string NameFilter { get; set; }

        protected override bool CopyFilesToSpecPath(
            IEnumerable<FileInfo> files, string toPath, ref ReplaceDialogResult replaceDialogResult)
        {
            if (string.IsNullOrEmpty(NameFilter)) return true;
            foreach (FileInfo file in files)
            {
                if (Stop)
                {
                    OnCanceled();
                    return false;
                }
                if (!file.Name.ToLower().Contains(NameFilter))
                {
                    continue;
                }
                OnFileCopying(file.Name);
                string temppath = Path.Combine(toPath, file.Name);
                file.CopyTo(temppath, true);
            }
            return true;
        }

        /// <summary>
        /// Копирует файлы из поддиректорий в одну директорию
        /// </summary>
        protected override bool CopySubDirsToSpecPath(
            IEnumerable<DirectoryInfo> dirs, string toPath, ref ReplaceDialogResult replaceDialogResult)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                if (Stop)
                {
                    OnCanceled();
                    return false;
                }
                    
                DoDirectoryCopy(subdir.FullName, toPath, ref replaceDialogResult);
            }
            return true;
        }
    }
}
