using System;
using System.Collections.Generic;
using NLog;

namespace Core
{
    /// <summary>
    /// Устарел используейте MainSystem.Instance.Services
    /// </summary>
    [Obsolete("Используйте MainSystem.Instance.Services")]
    public class ServiceLocator
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// typeof(T), T
        /// </summary>
        private static IDictionary<object, object> services;

        static ServiceLocator()
        {
            services = new Dictionary<object, object>();
        }

        public static T GetService<T>()
            where T : class
        {
            //try
            //{
            //    return (T)services[typeof(T)];
            //}
            //catch (KeyNotFoundException)
            //{
            //    throw new ApplicationException(string.Format("Запрашиваемый компонент {0} не найден.", typeof(T).Name));
            //}

            var type = typeof (T);

            if (!services.ContainsKey(type))
            {
                //logger.Error("Запрашиваемый компонент {0} не найден.", type.FullName);
                return null;
            }

            return (T)services[typeof(T)]; 
        }

        
        public static void SetService<T>(T service)
        {
            SetService(typeof(T), service);
        }

        public static void SetService(Type serviceType, object service)
        {
            services[serviceType] = service;
        }

        public static void RemoveService<T>()
        {
            if (services.ContainsKey(typeof (T)))
                services.Remove(typeof (T));
        }

        //#region IServiceLocator Members

        //public T GetService<T>()
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetService<T>(T service)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }
}
