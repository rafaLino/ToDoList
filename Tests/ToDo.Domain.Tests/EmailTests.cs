using ToDo.Domain.ValueObjects;
using Xunit;

namespace ToDo.Domain.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Should_Not_Be_Created()
        {
            string empty = string.Empty;

            Assert.Throws<EmailShouldNotBeEmptyException>(() => new Email(empty));
        }

        [Fact]
        public void Shoul_Not_Be_Valid()
        {
            string invalidEmail = "invalidemail.combr";

            Assert.Throws<EmailInvalidException>(() => new Email(invalidEmail));
        }

        [Fact]
        public void Should_Be_Created()
        {
            string validEmail = "rafaellinosantos@outlook.com.br";

            Email email = validEmail;

            Assert.Equal(validEmail, email);
        }
    }
}
