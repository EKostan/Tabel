using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace InterfaceLibrary.FileHelper
{
    public class FileHelperLogic : IFileHelperLogic
    {
        public event EventHandler<string> StateChanged;
        public event EventHandler<string> FileCopying;
        public event EventHandler<int> InitMaxSteps;
        public event EventHandler Finished;
        public event EventHandler Canceled;
        public event EventHandler<string> CopyError;
        public string Title { get; set; }

        protected bool Stop;
        protected int FilesCount;
        public string PathFrom { get; set; }
        public string PathTo { get; set; }
        public bool Recursively { get; set; }

        public FileHelperLogic()
        {
            Recursively = true;
        }

        #region Invocators

        protected void OnStateChanged(string e)
        {
            EventHandler<string> handler = StateChanged;
            if (handler != null) handler(this, e);
        }

        protected void OnFileCopying(string e)
        {
            EventHandler<string> handler = FileCopying;
            if (handler != null) handler(this, e);
        }

        protected void OnCopyError(string e)
        {
            EventHandler<string> handler = CopyError;
            if (handler != null) handler(this, e);
        }

        protected void OnInitMaxSteps(int e)
        {
            EventHandler<int> handler = InitMaxSteps;
            if (handler != null) handler(this, e);
        }

        protected void OnFinished()
        {
            EventHandler handler = Finished;
            if (handler != null && !Stop) handler(this, EventArgs.Empty);
        }

        protected void OnCanceled()
        {
            EventHandler handler = Canceled;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion

        #region Virtual

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="toPath"></param>
        /// <param name="replaceDialogResult"></param>
        /// <returns>Возвращает false если копирование прервано извне</returns>        
        protected virtual bool CopyFilesToSpecPath(IEnumerable<FileInfo> files, string toPath, 
            ref ReplaceDialogResult replaceDialogResult)
        {
            foreach (FileInfo file in files)
            {
                if (Stop)
                {
                    OnCanceled();
                    return false;
                }

                string destFileName = Path.Combine(toPath, file.Name);

                if (File.Exists(destFileName))
                {
                    if (replaceDialogResult == ReplaceDialogResult.None)
                    {
                        var msg = string.Format("Файл \"{0}\" уже существует. Что вы предпочитаете сделать с ним ?", destFileName);
                        var rd = new ReplaceDialog() { Message = msg };
                        rd.ShowDialog();
                        replaceDialogResult = rd.ReplaceDialogResult;

                        if (replaceDialogResult == ReplaceDialogResult.Owerrite
                            || replaceDialogResult == ReplaceDialogResult.OwerriteAll)
                            File.Copy(file.FullName, destFileName, true);
                    }
                    else if (replaceDialogResult == ReplaceDialogResult.OwerriteAll)
                        File.Copy(file.FullName, destFileName, true);
                    else if (replaceDialogResult == ReplaceDialogResult.SkipAll)
                        continue;
                }
                else 
                    File.Copy(file.FullName, destFileName, true);

                OnFileCopying(file.Name);


                if (replaceDialogResult == ReplaceDialogResult.Owerrite 
                    || replaceDialogResult == ReplaceDialogResult.Skip)
                {
                    replaceDialogResult = ReplaceDialogResult.None;
                }
                else if (replaceDialogResult == ReplaceDialogResult.Cancel)
                {
                    Stop = true;
                    OnCanceled();
                    return false;
                }
            }
            return true;
        }

       

        /// <returns>Возвращает false если копирование прервано извне</returns>
        protected virtual bool CopySubDirsToSpecPath(
            IEnumerable<DirectoryInfo> dirs, string toPath, ref ReplaceDialogResult replaceDialogResult)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                if (Stop)
                {
                    OnCanceled();
                    return false;
                }
                string temppath = Path.Combine(toPath, subdir.Name);
                DoDirectoryCopy(subdir.FullName, temppath, ref replaceDialogResult);
            }
            return true;
        }

        #endregion

        public virtual void DirectoryCopy()
        {
            Thread thread = null;
            try
            {
                CheckPaths(PathFrom, PathTo);
                thread = new Thread(() =>
                {
                    ReplaceDialogResult replaceDialogResult = ReplaceDialogResult.None;
                    DoPrepareAndCopy(PathFrom, PathTo, ref replaceDialogResult,
                    Recursively);
                });
                thread.Start();
            }
            catch (Exception e)
            {
                if (thread != null) thread.Abort();
                OnCopyError(e.Message);
            }
        }

        protected void DoPrepareAndCopy(string pathFrom, string pathTo, 
            ref ReplaceDialogResult replaceDialogResult, bool copySubDirs = true)
        {
            try
            {
                DoPrepare(pathFrom);
                DoDirectoryCopy(pathFrom, pathTo, ref replaceDialogResult, copySubDirs);
                OnFinished();
            }
            catch (Exception e)
            {
                OnCopyError(e.Message);
            }
        }

        protected void DoPrepare(string pathFrom)
        {
            OnStateChanged("Подготовка копирумых файлов...");
            FilesCount = 0;
            FilesCount = CalculateFileCount(pathFrom);
            OnInitMaxSteps(FilesCount);
        }

        public void DoDirectoryCopy(string fromPath, string toPath, 
            ref ReplaceDialogResult replaceDialogResult, bool copySubDirs = true)
        {
            try
            {
                if (Stop)
                {
                    OnCanceled();
                    return;
                }
                if (!Directory.Exists(fromPath))
                    throw new Exception("Неверно указана директория!");

                var dir = new DirectoryInfo(fromPath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                 // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(toPath))
                {
                    Directory.CreateDirectory(toPath);
                }
                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                if (!CopyFilesToSpecPath(files, toPath, ref replaceDialogResult))
                    return;

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    if (!CopySubDirsToSpecPath(dirs, toPath, ref replaceDialogResult))
                        return;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void OnCancelHandler(object o, EventArgs e)
        {
            Stop = true;
        }

        protected virtual int CalculateFileCount(string pathFrom)
        {
            return Directory.GetFiles(pathFrom, "*.*", SearchOption.AllDirectories).Length;
        }

        protected virtual void CheckPaths(string pathFrom, string pathTo)
        {
            if (string.IsNullOrEmpty(pathFrom)
                || !Directory.Exists(pathFrom))
                throw new Exception("Неверно указан каталог, из которого планируется скопировать файлы!");
            if (string.IsNullOrEmpty(pathTo)
                     || !Directory.Exists(pathTo))
                throw new Exception("Неверно указан каталог, в который планируется скопировать файлы!");
        }
    }
}
