using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Builder;
using MicroService.Common.Core.Services.Interfaces;

namespace MicroService.Common.Core.Services.impl
{
    public abstract class JsonWebTokenBase : IJsonWebTokenBase
    {
        private readonly string _secret;

        protected JsonWebTokenBase(string secret)
        {
            _secret = secret;
        }

        protected string CreateToken(Dictionary<string, object> claims)
        {
            return Create(claims);
        }

        public T DecodeToken<T>(string token)
        {
            var json = new JwtBuilder()
                .WithSecret(_secret)
                .MustVerifySignature()
                .Decode<T>(token);
            return json;
        }

        private string Create(Dictionary<string, object> claims)
        {
            var tokenBuilder = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret);

            foreach (var claim in claims)
            {
                tokenBuilder.AddClaim(claim.Key, claim.Value.ToString());
            }

            return tokenBuilder.Build();
        }
    }
}