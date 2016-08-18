using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core
{
    /// <summary>
    /// Словарь с расширенными возможностями. Основная его задача это возможность сериализации.
    /// Его необходимо использовать для передачи в качестве параметров сервиса или ответа от удаленного сервиса.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class DictionaryExt<TKey, TValue> : ISerializeSupport
        where TValue: class, new()
    {
        /// <summary>
        /// Список ключей.
        /// Сделан публичным для того чтобы автоматически сериализовались
        /// </summary>
        public List<TKey> _keys = new List<TKey>();

        /// <summary>
        /// Список значений 
        /// Сделан публичным для того чтобы автоматически сериализовались
        /// </summary>
        public List<TValue> _values = new List<TValue>();

        [NonSerialized]
        Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
        
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            _dict[key] = value;
        }

        /// <summary>
        /// Получить элемент
        /// </summary>
        /// <param name="key">Ключ эелемента</param>
        /// <returns>Элемент соответствующий ключу</returns>
        public TValue Get(TKey key)
        {
            if (!_dict.ContainsKey(key))
                _dict[key] = new TValue();

            return _dict[key];
        }

        [OnDeserialized]

        internal void OnDeserialized(StreamingContext sc)
        {
            ((ISerializeSupport)this).Deserialized();
        }

        void ISerializeSupport.Deserialized()
        {
            _dict = new Dictionary<TKey, TValue>();

            for (int i = 0; i < _keys.Count; i++)
            {
                var value = _values[i];
                var key = _keys[i];
                _dict[key] = value;
            }
        }

        [OnSerializing]
        internal void Serializing(StreamingContext sc)
        {
            ((ISerializeSupport)this).Serializing();
        }

        /// <summary>
        /// Предварительная подготовка словаря к сериализации.
        /// Необходимо вызывать перед сериализацией.
        /// </summary>
        public void Serializing()
        {
            _values = new List<TValue>(_dict.Values);
            _keys = new List<TKey>(_dict.Keys);
        }

        /// <summary>
        /// Возвращает Enumerator<TValue>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TValue> GetEnumerator()
        {
            return _dict.Values.GetEnumerator();
        }

        /// <summary>
        /// Индексатор.
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <returns>Значение элемента соответствующее ключу</returns>
        public TValue this[TKey key]
        {
            get { return _dict[key]; }
            set { _dict[key] = value; }
        }

        /// <summary>
        /// Проверка на вхождение.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public void Remove(TKey key)
        {
            if (_dict.ContainsKey(key))
            {
                _dict.Remove(key);
            }
        }

        /// <summary>
        /// Количество элементов в словаре.
        /// </summary>
        public int Count
        {
            get { return _dict.Count; }
        }
    }
}
