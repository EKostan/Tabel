namespace CACore.Settings
{
    public interface ISettingsTab
    {
        string Name { get; }

        object Control { get; }

        void ApplySettings();

        void ApplySettingsToView();

        void CancelSettings();

        void LoadSettings();
    }
}
