using System;

namespace TestingProj.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException() : base ("Validation exception.")
        {

        }

        public ValidationException(string errorMessage) : base (errorMessage)
        {

        }

        public ValidationException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}
