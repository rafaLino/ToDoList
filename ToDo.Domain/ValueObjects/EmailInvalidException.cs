using System;

namespace ToDo.Domain.ValueObjects
{
    public sealed class EmailInvalidException : DomainException
    {
        public EmailInvalidException(string message) : base(message)
        {

        }
    }
}
