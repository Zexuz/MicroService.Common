using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MicroService.Common.Core.Web
{
    public interface IHttpRequestParser
    {
        Task<JObject> ExecuteAsJObject(RequestMessage message);
        Task<T>       ExecuteAsType<T>(RequestMessage message);
        Task          ExecuteAsVoid(RequestMessage message);
        Task<string>  ExecuteRawAsync(RequestMessage message);
    }
}