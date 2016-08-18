namespace CACore.Visualizers
{
    public interface IVisualizerCreator<T> : IVisualizerCreator
        where T : class, IVisualizer
    {
        new T Create();
    }

    public interface IVisualizerCreator
    {
        IVisualizer Create();
    }
}