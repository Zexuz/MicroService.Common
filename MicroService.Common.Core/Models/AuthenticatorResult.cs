namespace MicroService.Common.Core.Models
{
    public class AuthenticatorResult
    {
        public string Issuer    { get; }
        public string Username  { get; }
        public string Algorithm { get; }
        public string Secret    { get; }
        public int    Digits    { get; }
        public int    Period    { get; }

        public AuthenticatorResult(string issuer, string username, string algorithm, string secret, int digits, int period)
        {
            Issuer = issuer;
            Username = username;
            Algorithm = algorithm;
            Secret = secret;
            Digits = digits;
            Period = period;
        }

        public override string ToString()
        {
            return $"otpauth://totp/{Issuer}:{Username}?secret={Secret}&issuer={Issuer}&algorithm={Algorithm}&digits={Digits}&period={Period}";
        }
    }
}