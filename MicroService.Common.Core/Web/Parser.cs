using Newtonsoft.Json;

namespace MicroService.Common.Core.Web
{
    public class Parser<T>
    {
        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
    }
}