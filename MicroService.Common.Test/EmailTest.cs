using System;
using MicroService.Common.Core.ValueTypes.Types;
using Xunit;

namespace MicroService.Common.Test
{
    public class EmailTest
    {
        [Theory]
        [InlineData("bowmanbs@outlook.com")]
        [InlineData("moinefou@verizon.net")]
        [InlineData("vertigo@yahoo.ca")]
        [InlineData("leslie@yahoo.com")]
        [InlineData("joelw@mac.com")]
        [InlineData("pspoole@comcast.net")]
        [InlineData("anicolao@live.com")]
        [InlineData("nanop@mac.com")]
        [InlineData("jbailie@optonline.net")]
        [InlineData("gtewari@outlook.com")]
        [InlineData("moinefou@att.net")]
        [InlineData("thassine@yahoo.com")]
        [InlineData("robin.Edbom@gmail.com")]
        [InlineData("ciginnecumo-2850@yopmail.com")]
        [InlineData("ciginnecumo-2850@yopmail.com                                                                              ")]
        [InlineData("                                       ciginnecumo-2850@yopmail.com                           ")]
        public void EmailIsValid(string emailStr)
        {
            var email = new Email(emailStr);
            Assert.Equal(emailStr.Trim(),email.Value);
        }
        
        [Theory]
        [InlineData("bowmanbs.outlook.com")]
        [InlineData("bowmanbskjadskjdaskjaskjdjkasdjkjkasdkjasdljlaksjdlkjas@okladshkjkhjdasutlook.com")]
        public void EmailIsInvalid(string emailStr)
        {
            Assert.Throws<ArgumentException>(() => new Email(emailStr));
        }
    }
}