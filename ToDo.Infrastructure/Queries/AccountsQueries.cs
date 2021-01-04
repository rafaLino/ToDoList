using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Queries;
using ToDo.Application.Results;
using ToDo.Infrastructure.Entities;

namespace ToDo.Infrastructure.Queries
{
    public class AccountsQueries : IAccountsQueries
    {
        private readonly Context _context;

        public AccountsQueries(Context context)
        {
            _context = context;
        }

        public async Task<AccountResult> GetAccount(Guid accountId)
        {
            Account account = await _context
                .Accounts
                .Find(x => x.Id == accountId)
                .SingleOrDefaultAsync();

            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists.");

            var toDoItems = await _context
                .ToDos
                .Find(x => x.AccountId == accountId)
                .ToListAsync();

            var toDoResult = toDoItems
                .OrderBy(x => x.TaskDate)
                .Select(x => new ToDoResult(x.Task, x.TaskDate, x.Done));

            AccountResult result = new AccountResult(accountId, toDoResult);

            return result;
        }
    }
}
