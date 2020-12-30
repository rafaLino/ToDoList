using System;
using System.Threading.Tasks;
using ToDo.Domain.Accounts;

namespace ToDo.Application.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);
    }
}
