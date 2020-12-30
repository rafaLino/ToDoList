using System;

namespace ToDo.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
