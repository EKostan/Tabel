namespace CACore.About
{
    public interface IAboutView
    {
        AboutInfo AboutInfo { get; set; }

        void ShowAbout();
    }
}
