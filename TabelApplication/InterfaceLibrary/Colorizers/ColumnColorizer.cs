using System.Collections.Generic;
using System.Drawing;

namespace InterfaceLibrary.Colorizers
{
    public abstract class ColumnColorizer<TKey, T> : IColumnColorizer<T>
    {
        protected Dictionary<TKey, Color> _colors;


        public Color GetColor(T record)
        {
            var key = GetKey(record);

            if (!_colors.ContainsKey(key))
                return Color.White;
            return _colors[key];
        }

        public Color GetColor(T record, Color defaultColor)
        {
            var key = GetKey(record);

            if (!_colors.ContainsKey(key))
                return defaultColor;
            return _colors[key];
        }

        protected abstract TKey GetKey(T record);

    }
}