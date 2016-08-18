namespace Core.Users.Autentification
{
    public interface IRule
    {
        bool CheckSid(string sid);

        bool CheckKey(string key);


        /// <summary>
        /// Уникальный идентификатор правила. Для сервисов это имя метода сервиса. Для данных это тип данных.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Уникальный идентификатор права в AD
        /// </summary>
        string Sid { get; set; }


        /// <summary>
        /// Отображаемое имя правила
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Описание правила
        /// </summary>
        string Description { get; set; }
    }
}