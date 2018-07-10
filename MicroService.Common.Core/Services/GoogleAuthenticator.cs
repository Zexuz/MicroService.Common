using System;
using MicroService.Common.Core.Models;
using OtpNet;

namespace MicroService.Common.Core.Services
{
    internal class GoogleAuthenticator
    {
        public           string              UserIdentifier { get; set; }
        public           string              Issuer         { get; set; }
        private readonly string              _secret;
        private readonly Totp                _totp;
        private readonly int                 _digits;
        private readonly int                 _period;
        private readonly string              _algorithm;
        private          AuthenticatorResult _result;


        public GoogleAuthenticator()
        {
            var key = KeyGeneration.GenerateRandomKey(32);
            var base32String = Base32Encoding.ToString(key);

            _secret = base32String;
            _totp = new Totp(key);
            _digits = 6;
            _period = 30;
            _algorithm = "SHA1";
        }

        public GoogleAuthenticator(string secret)
        {
            var key = Base32Encoding.ToBytes(secret);
            _secret = secret;
            _totp = new Totp(key);
            _digits = 6;
            _period = 30;
            _algorithm = "SHA1";
        }

        public long CurrentTimeWindow()
        {
            _totp.VerifyTotp("000000", out var timeWindows);
            return timeWindows;
        }

        public string ComputeTotp()
        {
            return _totp.ComputeTotp();
        }

        public bool ValidateCode(string code, out long timeWindowMatched)
        {
            return _totp.VerifyTotp(code, out timeWindowMatched);
        }

        public AuthenticatorResult Generate()
        {
            if (_result == null)
                throw new Exception($"Need to do {nameof(VerifyResult)} before getting the result");

            if (string.IsNullOrEmpty(Issuer) || string.IsNullOrEmpty(UserIdentifier))
                throw new Exception("The username of issuer is not set");

            return _result;
        }

        public bool VerifyResult()
        {
            if (string.IsNullOrEmpty(Issuer) || string.IsNullOrEmpty(UserIdentifier))
                throw new Exception("The username of issuer is not set");

            _result = new AuthenticatorResult(Issuer, UserIdentifier, _algorithm, _secret, _digits, _period);

            var topt = new Totp(Base32Encoding.ToBytes(_result.Secret));
            var code = topt.ComputeTotp();
            var isValid = topt.VerifyTotp(code, out _);
            return isValid;
        }
    }
}