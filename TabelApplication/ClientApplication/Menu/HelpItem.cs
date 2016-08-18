using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CACore.Menu;
using InterfaceLibrary;

namespace ClientApplication.Menu
{
    class HelpItem : BaseItemButton
    {
        public HelpItem()
        {
            this.DisplayName = "����������� ������������";
            this.Icon = ImageGallery.HelpIcon;
        }


        protected override void DoExecute()
        {
            var docFileName = "����������� ������������.docx";
            var path = Path.Combine(Application.StartupPath, docFileName);
            //Help.ShowHelp(null, Path.Combine(Application.StartupPath, "����������� ������������.docx"), HelpNavigator.TableOfContents);
            if (!File.Exists(path))
            {
                Dialogs.ErrorMessageBox("�� ������ ���� ������� \"{0}\"", path);
                return;
            }

            Process.Start(path);
        }

    }

   
}