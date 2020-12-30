using System;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Accounts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ToDo.Infrastructure.Repositories
{
    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public async Task<Account> Get(Guid id)
        {
            Entities.Account account = await _context
                .Accounts
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            IEnumerable<Entities.ToDoItem> toDoItems = await _context.ToDos
                .Find(x => x.AccountId == id)
                .ToListAsync();

            var ToDoList = toDoItems
                .Select(item =>
                    ToDoItem.Load(
                        item.Id,
                        item.Task,
                        item.TaskDate,
                        item.Done))
                .OrderBy(x => x.TaskDate);


            ToDoCollection collection = new ToDoCollection();
            collection.Add(ToDoList);

            Account result = Account.Load(
                account.Id,
                account.UserId,
                collection,
                account.CreatedDate
                );

            return result;
        }

        public async Task Add(Account account)
        {
            Entities.Account accountEntity = new Entities.Account
            {
                Id = account.Id,
                UserId = account.UserId,
                CreatedDate = DateTime.UtcNow
            };

            await _context.Accounts.InsertOneAsync(accountEntity);
        }

        public async Task Delete(Account account)
        {
            await _context.Accounts.DeleteOneAsync(x => x.Id == account.Id);
            await _context.ToDos.DeleteOneAsync(x => x.AccountId == account.Id);
        }

        public async Task Update(Account account)
        {

            IEnumerable<Entities.ToDoItem> toDoItemsEntity = account
                .GetToDoItems()
                .Select(item => new Entities.ToDoItem
                {
                    Id = item.Id,
                    AccountId = account.Id,
                    Task = item.Task,
                    TaskDate = item.TaskDate,
                    Done = item.Done,
                });

            await _context.ToDos.InsertManyAsync(toDoItemsEntity);
        }
    }
}
