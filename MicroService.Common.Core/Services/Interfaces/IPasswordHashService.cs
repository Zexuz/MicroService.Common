namespace MicroService.Common.Core.Services.Interfaces
{
    public interface IPasswordHashService
    {
        string GenerateHashFromPassword(string password);
        bool   IsValidHash(string password, string hash);
    }
}