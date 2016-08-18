namespace Core
{
    /// <summary>
    /// Объект содержит системное API.
    /// Объект реализует шаблон Синглтон. Для доступа к его функциям необходимо использовать свойство Instance.
    /// </summary>
    public class MainSystem
    {
        private static readonly object Lock = new object();
        private static MainSystem _instance;
        private readonly ServiceLocatorNew _services;

        protected MainSystem()
        {
            _services = new ServiceLocatorNew();
        }

        /// <summary>
        /// Единственный экземпляр объекта MainSystem
        /// </summary>
        public static MainSystem Instance 
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if(_instance==null)
                            _instance = new MainSystem();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// API для работы с сервисами системы
        /// </summary>
        public ServiceLocatorNew Services
        {
            get { return _services; }
        }

       
    }
}