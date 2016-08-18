using System;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Editors
{
    /// <summary>
    /// Текстовый редактор с автоматической подсказкой
    /// </summary>
    public class ComboBoxEditExt : ComboBoxEdit
    {
        public ComboBoxEditExt()
        {
            this.MouseEnter += TextEditExt_MouseEnter;
        }

        void TextEditExt_MouseEnter(object sender, EventArgs e)
        {
            var info = GetViewInfo() as DevExpress.XtraEditors.ViewInfo.ComboBoxViewInfo;

            using (var g = CreateGraphics())
            {
                int buttonWidth = 0;

                if (info != null)
                    buttonWidth = info.LeftButtons.Width + info.RightButtons.Width;

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