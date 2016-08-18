namespace Core.Users.Settings
{
    public interface IUserSettingsItem
    {
        string SettingsType { get; set; }
        string XmlSerializedData { get; set; }
    }
}