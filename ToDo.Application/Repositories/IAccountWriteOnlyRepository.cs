using System.Threading.Tasks;
using ToDo.Domain.Accounts;

namespace ToDo.Application.Repositories
{
    public interface IAccountWriteOnlyRepository
    {

        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);

    }
}
