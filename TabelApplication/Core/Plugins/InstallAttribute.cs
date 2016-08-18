using System;

namespace Core.Plugins
{
    /// <summary>
    /// InstallAttribute указывает сборщику плагинов, что медот является входным методом для регистрации расширений.
    /// </summary>
    public class InstallAttribute : Attribute
    {
    }

    /// <summary>
    /// Аналогичен InstallAttribute, за исключением того, что ядро гарантирует запуск всех функций помеченных 
    /// SystemInstallAttribute раньше функций помеченных автрибутами InstallAttribute
    /// </summary>
    public class SystemInstallAttribute : Attribute
    {
    }
}