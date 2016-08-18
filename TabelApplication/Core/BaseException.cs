using System;

namespace Core
{
    /// <summary>
    /// Базовый объект для типизированных ошибок ИС ЖГС
    /// </summary>
    public class BaseException : Exception
    {
        /// <summary>
        /// Номер ошибки
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Необходимо инициализировать описанием ошибки.
        /// </summary>
        /// <param name="message">Описание ошибки</param>
        public BaseException(string message)
            : base(message)
        {
        }
    }
}