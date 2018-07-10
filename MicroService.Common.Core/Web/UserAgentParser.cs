using MicroService.Common.Core.Models;
using UAParser;

namespace MicroService.Common.Core.Web
{
    public static class UserAgentParser
    {
        public static BrowserInfo FromUserAgent(string userAgent)
        {
            var clientInfo = Parser.GetDefault().Parse(userAgent);
            return new BrowserInfo
            {
                BrowserFamily = clientInfo.UserAgent.Family,
                DeviceFamily = clientInfo.Device.Family,
                OsFamily = clientInfo.OS.Family,
            };
        }
    }
}