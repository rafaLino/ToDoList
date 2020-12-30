using System.Threading.Tasks;
using ToDo.Domain.Users;

namespace ToDo.Application.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(User user);

        Task Update(User user);

        Task Delete(User user);
    }
}
