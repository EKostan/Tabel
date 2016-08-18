using System.Collections.Generic;
using System.Drawing;

namespace InterfaceLibrary.Colorizers
{
    public class ColorizerFactory
    {
        private Color defaultColor = Color.White;
        private Dictionary<string, IColumnColorizer> _colorContainer = new Dictionary<string, IColumnColorizer>();

        /// <summary>
        /// Добавить объект заливки для ячейки по имени столбца
        /// </summary>
        /// <param name="columnName">Имя столбца</param>
        /// <param name="colorizer">Объект заливки</param>
        public void Add(string columnName, IColumnColorizer colorizer)
        {
            _colorContainer[columnName] = colorizer;
        }

        /// <summary>
        /// Возвращает объект заливки по имени столбца
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public IColumnColorizer<T> Get<T>(string columnName)
        {
            if (!_colorContainer.ContainsKey(columnName))
                return null;

            return _colorContainer[columnName] as IColumnColorizer<T>;
        }
 

    }
}