namespace MicroService.Common.Core.Services.Interfaces
{
    public interface IJsonWebTokenBase
    {
//        Token CreateToken(int accountId, string audience, string issuer, TimeSpan? lifespan = null, Dictionary<string, object> claims = null);
//        Token CreateToken(Dictionary<string, object> claims, string audience, string issuer, TimeSpan? lifespan = null);
//        Token CreateToken(int accountId, TimeSpan fromMinutes, Dictionary<string, object> claims);

        T DecodeToken<T>(string token);
    }
}