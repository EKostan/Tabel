using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using NLog;

namespace InterfaceLibrary
{
    public class Dialogs
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void WarningMessageBox(string message, params object[] pars)
        {
            _logger.Warn(message, pars);
            XtraMessageBox.Show(string.Format(message, pars), "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void WarningMessageBox(string message)
        {
            WarningMessageBox(message, "");
        }

        public static void MessageBox(string message, params object[] pars)
        {
            _logger.Info(message, pars);
            XtraMessageBox.Show(string.Format(message, pars), "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MessageBox(string message)
        {
            MessageBox(message, "");
        }


        public static void ErrorMessageBox(string message, params object[] pars)
        {
            _logger.Error(message, pars);

            XtraMessageBox.Show(string.Format(message, pars), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ErrorMessageBox(string message)
        {
            ErrorMessageBox(message, "");
        }

        public static DialogResult Question(string message, string caption = "")
        {
            return XtraMessageBox.Show(message,
                caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }


        static bool _isWaitFormShow = false;
        static object _objWaitFormShow = new object();

        private static object _threadObj = new object();


        public static void ShowDefaultWaitForm(string caption = "Подождите...", string description = "Идет загрузка")
        {
            try
            {
                lock (_threadObj)
                {
                    if (!_isWaitFormShow)
                    {
                        _isWaitFormShow = true;
                        SplashScreenManager.ShowDefaultWaitForm(caption, description);
                    }
                }
            }
            catch
            {
                lock (_threadObj)
                {
                    CloseDefaultWaitForm();
                }
            }
        }

        public static void CloseDefaultWaitForm()
        {
            try
            {
                lock (_threadObj)
                {
                    if (_isWaitFormShow)
                    {
                        SplashScreenManager.CloseDefaultWaitForm();
                        _isWaitFormShow = false;
                    }
                }
            }
            catch
            {
                lock (_threadObj)
                {
                    _isWaitFormShow = false;
                }
            }
        }
    }
}
