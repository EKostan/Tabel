using System;

namespace CACore
{
    [Serializable]
    public abstract class BasePluginSettings : IPluginSettings
    {
        public virtual void Apply(IPluginSettings settings)
        {
            
        }

        
    }
}