namespace MicroService.Common.Core.Services.Interfaces
{
    public interface IHashService
    {
        string CreateBase64Sha512Hash(string text, string salt);
    }
}