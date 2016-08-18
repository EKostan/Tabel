using System;

namespace Core.Plugins
{
    class PluginDescriptor<T>
        where T: Attribute
    {
        public Type Type { get; set; }
        public T Attribute { get; set; }
    }


}
