namespace Core.Mapping
{
    using System;
    using Caching;


    /// <summary>
    /// Caches the type converter instances
    /// </summary>
    public class DictionaryConverterCache
    {
        readonly ICache<Type, IDictionaryConverter> _cache;

        public DictionaryConverterCache()
        {
            _cache = new GenericTypeCache<IDictionaryConverter>(typeof(ObjectDictionaryConverter<>),
                CreateMissingConverter);
        }

        IDictionaryConverter CreateMissingConverter(Type key)
        {
            Type type = typeof(ObjectDictionaryConverter<>).MakeGenericType(key);

            return (IDictionaryConverter)Activator.CreateInstance(type, this);
        }

        public IDictionaryConverter GetConverter(Type type)
        {
            return _cache[type];
        }
    }
}