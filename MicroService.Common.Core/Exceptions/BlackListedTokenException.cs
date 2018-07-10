using System;

namespace MicroService.Common.Core.Exceptions
{
    public class BlackListedTokenException : Exception
    {
        public BlackListedTokenException(string token) : base(token)
        {
        }
    }
}