using System;
using System.Threading.Tasks;
using ToDo.Domain.Users;

namespace ToDo.Application.Repositories
{
    public interface IUserReadOnlyRepository
    {
        Task<User> Get(Guid id);
    }
}
