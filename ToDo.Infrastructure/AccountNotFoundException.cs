namespace ToDo.Infrastructure
{
    public class AccountNotFoundException : InfrastructureException
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }
    }
}
