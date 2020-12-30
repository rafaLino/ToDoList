using System;

namespace ToDo.Domain.ValueObjects
{
    public class PasswordInvalidException : DomainException
    {
        public PasswordInvalidException(string message) : base(message)
        {

        }
    }
}
