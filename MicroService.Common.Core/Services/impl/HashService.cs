using System;
using System.Security.Cryptography;
using System.Text;
using MicroService.Common.Core.Services.Interfaces;

namespace MicroService.Common.Core.Services.impl
{
    public class HashService : IHashService
    {
        public string CreateBase64Sha512Hash(string text, string salt)
        {
            var textAndSaltBytes = ConvertTextAndSalt(text, salt);

            byte[] hash;
            using (var shaM = SHA512.Create())
            {
                hash = shaM.ComputeHash(textAndSaltBytes);
            }

            return ByteArrayToString(hash);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }


        private byte[] ConvertTextAndSalt(string text, string salt)
        {
            return Encoding.ASCII.GetBytes($"{text}:{salt}");
        }
    }
}