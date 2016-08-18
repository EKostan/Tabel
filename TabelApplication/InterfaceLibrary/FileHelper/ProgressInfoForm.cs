using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InterfaceLibrary.FileHelper
{
    public sealed partial class ProgressInfoForm : XtraForm
    {
        public event EventHandler CancelBtnClicked;
        private bool _isOkClosing = false;
        private bool _isFinished = false;

        private void OnCancelBtnClicked()
        {
            EventHandler handler = CancelBtnClicked;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public string Title
        {
            set
            {
                if (value != null)
                    Text = value;
            }
        }

        public ProgressInfoForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            btnOk.Enabled = false;

            progressBar.Properties.Step = 1;
            progressBar.Properties.ShowTitle = true;
            progressBar.Properties.PercentView = true;
            progressBar.Properties.Maximum = 100;
            progressBar.Properties.Minimum = 0;
        }

        #region Logic events handlers

        public void OnStateChanged(object o, string e)
        {
            Update(() =>
            {
                if (e != null)
                    infoLabel.Text = e;
            });
        }

        public void OnFileCopying(object o, string e)
        {
            Update(() =>
            {
                if (e != null)
                    infoLabel.Text = e;
                progressBar.PerformStep();
            });
        }

        public void OnInitMaxSteps(object o, int e)
        {
            Update(() =>
            {
                progressBar.Properties.Maximum = e;
            });
        }

        public void OnCopyError(object o, string e)
        {
            Update(() =>
            {
                if (e != null)
                    infoLabel.Text = e;
                progressBar.Enabled = false;
                btnOk.Enabled = true;
            });
        }

        public void OnFinished(object o, EventArgs e)
        {
            Update(() =>
            {
                infoLabel.Text = "Копирование успешно завершено!";
                progressBar.EditValue = progressBar.Properties.Maximum;
                btnOk.Enabled = true;
                btnCancel.Enabled = false;
                _isFinished = true;
            });
        }

        public void OnCanceled(object o, EventArgs e)
        {
            Update(() =>
            {
                infoLabel.Text = "Копирование отменено!";
                progressBar.Enabled = false;
                btnOk.Enabled = true;
                DialogResult = DialogResult.Cancel;
            });
        }

        #endregion

        #region View events handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelBtnClicked();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _isOkClosing = true;
            Close();
        }

        private void ProgressInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isOkClosing) //если окно закрыли по крестику в верхнем правом углу
            {
                OnCancelBtnClicked();
            }
            else// иначе можно закрыть только кнопкой ОК
            {   
                if (_isFinished) //но это еще не значит, что копирование завершено успешно
                {
                    DialogResult = DialogResult.OK;
                    return;
                }
            }
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region extra

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

        #endregion
    }
}