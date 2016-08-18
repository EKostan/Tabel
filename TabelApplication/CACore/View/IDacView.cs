using System.Collections.Generic;

namespace CACore.View
{
    /// <summary>
    /// Интерфейс, который должны реализовать контролы, предоставляющие
    /// возможность управления доступом к своим компонентам
    /// </summary>
    public interface IDacView
    {
        IDictionary<string, System.Windows.Forms.Control> GetCustomizableControls();
    }
}
