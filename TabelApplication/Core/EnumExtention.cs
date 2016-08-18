using System;
using System.ComponentModel;

namespace Core
{
    /// <summary>
    /// Класс расширений для перечислений.
    /// </summary>
    public static class EnumExtention
    {
        /// <summary>
        /// Возвращает объект атрибут по элементу перечисления.
        /// </summary>
        /// <typeparam name="T">Тип атрибута</typeparam>
        /// <param name="value">Значение перечисления</param>
        /// <returns>Объект аттрибута</returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        /// <summary>
        /// Возвращает значение DescriptionAttribute для элемента перечисления
        /// </summary>
        /// <param name="value">Значение перечисления</param>
        /// <returns>Значение DescriptionAttribute для элемента перечисления</returns>
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
