using System;
using ToDo.Domain.Users;
using Xunit;

namespace ToDo.Domain.Tests
{
    public class UserTests
    {

        [Fact]
        public void Should_Be_Loaded()
        {
            Guid userId = Guid.NewGuid();
            User user = User.Load(userId, DateTime.UtcNow, "Rafael", "rafaellino@email.com");

            Assert.Equal(userId, user.Id);
        }
    }
}
