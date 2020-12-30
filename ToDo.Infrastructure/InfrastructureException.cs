using System;

namespace ToDo.Infrastructure
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message) : base(message)
        {

        }
    }
}
