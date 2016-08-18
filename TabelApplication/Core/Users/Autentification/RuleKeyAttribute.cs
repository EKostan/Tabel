using System;

namespace Core.Users.Autentification
{
    /// <summary>
    /// Помечаем поля, используемые для связи элементов интерфейса и прав.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class RuleKeyAttribute : Attribute
    {
        /// <summary>
        /// Уникальный ключ для привязки правил
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Удобночитаемое имя для отображения в интервейсе
        /// </summary>
        public string Name { get; set; }

        public RuleKeyAttribute(string key, string name)
        {
            Key = key;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    /// <summary>
    /// Помечаем поля, группирующие поля с аттрибутом RuleKeyAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RuleKeyGroupAttribute : Attribute
    {
        public string Name { get; set; }

        public RuleKeyGroupAttribute(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
