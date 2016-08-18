using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Core.Users.Autentification;
using Core.Users.Autentification.Containers;
using Core.Users.Settings;
using NLog;

namespace Core.Module
{
    public class ModuleApi
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static ModuleApi()
        {
            UserSettings = new UserSettings();
            UserRoleEmail = new UserRoleEmail();
            UserRules = new RuleContainer<IRule>();
        }

        public static string ExecutableDirectory
        {
            get
            {
                string exe = Process.GetCurrentProcess().MainModule.FileName;
                //_logger.Info("ExecutableFile = {0}", exe);
                string path = Path.GetDirectoryName(exe);
                //_logger.Info("ExecutableDirectory = {0}", path);
                return path;
            }
        }

        /// <summary>
        /// Имя модуля ПК ПДГИ
        /// </summary>
        public static string ModuleId { get; set; }

        /// <summary>
        /// Уникальный идентификатор пользователя в ПК ПДГИ. 
        /// Присваивается движком после прохождения процедуры идентификации
        /// </summary>
        public static string UserId
        {
            get;
            set;
        }


        /// <summary>
        /// Список ролей Jet доступные пользователю
        /// </summary>
        public static UserRoleEmail UserRoleEmail { get; set; }

        /// <summary>
        /// Список правил для Gui-компонентов
        /// </summary>
        public static RuleContainer<IRule> UserRules { get; set; } 
       
        private static string _userName;
        /// <summary>
        /// Логин пользователя виндовс, от которого запускается модуль.
        /// </summary>
        public static string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                UserSettings.UserName = _userName;
            }
        }

       


        /// <summary>
        /// Генерирует уникальный идентификатор модуля. 
        /// Необходимо для того чтобы в системе каждый экземпляр модуля был уникальным.
        /// </summary>
        /// <returns></returns>
        public static string GenerateModuleId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateModuleId(string name)
        {
            var g = Guid.NewGuid().ToString();

            return String.Format("{0}::{1}", name, g);
        }

        public static ModuleDescriptor GetModuleDescriptor()
        {
            return new ModuleDescriptor()
            {
                ModuleId = ModuleId,
                UserId = UserId
            };
        }

       

       

        public static UserSettings UserSettings { get; set; }


       }
}
