using System;
using System.Collections.Generic;

namespace MicroService.Common.Core.Models
{
    public class Token
    {
        public TimeSpan?      Lifespan { get; set; }
        public DateTimeOffset Expires  { get; set; }
        public string         Audience { get; set; }
        public string         Issuer   { get; set; }

        public Dictionary<string, object> Claims { get; set; }

        public string TokenString { get; set; }
    }
}