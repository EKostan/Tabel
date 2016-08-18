using System;

namespace Core.Threads
{
    public interface IThreadStartObject : IDisposable
    {
        void Start();
        void Stop();
    }
}
