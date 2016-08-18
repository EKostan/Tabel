using System;
using Core.Plugins;
using NLog;

namespace Core
{
    /// <summary>
    /// Объект для активации ядра (загрузка настроек, сборка плагинов и т.д.).
    /// </summary>
    public class CoreActivator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static CoreActivator()
        {
            CoreConfigPath = "CoreConfig.xml";
        }

        /// <summary>
        /// Путь к файлу конфигурации ядра
        /// </summary>
        public static string CoreConfigPath { get; set; }

        /// <summary>
        /// Основная функция активации всех компонентов ядра.
        /// </summary>
        public static void Activate()
        {
            try
            {
                OnActivateMessage("Загружаем настройки.");
                SettingsController<CoreConfig>.LoadSettings(CoreConfigPath);
                var coreConfig = SettingsController<CoreConfig>.Settings;

                PluginActivator.SendMessage += PluginActivator_SendMessage;
                PluginActivator.Activate(coreConfig.PluginSettings);
            }
            catch (Exception e)
            {
                logger.Error("Ошибка сборки плагинов: {0}", e.ToString());
            }
            finally
            {
                PluginActivator.SendMessage -= PluginActivator_SendMessage;
            }
        }

        static void PluginActivator_SendMessage(object sender, string e)
        {
            OnActivateMessage(e);
        }

        /// <summary>
        /// Сообщает о сотоянии процесса активации ядра
        /// </summary>
        public static event EventHandler<string> ActivateMessage;

        private static void OnActivateMessage(string e)
        {
            var handler = ActivateMessage;
            if (handler != null) handler(null, e);
        }
    }
}
