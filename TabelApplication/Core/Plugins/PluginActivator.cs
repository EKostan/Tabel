using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core.Module;
using NLog;

namespace Core.Plugins
{
    public class PluginActivator
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Activate(PluginSettings settings)
        {
            OnSendMessage("Идет процесс сборки плагинов");
            //Splash.ShowStatus("Идет процесс сборки плагинов");
            var files = new List<string>();

            _logger.Info("Передано {0} директорий для поиска плагинов", settings.PluginDirectories.Count);

            // ищем все сборки в директориях с плагинами
            foreach (var pluginDirectory in settings.PluginDirectories)
            {
                try
                {
                    var dir = pluginDirectory;

                    if (string.IsNullOrEmpty(pluginDirectory))
                    {
                        dir = ModuleApi.ExecutableDirectory;
                        //_logger.Info("Пустая директория была заменена на {0}", dir);
                    }
                    //dir = Path.GetDirectoryName(Application.ExecutablePath);

                    if (!Directory.Exists(dir))
                    {
                        _logger.Warn("Указанная директория с плагинами {0} не найдена", pluginDirectory);
                        continue;
                    }

                    var fullPath = Path.GetFullPath(dir);

                    _logger.Info("Ищем плагины в директории: {0}", fullPath);

                    files.AddRange(Directory.GetFiles(fullPath, "*.exe"));
                    files.AddRange(Directory.GetFiles(fullPath, "*.dll"));
                }
                catch (Exception e)
                {
                    _logger.Error("Ошибка поиска директории {0}: {1}", pluginDirectory, e.ToString());
                }
            }

            ActivatePluginsFromFiles(files);
        }


        static void ActivatePluginsFromFiles(IEnumerable<string> files)
        {
            var pluginTypesList = new List<Type>();

            foreach (var file in files)
            {
                if (string.IsNullOrEmpty(file) || Path.GetFileName(file).StartsWith("DevExpress"))
                    continue;

                var pluginTypes = GetExportedTypes(file);
                pluginTypesList.AddRange(pluginTypes);
            }

            foreach (var pluginType in pluginTypesList)
            {
                try
                {
                    Install<SystemInstallAttribute>(pluginType);
                }
                catch (Exception e)
                {
                    _logger.Error("Ошибка при инсталляции плагина {0}: {1}", pluginType.FullName, e.ToString());
                }
            }
           
            foreach (var pluginType in pluginTypesList)
            {
                try
                {
                    Install<InstallAttribute>(pluginType);
                }
                catch (Exception e)
                {
                    _logger.Error("Ошибка при инсталляции плагина {0}: {1}", pluginType.FullName, e.ToString());
                }
            }

        }

        private static IEnumerable<Type> GetExportedTypes(string filePath)
        {
            var res = new List<Type>();

            try
            {
                var assembly = Assembly.LoadFile(filePath);
                res.AddRange(assembly.GetExportedTypes());
            }
            catch (Exception e)
            {
                _logger.Error("Ошибка при поиске плагинов в файле {0}: {1}", filePath, e.ToString());
            }

            return res;
        }

        private static void Install<T>(Type pluginType)
            where T : Attribute
        {
            var methods = pluginType.GetMethods(BindingFlags.Static | BindingFlags.Public);

            foreach (var method in methods)
            {
                var attr = (T)method.GetCustomAttribute(typeof(T));

                if (attr != null)
                {
                    _logger.Info("Найден плагин {0}. Процедура инсталляции начата", pluginType.FullName);
                    method.Invoke(null, null);
                    _logger.Info("Плагин {0} успешно инсталлирован", pluginType.FullName);
                    
                    // TODO: для демонстрации, потом удалить
                    //Thread.Sleep(500);
                    ///
                    
                    var message = string.Format("Плагин {0} успешно инсталлирован", pluginType.FullName);
                    OnSendMessage(message);
                    
                    //Splash.ShowStatus(message);
                }
            }
        }


        public static event EventHandler<string> SendMessage;

        private static void OnSendMessage(string e)
        {
            var handler = SendMessage;
            if (handler != null) handler(null, e);
        }
    }
}
