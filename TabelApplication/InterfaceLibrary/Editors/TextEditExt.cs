using System;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Editors
{
    /// <summary>
    /// Текстовый редактор с автоматической подсказкой
    /// </summary>
    public class TextEditExt : TextEdit
    {
        public TextEditExt()
        {
            this.MouseEnter += TextEditExt_MouseEnter;
        }

        void TextEditExt_MouseEnter(object sender, EventArgs e)
        {
            using (var g = CreateGraphics())
            {
                ToolTip = g.MeasureString(Text, Font).Width > Width ? Text : string.Empty;
            }
        }

        protected override void Dispose(bool disposing)
        {
            MouseEnter -= TextEditExt_MouseEnter;
            base.Dispose(disposing);
        }
    }
}
