﻿namespace Core.Mapping
{
    using System;


    public interface IObjectConverterCache
    {
        IObjectConverter GetConverter(Type type);
    }
}