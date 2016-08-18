using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace InterfaceLibrary.Editors
{
    /// <summary>
    /// Текстовый редактор с автоматической подсказкой
    /// </summary>
    public class DateEditExt : DateEdit
    {
        public DateEditExt()
        {
            this.MouseEnter += TextEditExt_MouseEnter;
        }

        void TextEditExt_MouseEnter(object sender, EventArgs e)
        {
            using (var g = CreateGraphics())
            {
                int buttonWidth = 0;
                foreach (EditorButton button in this.Properties.Buttons)
                {
                    // 18 магическое число отвечает за ширину кнопки в классической теме Windows
                    buttonWidth += 18;
                }

                ToolTip = g.MeasureString(Text, Font).Width > (Width - buttonWidth) ? Text : string.Empty;
            }
        }

        protected override void Dispose(bool disposing)
        {
            MouseEnter -= TextEditExt_MouseEnter;
            base.Dispose(disposing);
        }
    }
}