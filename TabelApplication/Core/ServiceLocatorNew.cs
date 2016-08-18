using System;
using System.ComponentModel.Design;
using System.Linq;
using NLog;

namespace Core
{
    /// <summary>
    /// Объект реализует шаблон проектирования Service Locator.
    /// Предоставляет возможность регистрировать объекты и получать объект 
    /// не зависимо есть ли ссылка на реализацию данного объекта или нет.
    /// </summary>
    public class ServiceLocatorNew : IServiceContainer
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly VirtualTableCollection _table;
        private bool _lazy = true;

        public ServiceLocatorNew()
        {
            _table = new VirtualTableCollection();
        }

        /// <summary>
        /// Не используется
        /// </summary>
        public bool Lazy
        {
            get { return _lazy; }
            set
            {
                if (_lazy && !value)
                {
                    InstantiateLazies();
                }
                _lazy = value;
            }
        }

        /// <summary>
        /// Регистрирует объект по типу serviceType.
        /// </summary>
        /// <param name="serviceType">Тип объект</param>
        /// <param name="callback">Функция обратного вызова, вызывается после создания объекта.</param>
        public void AddService(Type serviceType, ServiceCreatorCallback callback)
        {
            AddService(typeof (object), serviceType, callback);
        }

        /// <summary>
        /// Регистрирует объект по типу serviceType.
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="serviceInstance">Экземпляр объекта</param>
        public void AddService(Type serviceType, object serviceInstance)
        {
            AddService(typeof (object), serviceType, serviceInstance);
        }

