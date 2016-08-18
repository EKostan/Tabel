using System;
using System.Drawing;

namespace CACore.Visualizers
{
    public abstract class Visualizer : IVisualizer
    {
        public event EventHandler<string> NameChanged;
        public event EventHandler ParentTabActivated;

        public string Name { get; set; }

        public virtual void OnParentTabActivated()
        {
            EventHandler handler = ParentTabActivated;
            if (handler != null) handler(this, EventArgs.Empty);
        }


        protected virtual void OnNameChanged(string e)
        {
            EventHandler<string> handler = NameChanged;
            if (handler != null) handler(this, e);
        }

        public IPresentation Presentation { get; set; }
        public Icon Icon { get; set; }
        public virtual void Dispose()
        {
            
        }
    }
}
