using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace InterfaceLibrary.FileHelper
{
    public class FileAndDirHelperLogic : FileHelperLogic
    {
        public IReadOnlyList<string> DirPaths { get; set; }
        public IReadOnlyList<string> FilePaths { get; set; }
      
        public FileAndDirHelperLogic()
        {
            DirPaths = new List<string>();
            FilePaths = new List<string>();
        }

        public override void DirectoryCopy()
        {
            Thread thread = null;
            try
            {
                //CheckPaths(PathFrom, PathTo);
                thread = new Thread(() =>
                {
                    ReplaceDialogResult replaceDialogResult = ReplaceDialogResult.None;
                    DoPrepare(string.Empty);
                    DoCopyDirs(ref replaceDialogResult);
                    DoCopyFiles(ref replaceDialogResult);
                    OnFinished();
                });
                thread.Start();
            }
            catch (Exception e)
            {
                if (thread != null) thread.Abort();
                OnCopyError(e.Message);
            }
        }

        protected override int CalculateFileCount(string pathFrom)
        {
            return DirPaths.Sum(dirPath => base.CalculateFileCount(dirPath)) + FilePaths.Count;
        }

        private void DoCopyDirs(ref ReplaceDialogResult replaceDialogResult)
        {          
            foreach (var dirPath in DirPaths)
            {
                DoDirectoryCopy(dirPath, PathTo, ref replaceDialogResult, Recursively);
            }
        }

        private void DoCopyFiles(ref ReplaceDialogResult replaceDialogResult)
        {
            CopyFilesToSpecPath(FilePaths.Select(x => new FileInfo(x)), PathTo, ref replaceDialogResult);
        }
    }
}
