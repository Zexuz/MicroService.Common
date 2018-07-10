using System;
using System.Text.RegularExpressions;
using MicroService.Common.Core.Misc;
using MicroService.Common.Core.ValueTypes.ValidationSettings;

namespace MicroService.Common.Core.ValueTypes.Types
{
    public sealed class Email : ValueTypeBase<string>
    {
        private Regex _regex;

        public Email(string email) : base(email.Trim())
        {
            _regex = new Regex(@"\S+@\S+\.\S+");
            var res = Validate();
            if (!res.Success)
                throw new ArgumentException("Email is not valid", nameof(email), new Exception(res.ErrorMessage));
        }


        protected override ValidationRestult Validate()
        {
            if (Value.Length > EmailValidationSettings.MaxLenght)
                return new ValidationRestult(false, string.Format(StrResource.EmailToLong, EmailValidationSettings.MaxLenght));

            return new ValidationRestult(_regex.IsMatch(Value), StrResource.EmailLooksStrange);
        }
    }
}