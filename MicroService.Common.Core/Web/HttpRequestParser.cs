using System;
using System.Net.Http;
using System.Threading.Tasks;
using MicroService.Common.Core.Web.Exceptions;
using Newtonsoft.Json.Linq;

namespace MicroService.Common.Core.Web
{
    public class HttpRequestParser : IHttpRequestParser
    {
        private readonly HttpClient _httpClient;

        public HttpRequestParser()
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false,
            });
        }


        public async Task<JObject> ExecuteAsJObject(RequestMessage message)
        {
            var jsonString = await Execute(message);
            return JObject.Parse(jsonString);
        }

        public async Task<T> ExecuteAsType<T>(RequestMessage message)
        {
            var jsonString = await Execute(message);
            return Parser<T>.FromJson(jsonString);
        }

        public async Task ExecuteAsVoid(RequestMessage message)
        {
            await Execute(message);
        }

        public async Task<string> ExecuteRawAsync(RequestMessage message)
        {
            return await Execute(message);
        }

        private async Task<string> Execute(RequestMessage message)
        {
            var request = new HttpRequestMessage(message.Method, message.Url);

            if (message.Headers != null)
                foreach (var header in message.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

            if (message.Body != null && message.Method == HttpMethod.Get)
                throw new Exception("Can't have a payload on GET Request");

            if (message.Body != null)
                request.Content = new FormUrlEncodedContent(message.Body);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new NoneSuccessFullStatusCodeException(response.StatusCode, response.ReasonPhrase);

            var jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
    }
}