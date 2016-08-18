using System.Drawing;

namespace InterfaceLibrary.Colorizers
{
    public interface IColumnColorizer
    {
    }

    public interface IColumnColorizer<T> : IColumnColorizer
    {
        Color GetColor(T record);
        Color GetColor(T record, Color defaultColor);
    }

}