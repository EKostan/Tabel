using System.ComponentModel;

namespace CACore.About
{
    public class AboutInfo
    {
        /// <summary>
        /// Версия программы
        /// </summary>
        [DisplayName("Версия программы")]
        [Category("Версия")]
        public string Version { get; set; }

        /// <summary>
        /// Билд программы
        /// </summary>
        [DisplayName("Билд программы")]
        [Category("Версия")]
        public string Build { get; set; }


        

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DisplayName("Имя пользователя")]
        [Category("Система")]
        public string UserName { get; set; }


    }}