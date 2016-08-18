using System;

namespace Core.Module
{
    /// <summary>
    /// Описатель модуля системы
    /// </summary>
    [Serializable]
    public class ModuleDescriptor
    {
        /// <summary>
        /// Идентификатор пользователя, от которого идет отправка сообщения
        /// </summary>
        public string UserId { get; set; }


        /// <summary>
        /// Уникальный идентификатор модуля
        /// </summary>
        public string ModuleId { get; set; }

        

    }
}
