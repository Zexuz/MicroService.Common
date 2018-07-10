using System;

namespace MicroService.Common.Core.Exceptions
{
    public class UserSuspendedException : Exception
    {
        public UserSuspendedException(string str) : base(str)
        {
        }
    }
}