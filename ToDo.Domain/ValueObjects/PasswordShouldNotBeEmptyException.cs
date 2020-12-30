using System;

namespace ToDo.Domain.ValueObjects
{
    public class PasswordShouldNotBeEmptyException : DomainException
    {
        public PasswordShouldNotBeEmptyException(string message) : base(message)
        {

        }
    }
}
