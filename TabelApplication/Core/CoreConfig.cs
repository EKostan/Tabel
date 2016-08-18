using System;
using System.IO;
using System.Xml.Serialization;
using Core.Module;
using Core.Plugins;

namespace Core
{
    /// <summary>
    /// Объект описнаие параметров ядра.
    /// </summary>
    [Serializable]
    public class CoreConfig : ISettings
    {
        /// <summary>
        /// Создает и инициализирует значениями по умолчанию
        /// </summary>
        public CoreConfig()
        {
            PluginSettings = new PluginSettings();
            AddDefaultPluginDirectories();
            ServerAddress = "rabbitmq://localhost/MainServer";
        }

        void AddDefaultPluginDirectories()
        {
            var executableDirectory = Path.GetDirectoryName(ModuleApi.ExecutableDirectory);

            if (string.IsNullOrEmpty(executableDirectory))
                executableDirectory = string.Empty;

            var pluginDirectory = Path.Combine(executableDirectory, "Plugins");

            PluginSettings.PluginDirectories.Add(pluginDirectory);
        }

        /// <summary>
        /// Настройки для механизма сборки плагинов
        /// </summary>
        [XmlElement]
        public PluginSettings PluginSettings { get; set; }

        /// <summary>
        /// Адрес сервера (интеграционной шины)
        /// по умолчанию равен "rabbitmq://localhost/MainServer"
        /// </summary>
        [XmlElement]
        public string ServerAddress { get; set; }

        /// <summary>
        /// Событие изменения параметров ядра
        /// </summary>
        public event EventHandler Changed;

        protected virtual void OnChanged()
        {
            var handler = Changed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
