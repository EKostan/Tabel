using System;
using NLog;

namespace Core.Mvp
{
    public abstract class Presenter : IDisposable
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Вызывайте этот метод в конструкторе для инициализации объектов презентера
        /// </summary>
        public virtual void InitPresenter()
        {
            InitView();
            SignViewEvents();
            SignModelEvents();
        }

        protected abstract void InitView();

        protected virtual void SignViewEvents()
        {
            
        }

        protected virtual void UnSignViewEvents()
        {
            
        }

        protected virtual void SignModelEvents()
        {
            
        }

        protected virtual void UnSignModelEvents()
        {
            
        }

        public virtual void Dispose()
        {
            UnSignViewEvents();
            UnSignModelEvents();
        }
    }
}
