using System;
using System.Xml.Serialization;
using Core;

namespace CACore.FolderOpener
{
    [Serializable]
    public class OpenFolderSettings: ISettings
    {
        public OpenFolderSettings()
        {
            UseExplorer = true;
            UseExplorerForDownload = true;
            PathToTC = @"C:\ProgramKNGF\TotalCmd\TOTALCMD.EXE";
        }

        public bool UseExplorer { get; set; }
        public bool UseExplorerForDownload { get; set; }

        public string PathToTC { get; set; }

        [field:NonSerialized]
        [field:XmlIgnore]
        public event EventHandler Changed;
    }
}
