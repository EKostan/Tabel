using System;

namespace Core
{
    /// <summary>
    /// Базовый интерфейс настроек
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Событие об изменении настроек
        /// </summary>
        event EventHandler Changed;
    }
}