using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MicroService.Common.Core.Web
{
    public static class JsonHelper
    {
        public static string GetJsonStringFromObjcet(object msg)
        {
            var json = JsonConvert.SerializeObject(msg, new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            return json;
        }
    }
}