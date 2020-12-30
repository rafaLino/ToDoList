namespace ToDo.Application.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }
    }
}
