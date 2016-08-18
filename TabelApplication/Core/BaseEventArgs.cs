using System;

namespace Core
{
    /// <summary>
    /// Параметризованный объект для передачи параметров в событиях
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Значение
        /// </summary>
        public T Value;

        /// <summary>
        /// Обязательно необходимо инициализировать значением value.
        /// </summary>
        /// <param name="value">Значение</param>
        public BaseEventArgs(T value)
        {
            Value = value;
        }
    }
}