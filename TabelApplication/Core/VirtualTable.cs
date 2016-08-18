
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Core
{
    public class VirtualTableCollection : IEnumerable
    {
        private readonly Dictionary<string, VirtualTableDictionary> _table;

        protected VirtualTableCollection(Dictionary<string, VirtualTableDictionary> serviceRegistry)
        {
            _table = serviceRegistry;
        }

        public VirtualTableCollection()
        {
            _table = new Dictionary<string, VirtualTableDictionary>();
        }

        protected Dictionary<string, VirtualTableDictionary> Table
        {
            get { return _table; }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var current in _table)
            {
                KeyValuePair<string, VirtualTableDictionary> keyValuePair = current;
                foreach (var current2 in keyValuePair.Value)
                {
                    KeyValuePair<string, object> keyValuePair2 = current2;
                    yield return keyValuePair2.Value;
                }
            }
        }

        public VirtualTableCollection Clone()
        {
            var dictionary = new Dictionary<string, VirtualTableDictionary>();
            foreach (string current in _table.Keys)
            {
                dictionary[current] = new VirtualTableDictionary(_table[current]);
            }
            return new VirtualTableCollection(dictionary);
        }

        private static Type GetType(object instance)
        {
            Type result = instance.GetType();
            return result;
        }

        public object Lookup(Type source, Type target)
        {
            //ArgumentValidation.CheckForNullReference(target, "target");
            var keyTarget = target.ToString();
            object obj = null;
            VirtualTableDictionary virtualTableDictionary;
            if (_table.TryGetValue(keyTarget, out virtualTableDictionary) && virtualTableDictionary.Count > 0)
            {
                Type typeSource = source;
                var keySource = source.ToString();
                while (typeSource != null && obj == null && !virtualTableDictionary.TryGetValue(keySource, out obj))
                {
                    Type[] interfaces = typeSource.GetInterfaces();
                    typeSource = typeSource.BaseType;
                    Type[] array = (typeSource != null) ? typeSource.GetInterfaces() : new Type[0];
                    for (int i = 0; i < interfaces.Length; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[j] == interfaces[i])
                            {
                                flag = true;
                                break;
                            }
                        }

                        var keyInterfaceI = interfaces[i].ToString();

                        if (!flag && virtualTableDictionary.TryGetValue(keyInterfaceI, out obj))
                        {
                            break;
                        }
                    }
                }
            }
            return obj;
        }

        public object Lookup(object instance, Type target)
        {
            object obj = null;
            if (!ReferenceEquals(instance, null))
            {
                var serviceProvider = instance as IServiceProvider;
                if (serviceProvider != null)
                {
                    obj = serviceProvider.GetService(target);
                }
                if (obj == null)
                {
                    obj = Lookup(GetType(instance), target);
                }
            }
            return obj;
        }

        public object LookupExact(Type exactSourceType, Type exactTargetType)
        {
            var keyTarget = exactTargetType.ToString();
            var keySource = exactSourceType.ToString();
            object result = null;
            VirtualTableDictionary virtualTableDictionary;
            if (_table.TryGetValue(keyTarget, out virtualTableDictionary))
                virtualTableDictionary.TryGetValue(keySource, out result);
            return result;
        }

        public void Register(Type source, Type target, object newService)
        {
            var keyTarget = target.ToString();
            var keySource = source.ToString();

            if (!_table.ContainsKey(keyTarget))
                _table[keyTarget] = new VirtualTableDictionary();
            VirtualTableDictionary virtualTableDictionary = _table[keyTarget];
            
            //TODO: пока позволяем регистрировать один и тот же тип сервиса, при этом последний перезаписывает первый
            if (virtualTableDictionary.ContainsKey(keySource) && !virtualTableDictionary[keySource].Equals(newService))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                    "ExceptionLookupFrom0To1IsAlreadyRegistered; Source: {0}; Target: {1}", new object[]
                    {
                        source,
                        target
                    }));
            }
            virtualTableDictionary[keySource] = newService;
        }

        public void Unregister(Type source, Type target)
        {
            var keySource = source.ToString();
            var keyTarget = target.ToString();
            VirtualTableDictionary virtualTableDictionary;
            if (_table.TryGetValue(keyTarget, out virtualTableDictionary))
                virtualTableDictionary.Remove(keySource);
        }
    }

    [Serializable]
    public class VirtualTableDictionary : Dictionary<string, object>
    {
        public VirtualTableDictionary()
        {
        }

        public VirtualTableDictionary(VirtualTableDictionary vt)
            : base(vt)
        {
        }

        protected VirtualTableDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
