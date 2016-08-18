using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfaceLibrary.FileHelper
{
    public class FileHelper
    {
        public static bool DirectoryCopy(string pathFrom, string pathTo, 
            bool copySubDirs = true, string title = null)
        {
            var logic = new FileHelperLogic
            {
                PathFrom = pathFrom,
                PathTo = pathTo,
                Recursively = copySubDirs,
                Title = title
            };
            return DoCopy(logic);
        }

        /// <summary>
        /// Копирует файлы, содержащие в названии %filter%. 
        /// Все файлы копируются в одну папку, даже если по пути pathFrom
        /// были вложенные папки.
        /// </summary>
        public static bool DirectoryCopyWithFilter(
            string pathFrom, string pathTo, string filter,
            bool copySubDirs = true, string title = null)
        {
            var logic = new FileHelperWithFilterLogic
            {
                PathFrom = pathFrom,
                PathTo = pathTo,
                NameFilter = filter,
                Recursively = copySubDirs,
                Title = title
            };
            return DoCopy(logic);
        }

        /// <summary>
        /// Выполняет сразу несколько копирований, используя только один 
        /// индикатор прогресса. 
        /// </summary>
        public static bool DirectoryCopySeveral(List<string> pathsFrom, 
            List<string> pathsTo, bool copySubDirs = true, string title = null)
        {
            var logic = new FileHelperSeveralCopying
            {
                PathsFrom = pathsFrom,
                PathsTo = pathsTo,
                Recursively = true,
                Title = title
            };
            return DoCopy(logic);
        }

        /// <summary>
        /// Выполняет сразу несколько копирований (файлов и папок), 
        /// используя только один индикатор прогресса. 
        /// </summary>
        public static bool DirectoryCopyDirsAndFiles(string pathTo,
            IReadOnlyList<string> foldersPath, IReadOnlyList<string> filesPath, string title = null)
        {
            var logic = new FileAndDirHelperLogic()
            {
                DirPaths = foldersPath,
                FilePaths = filesPath,
                PathTo = pathTo,
                Recursively = true,
                Title = title
            };
            return DoCopy(logic);
        }


        private static bool DoCopy(IFileHelperLogic logic)
        {
            using (var form = new ProgressInfoForm { Title = logic.Title, Tag = logic })
            {
                form.CancelBtnClicked += logic.OnCancelHandler;
                form.Load += form_Load;
                
                var result = form.ShowDialog();

                logic.StateChanged -= form.OnStateChanged;
                logic.FileCopying -= form.OnFileCopying;
                logic.InitMaxSteps -= form.OnInitMaxSteps;
                logic.CopyError -= form.OnCopyError;
                logic.Finished -= form.OnFinished;
                logic.Canceled -= form.OnCanceled;
                form.CancelBtnClicked -= logic.OnCancelHandler;
                form.Load -= form_Load;

                return result == DialogResult.OK;
            }
            
            
        }

        static void form_Load(object sender, System.EventArgs e)
        {
            var form = sender as ProgressInfoForm;

            if (form != null)
            {
                var logic = form.Tag as IFileHelperLogic;

                if (logic != null)
                {
                    logic.StateChanged += form.OnStateChanged;
                    logic.FileCopying += form.OnFileCopying;
                    logic.InitMaxSteps += form.OnInitMaxSteps;
                    logic.CopyError += form.OnCopyError;
                    logic.Finished += form.OnFinished;
                    logic.Canceled += form.OnCanceled;
                    logic.DirectoryCopy();
                }
            }
        }
    }
}
