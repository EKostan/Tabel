using System;
using System.Drawing;

namespace CACore.Visualizers
{
    
    public interface IVisualizer : IDisposable
    {
        event EventHandler<string> NameChanged;
        event EventHandler ParentTabActivated;

        string Name { get; set; }
        

        void OnParentTabActivated();

        
        IPresentation Presentation { get; set; }

        Icon Icon { get; set; }
    }

    
}
