using System;

namespace MicroService.Common.Core.Exceptions
{
    public class InsufficientFoundsException : Exception
    {
        public InsufficientFoundsException(string str) : base(str)
        {
        }
    }
}