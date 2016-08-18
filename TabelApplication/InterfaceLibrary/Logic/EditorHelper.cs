using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace InterfaceLibrary.Logic
{
    public class EditorHelper
    {
        public static void ClearComboBoxIfNeeded(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Clear)
            {
                var comboBox = sender as ComboBoxEdit;
                comboBox.SelectedIndex = -1;
            }
        }
    }
}
