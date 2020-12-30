using System;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Users;
using MongoDB.Driver;
namespace ToDo.Infrastructure.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            Entities.User userEntity = new Entities.User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                CreatedDate = DateTime.UtcNow

            };

            await _context.Users.InsertOneAsync(userEntity);
        }

        public async Task Delete(User user)
        {
            await _context.Users.DeleteOneAsync(x => x.Id == user.Id);
        }

        public async Task<User> Get(Guid id)
        {
            Entities.User user = await _context
                .Users
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            Guid accountId = await _context
                .Accounts
                .Find(x => x.UserId == id)
                .Project(x => x.Id)
                .SingleOrDefaultAsync();

            User result = User.Load(
                user.Id,
                user.Name,
                user.Email,
                accountId);

            return result;
        }

        public async Task Update(User user)
        {
            var userEntity = Builders<Entities.User>
                .Update
                .Set(f => f.Name, user.Name);
            await _context.Users.UpdateOneAsync(x => x.Id == user.Id, userEntity);
        }
    }
}
