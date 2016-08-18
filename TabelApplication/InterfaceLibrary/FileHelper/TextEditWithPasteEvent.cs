using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.FileHelper
{

    public class TextEditWithPasteEvent : ButtonEdit
    {
        public event EventHandler<PasteEventArgs> OnPaste;

        protected override TextBoxMaskBox CreateMaskBoxInstance()
        {
            var myTextBoxMaskBox = new TextBoxMaskBoxWithPasteEvent(this);
            myTextBoxMaskBox.Paste += MyTextBoxMaskBoxOnOnPaste;

            return myTextBoxMaskBox;
        }

        private void MyTextBoxMaskBoxOnOnPaste(object sender, PasteEventArgs pasteEventArgs)
        {
            OnOnPaste(pasteEventArgs);
        }

        private void OnOnPaste(PasteEventArgs e)
        {
            var handler = OnPaste;
            if (handler != null) handler(this, e);
        }
    }
    class TextBoxMaskBoxWithPasteEvent : TextBoxMaskBox
    {
        private const int WM_PASTE = 0x0302;

        public event EventHandler<PasteEventArgs> Paste;

        public TextBoxMaskBoxWithPasteEvent(TextEdit ownerEdit)
            : base(ownerEdit)
        {
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_PASTE)
            {
                var a = Clipboard.GetText();
                if (!string.IsNullOrEmpty(a))
                {
                    OnPaste(new PasteEventArgs(a));
                    return;
                }
            }
            base.WndProc(ref message);
        }

        private void OnPaste(PasteEventArgs e)
        {
            var handler = Paste;
            if (handler != null) handler(this, e);
        }
    }
    public class PasteEventArgs : EventArgs
    {
        public PasteEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
