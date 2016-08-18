using System;
using CACore.Visualizers;

namespace CACore.View
{
    /// <summary>
    ///  Закладка. В объект закладка можно положить визуализатор.
    /// </summary>
    public class Tab : IDisposable
    {
        public IVisualizer Visualizer { get; set; }

        public void OnTabActivated()
        {
            if (Visualizer != null)
                Visualizer.OnParentTabActivated();
        }

        public void Dispose()
        {
            if (Visualizer != null)
                Visualizer.Dispose();
        }
    }
}