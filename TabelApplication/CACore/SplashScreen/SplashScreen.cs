using Core;

namespace CACore.SplashScreen
{
    public class Splash
    {
        public static ISplash SplashScreen
        {
            get
            {
                return ServiceLocator.GetService<ISplash>();
            }
        }

        public static void ShowSplash()
        {
            if (SplashScreen == null)
                return;

            SplashScreen.ShowSplash();
        }

        public static void HideSplash()
        {
            if (SplashScreen == null)
                return;
            
            SplashScreen.HideSplash();
        }

        public static void ShowStatus(string text)
        {
            if (SplashScreen == null)
                return;
            
            SplashScreen.ShowStatus(text);
        }

        public static void SetPercentage(int percent)
        {
            if (SplashScreen == null)
                return;
            
            SplashScreen.SetPercentage(percent);
        }
    }
}