using MicroService.Common.Core.Services.Interfaces;

namespace MicroService.Common.Core.Services.impl
{
    public class PasswordHashService : IPasswordHashService
    {
        public string GenerateHashFromPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool IsValidHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}