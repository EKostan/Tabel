using System;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace InterfaceLibrary
{
    public class GridExporter
    {

        public static void ExportToExcel(/*GridView exportView*/GridControl gridControl)
        {
            string fileName = ShowSaveFileDialog("Экспорт в Excel", "Microsoft Excel|*.xlsx");
            if (fileName == string.Empty) 
                return;

            gridControl.ExportToXlsx(fileName);

            //exportView.ExportToXlsx(fileName);

            //if (exportView == null) return;

             

            //var gvlink = (GridViewExportLink)exportView.CreateExportLink(new ExportXlsProvider(fileName));
            //gvlink.ExportAll = true;
            //gvlink.ExpandAll = true;
            //gvlink.ExportDetails = true;
            //gvlink.ExportTo(true);


            OpenFile(fileName);
        }



        private static void OpenFile(string fileName)
        {
            if (Dialogs.Question(string.Format("Открыть файл {0} ?", fileName), "Экспорт...") == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process
                    {
                        StartInfo =
                        {
                            FileName = fileName,
                            Verb = "Open",
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                        }
                    };
                    process.Start();
                }
                catch
                {
                    Dialogs.ErrorMessageBox("Не удается найти приложения на вашей системе, пригодных для открытия файла с экспортируемыми данными.");
                }
            }
        }


        private static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".", StringComparison.Ordinal) + 1;
            if (n > 0) 
                name = name.Substring(n, name.Length - n);

            dlg.Title = title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
    }
}
