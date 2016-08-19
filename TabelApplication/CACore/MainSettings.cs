using System;
using System.Security.AccessControl;
using Core;

namespace CACore
{
    [Serializable]
    public class MainSettings : BasePluginSettings, ISettings
    {
        public MainSettings()
        {
            DbFilePath = "tabel.sqlite";
        }

        public string DbFilePath { get; set; }

        public event EventHandler Changed;
    }

   
}
