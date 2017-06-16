using System.Collections.Specialized;

namespace CroweHorwath.Api
{
    public class ApiSettings : ISettings
    {
        public NameValueCollection _collection;

        public ApiSettings() : this(System.Configuration.ConfigurationManager.AppSettings)
        {

        }

        public ApiSettings(NameValueCollection collection)
        {
            _collection = collection;
        }
        public string GetValueByKey(string key)
        {
            return _collection[key];
        }
    }
}
