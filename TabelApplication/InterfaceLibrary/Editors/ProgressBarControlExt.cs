using System;
using System.Drawing;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.Editors
{
    public class ProgressBarControlExt : ProgressBarControl
    {
        private LabelControl _label;
        private string _caption;

        public ProgressBarControlExt()
        {
            Properties.Step = 1;
            Properties.Maximum = 100;
            Properties.Minimum = 0;

            _label = new LabelControl();
            this.Controls.Add(_label);
            UpdateLabelLocation();
            this.Resize += ProgressBarControlExt_Resize;
        }

        void ProgressBarControlExt_Resize(object sender, EventArgs e)
        {
            UpdateLabelLocation();
        }

        void UpdateLabelLocation()
        {
            _label.Location = GetNewLabelPosition();
        }

        Point GetNewLabelPosition()
        {
            return new Point(Width / 2 - _label.Width / 2, Height / 2 - _label.Height / 2);
        }
        
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                Update(() =>
                {
                    _caption = value;
                    _label.Text = _caption;
                    UpdateLabelLocation();
                });
            }
        }

       



        private delegate void GuiDelegate();

        void Update(GuiDelegate funk)
        {
            if (InvokeRequired)
            {
                Invoke(funk);
            }
            else
            {
                funk();
            }
        }
    }
}
