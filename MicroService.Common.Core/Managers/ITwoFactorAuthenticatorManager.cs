using MicroService.Common.Core.Models;

namespace MicroService.Common.Core.Managers
{
    public interface ITwoFactorAuthenticatorManager
    {
        bool VerifyCode(string code, string secret, string userIdentifier);
        bool GenerateResult(string userIdentifier, string issuer, out AuthenticatorResult result);
    }
}