namespace Core
{
    /// <summary>
    /// Объект, который реализует этот интерфейс поддерживает сериализацию.
    /// </summary>
    public interface ISerializeSupport
    {
        /// <summary>
        /// Функция должна выполнится после десериализации объекта
        /// </summary>
        void Deserialized();

        /// <summary>
        /// Функция должна выполнится перед сериализацией объекта
        /// </summary>
        void Serializing();
    }
}