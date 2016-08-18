using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using NLog;

namespace Core
{
    /// <summary>
    /// Объект для управления настройками
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SettingsController<T>
        where T : class, ISettings, new()
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private static string _settingsFilePath;

        private static T _settings;
        
        /// <summary>
        /// Настройки. Через это поле нужно получать текущие настройки для типа настроек T
        /// </summary>
        public static T Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                UnSignEvents();
                _settings = value;
                SignEvents();
            }
        }
        
        static SettingsController()
        {
            _settings = new T();
            SignEvents();
            _settingsFilePath = Path.Combine(_settingsDirectory, GetSettingsFileName());
        }

        /// <summary>
        /// Путь к файлу где хранятся настройки. Путь используется для загрузки и сохранения настроек.
        /// </summary>
        public static string SettingsFilePath
        {
            get
            {
                return _settingsFilePath;
            }
        }

        private static string _settingsDirectory = Application.UserAppDataPath;

        /// <summary>
        /// Путь к директории где хранится файл с настройками.
        /// </summary>
        public static string SettingsDirectory
        {
            get
            {
                return _settingsDirectory;
            }
            set
            {
                _settingsDirectory = value;
                _settingsFilePath = Path.Combine(_settingsDirectory, GetSettingsFileName());
            }
        }

        /// <summary>
        /// Возвращает имя файла настроек
        /// </summary>
        /// <returns></returns>
        public static string GetSettingsFileName()
        {
            return _settings.ToString() + ".xml";
        }

       
        /// <summary>
        /// Сохранить настройки в формате xml. 
        /// Настройки будут сохранены в директорию SettingsDirectory по пути SettingsFilePath
        /// </summary>
        public static void SaveSettings()
        {
            SaveSettings(_settingsFilePath);
        }

        /// <summary>
        /// Сохранить настройки в бинарном формате. 
        /// Настройки будут сохранены в директорию SettingsDirectory по пути SettingsFilePath
        /// </summary>
        public static void SaveSettingsBin()
        {
            SaveSettingsBin(_settingsFilePath);
        }

        /// <summary>
        /// Сохранить настройки в формате xml. 
        /// Настройки будут сохранены по пути path
        /// </summary>
        /// <param name="path"></param>
        public static void SaveSettings(string path)
        {
            Serializer.SerializeXmlToFile<T>(path, _settings);
        }

        /// <summary>
        /// Сохранить настройки в бинарном формате. 
        /// Настройки будут сохранены по пути path
        /// </summary>
        /// <param name="path"></param>
        public static void SaveSettingsBin(string path)
        {
            Serializer.SerializeBinToFile(path, _settings.GetType(), _settings);
        }

        /// <summary>
        /// Загрузить настройки из формата xml.
        /// Настройки будут загружены из директории SettingsDirectory из файла SettingsFilePath
        /// </summary>
        public static void LoadSettings()
        {
            LoadSettings(_settingsFilePath);
        }

        /// <summary>
        /// Загружает настройки из формата xml.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="secondPath"></param>
        public static void LoadSettings(string path, string secondPath)
        {
            if (File.Exists(path))
                LoadSettings(path);
            else
                LoadSettings(secondPath);
        }

        /// <summary>
        /// Загрузить настройки из бинарного формата. 
        /// Настройки будут загружены из директории SettingsDirectory из файла SettingsFilePath
        /// </summary>
        public static void LoadSettingsBin()
        {
            LoadSettingsBin(_settingsFilePath);
        }

        /// <summary>
        /// Загрузить настройки из формата xml.
        /// Настройки будут загружены по пути path
        /// </summary>
        /// <param name="path"></param>
        public static void LoadSettings(string path)
        {
            _logger.Info("Загружаем настройки из: {0}", path);
            if (!File.Exists(path))
                return;

            try
            {
                UnSignEvents();
                using (XmlReader xmlReader = XmlReader.Create(path))
                {
                    _settings = Serializer.DeserializeXml<T>(xmlReader);
                    OnChanged();
                }
            }
            catch (Exception e)
            {
                _logger.Error("Ошибка загрузки настроек: {0}", e.ToString());
            }
            finally
            {
                SignEvents();
            }
            _logger.Info("Настройки успешно загружены из: {0}", path);

        }

        /// <summary>
        /// Загрузить настройки из бинарного формата.
        /// Настройки будут загружены по пути path
        /// </summary>
        /// <param name="path"></param>
        public static void LoadSettingsBin(string path)
        {
            if (!File.Exists(path))
                return;


            try
            {
                UnSignEvents();
                _settings = Serializer.DeserializeBinFromFile<T>(path);
                OnChanged();
            }
            catch (Exception e)
            {
                _logger.Error("Ошибка загрузки настроек: {0}", e.ToString());
            }
            finally
            {
                SignEvents();
            }
        }

       
       


        private static void SignEvents()
        {
            _settings.Changed += _settings_Changed;
        }

        static void _settings_Changed(object sender, EventArgs e)
        {
            OnChanged();
        }

        private static void UnSignEvents()
        {
            _settings.Changed -= _settings_Changed;
        }

        /// <summary>
        /// Событие об изменении настроек
        /// </summary>
        public static event EventHandler Changed;


        private static void OnChanged()
        {
            var handler = Changed;
            if (handler != null) handler(null, EventArgs.Empty);
        }
    }
}
