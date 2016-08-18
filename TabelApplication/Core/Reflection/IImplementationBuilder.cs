using System;

namespace Core.Reflection
{
    public interface IImplementationBuilder
    {
        Type GetImplementationType(Type interfaceType);
    }
}