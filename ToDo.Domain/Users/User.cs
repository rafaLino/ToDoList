using System;
using ToDo.Domain.ValueObjects;

namespace ToDo.Domain.Users
{
    public class User : IEntity
    {

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Email Email { get; private set; }

        public Password Password { get; private set; }

        public Guid AccountId { get; private set; }

        private User()
        {

        }

        public User(string name, Email email, Password password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
        }
        public static User Load(Guid id, string name, Email email, Guid accountId)
        {
            User user = new User
            {
                Id = id,
                Name = name,
                Email = email,
                AccountId = accountId

            };

            return user;
        }
    }
}
