using System;

namespace Core
{
    /// <summary>
    /// Стандартный объект пинга
    /// </summary>
    public class EmptyPingProgram : IPingProgram
    {
        /// <summary>
        /// Запусить ping синхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <returns>Получен ли ответ от удаленного узла</returns>
        public bool PingSync(string address, TimeSpan timeout, Action timeoutAction)
        {
            return true;
        }
        /// <summary>
        /// Запусить ping асинхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <param name="resultAction">Делегат вызываемый при успешном выполнении Ping команды.
        /// Если, аргумент resultAction устаовлен в true, значит
        /// во время выполнения пинг произошла ошибка</param>
        public void PingAsync(string address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction)
        {
            resultAction(false);
        }
        /// <summary>
        /// Запусить ping синхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <returns>Получен ли ответ от удаленного узла</returns>
        public bool PingSync(Uri address, TimeSpan timeout, Action timeoutAction)
        {
            return true;
        }
        /// <summary>
        /// Запусить ping асинхронно
        /// </summary>
        /// <param name="address">Удаленный адрес</param>
        /// <param name="timeout">Таймаут пинг команды</param>
        /// <param name="timeoutAction">Делегат вызываемый при таймауте</param>
        /// <param name="resultAction">Делегат вызываемый при успешном выполнении Ping команды.
        /// Если, аргумент resultAction устаовлен в true, значит
        /// во время выполнения пинг произошла ошибка</param>
        public void PingAsync(Uri address, TimeSpan timeout, Action timeoutAction, Action<bool> resultAction)
        {
            resultAction(false);
        }
    }
}