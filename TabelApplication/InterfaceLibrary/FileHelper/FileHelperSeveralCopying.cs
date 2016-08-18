using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InterfaceLibrary.FileHelper
{
    class FileHelperSeveralCopying : FileHelperLogic
    {
        public List<string> PathsFrom { get; set; } 
        public List<string> PathsTo { get; set; }

        public override void DirectoryCopy()
        {
            Thread thread = null;
            try
            {
                CheckSeveralPaths();
                thread = new Thread(() =>
                    DoPrepareAndCopySeveral(PathsFrom, PathsTo, Recursively));
                thread.Start();
            }
            catch (Exception e)
            {
                if (thread != null) thread.Abort();
                OnCopyError(e.Message);
            }
        }

        protected void DoPrepareAndCopySeveral(
            List<string> pathsFrom, List<string> pathsTo, 
            bool copySubDirs = true)
        {
            try
            {
                DoPrepareSeveral(pathsFrom);
                ReplaceDialogResult replaceDialogResult = ReplaceDialogResult.None;
                for (int i = 0; i < pathsFrom.Count; i++)
                {
                    DoDirectoryCopy(pathsFrom[i], pathsTo[i], ref replaceDialogResult, copySubDirs);
                }
                OnFinished();
            }
            catch (Exception e)
            {
                OnCopyError(e.Message);
            }
        }

        protected void DoPrepareSeveral(List<string> pathsFrom)
        {
            OnStateChanged("Подготовка копирумых файлов...");
            FilesCount = pathsFrom.Sum(x => CalculateFileCount(x));
            OnInitMaxSteps(FilesCount);
        }

        public void CheckSeveralPaths()
        {
            if (PathsFrom == null || !PathsFrom.Any() ||
                PathsTo == null   || !PathsTo.Any() ||
                PathsFrom.Count != PathsTo.Count)
                throw new ArgumentException("Списки каталогов пустые, либо разного размера!");

            for (int i = 0; i < PathsFrom.Count; i++)
            {
                CheckPaths(PathsFrom[i], PathsTo[i]);
            }
        }
    }
}
