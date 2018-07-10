using System;
using MicroService.Common.Core.Models;
using MicroService.Common.Core.Services;

namespace MicroService.Common.Core.Managers
{
    public class TwoFactorAuthenticatorManager : ITwoFactorAuthenticatorManager
    {
        private ISimpleCacheResourceManager<string> _cacheManager;

        public TwoFactorAuthenticatorManager()
        {
            var simpleCacheResourceManager = new SimpleCacheResourceManager<string> {CacheTimeSpan = TimeSpan.FromMinutes(5)};
            _cacheManager = simpleCacheResourceManager;
        }

        public bool VerifyCode(string code, string secret, string userIdentifier)
        {
            var googleAuthenticator = new GoogleAuthenticator(secret);
            var isValidCode = googleAuthenticator.ValidateCode(code, out var newTimeWindowMatched);

            var key = $"{userIdentifier}:{code}:{newTimeWindowMatched}";
            if (!isValidCode || _cacheManager.HasCache(key)) return false;
            _cacheManager.AddToCache(key, null);

            return true;
        }

        public bool GenerateResult(string userIdentifier, string issuer, out AuthenticatorResult result)
        {
            var googleAuthenticator = new GoogleAuthenticator
            {
                Issuer = issuer,
                UserIdentifier = userIdentifier
            };

            var isValid = googleAuthenticator.VerifyResult();
            result = googleAuthenticator.Generate();

            return isValid;
        }
    }
}