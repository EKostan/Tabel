namespace Core.Mapping
{
    public interface IObjectConverter
    {
        object GetObject(IObjectValueProvider valueProvider);
    }
}