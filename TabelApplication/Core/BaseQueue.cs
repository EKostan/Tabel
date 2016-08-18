using System;
using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Очередь. Используется для организации очереди объектов (FIFO).
    /// </summary>
    /// <typeparam name="T">Элемент очереди</typeparam>
    public class BaseQueue<T> : Queue<T>
        where T: class 
    {
        Queue<T> queue = new Queue<T>();

        /// <summary>
        /// Поместить элемент в очередь.
        /// </summary>
        /// <param name="message"></param>
        public new void Enqueue(T message)
        {
            queue.Enqueue(message);

            if(ItemEnqueue!=null)
                ItemEnqueue(this, new BaseEventArgs<T>(message));
        }

        /// <summary>
        /// Выбрать элемент из очереди.
        /// </summary>
        public new T Dequeue()
        {
            if (queue.Count <=0)
                return null;

            return queue.Dequeue();
        }

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        public void Dispose()
        {
            queue.Clear();
        }

        /// <summary>
        /// Событие помещения элемента в очередь
        /// </summary>
        public event EventHandler<BaseEventArgs<T>> ItemEnqueue;

    }
}
