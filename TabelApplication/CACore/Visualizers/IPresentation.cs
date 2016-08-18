using System.Drawing;

namespace CACore.Visualizers
{
    /// <summary>
    /// Интерфейс пользователя
    /// </summary>
    public interface IPresentation
    {
        Size Size { get; set; }
        void Show();
        void Hide();
    }

    public interface IPresentationControl : IPresentation
    {
    }

    public interface IPresentationForm : IPresentation
    {
    }

}
