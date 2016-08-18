

namespace Core.Logging
{
    public interface ILogger
    {
        ILog Get(string name);
    }
}