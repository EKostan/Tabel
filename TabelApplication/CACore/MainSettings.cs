using System;
using Core;

namespace CACore
{
    [Serializable]
    public class MainSettings : BasePluginSettings, ISettings
    {
        public MainSettings()
        {

        }

        private DictionaryExt<string, CustomPath> _paths = new DictionaryExt<string, CustomPath>();

        /// <summary>
        /// Сохранить путь 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        public void SetCustomPath(string key, string path)
        {
            _paths[key] = new CustomPath() { Path = path };
        }

        /// <summary>
        /// Получить сохраненный путь
        /// </summary>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetCustomPath(string key)
        {
            if(!_paths.ContainsKey(key))
                return String.Empty;

            return _paths[key].Path;
        }

        /// <summary>
        /// Путь к директории по умолчанию Группа 1 для следующих действий 
        /// Сохранить исходные данные на КХД
        /// Сохранить материал от заказчика на КХД
        /// </summary>
        public string SaveKhdDefaultDir { get; set; }

        /// <summary>
        /// Путь к директории по умолчанию Группа 2 для следующих действий 
        /// Скачать исходные данные с КХД
        /// Скачать обработанные данные с КХД
        /// </summary>
        public string LoadKhdDefaultDir { get; set; }

        /// <summary>
        /// Путь к директории по умолчанию Группа 3 для следующих действий 
        /// Отправить на проверку заключения
        /// Отправить на проверку экспресс
        /// Отправить заключение без проверки
        /// Отправить экспресс без проверки
        /// Отправить материал на исправление
        /// Отправить экспресс повторно
        /// Отправить заключение повторно
        /// </summary>
        public string SendToCustomerDefaultDir { get; set; }

        /// <summary>
        /// Путь к директории по умолчанию Группа 4 для следующих действий 
        /// Копирование документов в БД на КХД
        /// </summary>
        public string SendToDbDefaultDir { get; set; }

        public event EventHandler Changed;
    }

   
}
