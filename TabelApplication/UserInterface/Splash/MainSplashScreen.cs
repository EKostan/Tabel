using CACore.Splash;

namespace UserInterface.Splash
{
    public class MainSplashScreen : DevExpress.ExpressApp.Win.Utils.DXSplashScreen, ISplashView
    {
        public MainSplashScreen()
            : base(typeof (MainSplashScreenForm))
        {
            
        }

        public void Show()
        {
            Start();
        }

        public void Hide()
        {
            Stop();
        }

        public void ShowStatus(string text)
        {
            SetDisplayText(text);
        }
    }
}
