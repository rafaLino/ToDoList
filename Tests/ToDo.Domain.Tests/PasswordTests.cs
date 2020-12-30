using ToDo.Domain.ValueObjects;
using Xunit;

namespace ToDo.Domain.Tests
{
    public class PasswordTests
    {

        [Fact]
        public void Should_Not_Be_Created()
        {
            string empty = string.Empty;

            Assert.Throws<PasswordShouldNotBeEmptyException>(() => new Password(empty));
        }

        [Fact]
        public void Should_Not_Be_Valid()
        {
            string invalidPassword = "12345678";
            Assert.Throws<PasswordInvalidException>(() => new Password(invalidPassword));
        }

        [Fact]
        public void Should_Be_Created()
        {
            string validPassword = "Xyza1234";

            Password password = validPassword;

            Assert.NotEqual<Password>(validPassword, password); //value and hash value is not the same

            Assert.True(password.Equals(validPassword));
        }
    }
}
