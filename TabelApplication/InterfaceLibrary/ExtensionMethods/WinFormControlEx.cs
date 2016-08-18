using System;
using System.Windows.Forms;

namespace InterfaceLibrary.ExtensionMethods
{
    public static class WinFormControlEx
    {
        public static void UpdateEx(this Control control, Action func)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(func);
            }
            else
            {
                func();
            }
        }
    }
}
