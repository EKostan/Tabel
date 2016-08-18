using System;

namespace CACore.Visualizers
{
    public class VisualizerCreator : IVisualizerCreator
    {
        public Type VisualizerType { get; set; }

        public IVisualizer Create()
        {
            return (IVisualizer) Activator.CreateInstance(VisualizerType);
        }
    }

    public class VisualizerCreator<T> : IVisualizerCreator<T>
        where T : class, IVisualizer, new()
    {
        public T Create()
        {
            return DoCreate();
        }

        protected virtual T DoCreate()
        {
            return new T();
        }

        IVisualizer IVisualizerCreator.Create()
        {
            return Create();
        }
    }
}