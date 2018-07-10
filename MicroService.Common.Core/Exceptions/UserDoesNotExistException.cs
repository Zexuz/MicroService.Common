using System;

namespace MicroService.Common.Core.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(string str) : base(str)
        {
        }
    }
}