using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Users.Autentification
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CatalogRoleEmail : ISettings
    {
        [XmlElement]
        public List<UserRoleEmail> Roles = new List<UserRoleEmail>();



        public event EventHandler Changed;

        /// <summary>
        /// Возвращает email для первого найденного SID
        /// </summary>
        /// <param name="userSids"></param>
        /// <returns></returns>
        public UserRoleEmail GetRoleEmail(List<string> userSids)
        {
            // оптимизация поиска прав при гигантском количестве userSids
            var dictUserSids = new Dictionary<string, string>();
            foreach (var userSid in userSids)
            {
                dictUserSids[userSid] = userSid;
            }


            foreach (var roleEmail in Roles)
            {
                if (dictUserSids.ContainsKey(roleEmail.Sid))
                    return roleEmail;
            }

            return new UserRoleEmail();
        }


    }
}