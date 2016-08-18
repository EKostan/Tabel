using System;

namespace Core.Users.Autentification
{
    /// <summary>
    /// Запись соответствия роли AD и email 
    /// </summary>
    [Serializable]
    public class UserRoleEmail
    {
        /// <summary>
        /// [users].UserId
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Имя пользователя в домене, оно же лежит в [users].UserName
        /// </summary>
        public string Email { get; set; }

    }
}