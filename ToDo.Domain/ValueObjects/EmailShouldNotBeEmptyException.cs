using System;

namespace ToDo.Domain.ValueObjects
{
    public sealed class EmailShouldNotBeEmptyException : DomainException
    {
        public EmailShouldNotBeEmptyException(string message) : base(message)
        {

        }
    }
}
