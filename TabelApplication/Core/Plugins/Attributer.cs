using System;
using NLog;

namespace Core.Plugins
{
    public class Attributer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static T GetAttribute<T>(Type fromType)
            where T : Attribute
        {
            try
            {
                var attr = Attribute.GetCustomAttribute(fromType, typeof(T)) as T;
                return attr;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
