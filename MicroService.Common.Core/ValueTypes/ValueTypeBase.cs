using System;

namespace MicroService.Common.Core.ValueTypes
{
    public abstract class ValueTypeBase<T>
    {
        public readonly T Value;

        protected ValueTypeBase(T value)
        {
            Value = value;
        }

        protected abstract ValidationRestult Validate();
    }

    public class ValidationRestult
    {
        private string _errorMessage;

        public bool Success { get; set; }

        public string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(_errorMessage))
                    throw new Exception("Error message is not set");
                if (Success)
                    throw new Exception("Can't get error message on success");
                return _errorMessage;
            }
            set => _errorMessage = value;
        }

        public ValidationRestult(bool success)
        {
            Success = success;
        }

        public ValidationRestult(bool success, string errorMessage) : this(success)
        {
            _errorMessage = errorMessage;
        }
    }
}