        /// <summary>
        /// Возвращает зарегистрированный ранее объект
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return GetService(typeof (object), serviceType);
        }

        /// <summary>
        /// Возвращает объект по типу TServiceType. 
        /// </summary>
        /// <typeparam name="TServiceType">Тип объекта. Необходимо указывать именно тот тип, по которому был зарегистрирован объект.</typeparam>
        /// <returns>Возвращает зарегистрированный ранее объект.</returns>
        public TServiceType GetService<TServiceType>() where TServiceType : class
        {
            return GetService(typeof (object), typeof (TServiceType)) as TServiceType;
        }

        /// <summary>
        /// Возвращает объект по типу TServiceType.
        /// </summary>
        /// <typeparam name="TServiceType">Тип объекта</typeparam>
        /// <param name="sourceType">Тип объекта</param>
        /// <returns>Возвращает зарегистрированный ранее объект</returns>
        public TServiceType GetService<TServiceType>(Type sourceType) where TServiceType : class
        {
            return GetService(sourceType, typeof(TServiceType)) as TServiceType;
        }

        /// <summary>
        /// Возвращает объект по типу source.
        /// </summary>
        /// <typeparam name="TServiceType">Тип объекта</typeparam>
        /// <param name="source">Экземпляр объекта</param>
        /// <returns>Возвращает зарегистрированный ранее объект</returns>
        public TServiceType GetService<TServiceType>(object source) where TServiceType : class
        {
            return GetService(source, typeof(TServiceType)) as TServiceType;
        }

        /// <summary>
        /// Регистрирует объект по типу serviceType
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="callback">Функция обратного вызова, вызывается после создания объекта.</param>
        /// <param name="promote">не используется</param>
        void IServiceContainer.AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
        {
            AddService(serviceType, callback);
        }

        /// <summary>
        /// Регистрирует объект
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="serviceInstance">Экземпляр объекта</param>
        /// <param name="promote">не используется</param>
        void IServiceContainer.AddService(Type serviceType, object serviceInstance, bool promote)
        {
            AddService(serviceType, serviceInstance);
        }
        
        /// <summary>
        /// Удаляет сервис по типу serviceType
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="promote">не используется</param>
        void IServiceContainer.RemoveService(Type serviceType, bool promote)
        {
            RemoveService(serviceType);
        }

        /// <summary>
        /// Удаляет сервис по типу serviceType
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        public void RemoveService(Type serviceType)
        {
            RemoveService(typeof (object), serviceType);
        }

        /// <summary>
        /// Регистрирует объект для источника sourceType по типу serviceType
        /// </summary>
        /// <param name="sourceType">Тип источника (базовый объект или интерфейс)</param>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="callback">Функция обратного вызова, вызывается после создания объекта.</param>
        public void AddService(Type sourceType, Type serviceType, ServiceCreatorCallback callback)
        {
            var serviceCreatorWrapper = new ServiceCreatorWrapper(sourceType, serviceType, callback);
            if (_lazy)
            {
                _table.Register(sourceType, serviceType, serviceCreatorWrapper);
                return;
            }
            AddService(sourceType, serviceType, LazyStubResolve(serviceCreatorWrapper));
        }

        /// <summary>
        /// Регистрирует объект для источника sourceType по типу serviceType
        /// </summary>
        /// <param name="sourceType">Тип источника (базовый объект или интерфейс)</param>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="serviceInstance">Экземпляр объекта</param>
        public void AddService(Type sourceType, Type serviceType, object serviceInstance)
        {
            _table.Register(sourceType, serviceType, serviceInstance);
        }

        /// <summary>
        /// Регистрирует объект по типу TServiceType
        /// </summary>
        /// <typeparam name="TServiceType">Тип объекта</typeparam>
        /// <param name="service">Экземпляр объекта</param>
        public void SetService<TServiceType>(TServiceType service) where TServiceType : class
        {
            AddService(typeof(object), typeof(TServiceType), service);
        } 

        /// <summary>
        /// Регистрирует объект service по типу TServiceType
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="service">Экземпляр объекта</param>
        public void SetService(Type serviceType, object service)
        {
            AddService(typeof(object), serviceType, service);
        }

        /// <summary>
        /// Регистрирует объект service по типу TServiceType
        /// В отличии от SetService не кидает исключения при уже зарегистрированном объекте
        /// </summary>
        /// <param name="serviceType">Тип объекта</param>
        /// <param name="service">Экземпляр объекта</param>
        public void SetServiceSafe(Type serviceType, object service)
        {
            try
            {
                AddService(typeof(object), serviceType, service);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Warn, "SetServiceSafe method: " + e.Message);
            }         
        }

        /// <summary>
        /// Возвращает зарегистрированный ранее объект serviceType для источника source
        /// </summary>
        /// <param name="source">Объект источник (базовый объект или интерфейс)</param>
        /// <param name="serviceType">Тип объекта</param>
        /// <returns></returns>
        public object GetService(object source, Type serviceType)
        {
            object service = _table.Lookup(source, serviceType);
            return LazyStubResolve(service);
        }

        /// <summary>
        /// Возвращает зарегистрированный ранее объект serviceType для источника sourceType
        /// </summary>
        /// <param name="sourceType">тип источника (базовый объект или интерфейс)</param>
        /// <param name="serviceType">Тип объекта</param>
        /// <returns></returns>
        public object GetService(Type sourceType, Type serviceType)
        {
            object service = _table.Lookup(sourceType, serviceType);
            return LazyStubResolve(service);
        }

        /// <summary>
        /// Удаляет объект serviceType для источника sourceType
        /// </summary>
        /// <param name="sourceType">тип источника (базовый объект или интерфейс)</param>
        /// <param name="serviceType">Тип объекта</param>
        public void RemoveService(Type sourceType, Type serviceType)
        {
            object obj = _table.LookupExact(sourceType, serviceType);
            if (obj != null)
            {
                _table.Unregister(sourceType, serviceType);
            }
        }

        /// <summary>
        /// Удаляет объект T
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        public void RemoveService<T>()
        {
            RemoveService(typeof (T));
        }


        private void InstantiateLazies()
        {
            VirtualTableCollection virtualTableCollection = _table.Clone();
            foreach (var serviceCreatorWrapper in virtualTableCollection.OfType<ServiceCreatorWrapper>())
                LazyStubResolve(serviceCreatorWrapper);
        }

        private object LazyStubResolve(object service)
        {
            object result = service;
            var serviceCreatorWrapper = service as ServiceCreatorWrapper;
            if (serviceCreatorWrapper != null)
                result = serviceCreatorWrapper.Create(this);
            return result;
        }


        private class ServiceCreatorWrapper
        {
            private readonly ServiceCreatorCallback _callback;
            private readonly Type _serviceType;
            private readonly Type _sourceType;

            internal ServiceCreatorWrapper(Type sourceType, Type serviceType, ServiceCreatorCallback callback)
            {
                _sourceType = sourceType;
                _serviceType = serviceType;
                _callback = callback;
            }

            internal object Create(ServiceLocatorNew locator)
            {
                object obj = _callback(locator, _serviceType);
                if (obj != null)
                {
                    locator.RemoveService(_sourceType, _serviceType);
                    locator.AddService(_sourceType, _serviceType, obj);
                }
                return obj;
            }
        }
    }
}