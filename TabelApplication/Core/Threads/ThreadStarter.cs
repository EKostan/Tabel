using System;
using System.Threading;
using NLog;

namespace Core.Threads
{
    public class ThreadStarter : IDisposable
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ThreadStarter(IThreadStartObject threadObject)
        {
            _threadObject = threadObject;
        }

        private Thread _thread;
        private IThreadStartObject _threadObject;

        /// <summary>
        /// Запускает функцию Start у IThreadStartObject в параллельном потоке
        /// </summary>
        public void Start()
        {
            _thread = new Thread(_threadObject.Start);
            _thread.Start();
            logger.Info("Объект {0} запущен в новом потоке", _threadObject);
        }

        /// <summary>
        /// Останавливает работу функции Start (работу параллельного потока) у IThreadStartObject.
        /// </summary>
        public void Stop()
        {
            _threadObject.Stop();

            logger.Info("Ожидание завершения потока {0}", _threadObject);
            while (_thread.IsAlive)
            {

            }
        }

        public void Dispose()
        {
            _threadObject.Dispose();
        }
    }
}
