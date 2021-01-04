using System;
using System.Threading.Tasks;
using ToDo.Application.Results;

namespace ToDo.Application.Queries
{
    public interface IAccountsQueries
    {

        Task<AccountResult> GetAccount(Guid accountId);
    }
}
