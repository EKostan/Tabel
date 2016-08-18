using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Core.Users.Autentification;

namespace Core.Users
{
    [Serializable]
    public class CatalogUsers : ISettings
    {
        public CatalogUsers()
        {
            Users = new List<User>();
        }


        [XmlElement]
        public List<User> Users { get; set; }

        public void AddUser(User user)
        {
            Users.Add(user);
        }


        /// <summary>
        /// Ищет в каталоге пользователей пользователя по логину
        /// </summary>
        /// <returns></returns>
        public User GetUser(string samUserName)
        {
            if (!string.IsNullOrEmpty(samUserName))
            {
                foreach (var user in Users)
                {
                    if (user.SamName.ToLower().Equals(samUserName.ToLower()))
                        return user;
                }
            }

            return new User(){SamName = samUserName};
            //throw new UserNotFoundException(samUserName);
        }

        public User GetUserSilent(string samUserName)
        {
            if (!string.IsNullOrEmpty(samUserName))
            {
                foreach (var user in Users)
                {
                    if (user.SamName.ToLower().Equals(samUserName.ToLower()))
                        return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Ищет в каталоге зарегистрированных пользователей пользователя по логину
        /// </summary>
        /// <returns></returns>
        public User GetUserByUserId(string userId)
        {
            foreach (var user in Users)
            {
                // проверка зарегистрирован ли пользователь
                if (string.IsNullOrEmpty(user.Id) || string.IsNullOrEmpty(userId))
                    continue;

                if (user.Id.ToLower().Equals(userId.ToLower()))
                    return user;
            }

            return null;
            //throw new UserNotFoundException(userId);
        }


        public event EventHandler Changed;
    }
}
