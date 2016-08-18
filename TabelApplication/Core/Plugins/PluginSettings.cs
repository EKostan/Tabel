using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Plugins
{
    [Serializable]
    public class PluginSettings
    {
        public PluginSettings()
        {
            PluginDirectories= new List<string>();
        }

        [XmlElement]
        public List<string> PluginDirectories { get; set; }
    }
}