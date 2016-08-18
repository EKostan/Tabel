using System;

namespace Core
{
    /// <summary>
    /// Пинг позволяет определить работоспособность удаленного(локального) узла используя его адрес
    /// </summary>
    public interface IPingProgram
    {
        /// <summary>
        /// Запусить ping синхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <returns>Получен ли ответ от удаленного узла</returns>
        bool PingSync(string address, TimeSpan timeout, Action timeoutAction);
        /// <summary>
        /// Запусить ping асинхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <param name="resultAction">Делегат вызываемый при успешном выполнении Ping команды.
        /// Если, аргумент resultAction устаовлен в true, значит
        /// во время выполнения пинг произошла ошибка</param>
        void PingAsync(string address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction);
        /// <summary>
        /// Запусить ping синхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <returns>Получен ли ответ от удаленного узла</returns>
        bool PingSync(Uri address, TimeSpan timeout, Action timeoutAction);
        /// <summary>
        /// Запусить ping асинхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <param name="resultAction">Делегат вызываемый при успешном выполнении Ping команды.
        /// Если, аргумент resultAction устаовлен в true, значит
        /// во время выполнения пинг произошла ошибка</param>
        void PingAsync(Uri address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction);
    }
}