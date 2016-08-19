namespace CACore.SplashScreen
{
    public interface ISplash
    {
        void ShowSplash();
        void HideSplash();
        void ShowStatus(string text);
        void SetPercentage(int percent);
    }
}
