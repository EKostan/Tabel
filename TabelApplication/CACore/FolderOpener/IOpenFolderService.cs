namespace CACore.FolderOpener
{
    public interface IOpenFolderService
    {
        IOpenFolder GetFolderOpener(OpenFolderSettings settings);
        IOpenFolder GetFolderOpenerForDownload(OpenFolderSettings settings);
    }
}
