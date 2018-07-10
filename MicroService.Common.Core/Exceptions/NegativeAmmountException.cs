using System;

namespace MicroService.Common.Core.Exceptions
{
    public class NegativeAmmountException : Exception
    {
        public NegativeAmmountException(string str) : base(str)
        {
        }
    }
}