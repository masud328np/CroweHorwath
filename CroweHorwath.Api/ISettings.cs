using System.Collections.Specialized;

namespace CroweHorwath.Api
{
    public interface ISettings
    {
        string GetValueByKey(string key);
    }
}