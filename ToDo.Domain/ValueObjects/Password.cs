using System;
using System.Text.RegularExpressions;

namespace ToDo.Domain.ValueObjects
{
    public sealed class Password
    {
        public string _text { get; private set; }

        const string RegexForValidation = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";

        public Password(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new PasswordShouldNotBeEmptyException("The password field is required");

            Regex regex = new Regex(RegexForValidation);
            Match match = regex.Match(text);

            if (!match.Success)
                throw new PasswordInvalidException("Minimum eight characters, at least one letter and one number");

            _text = BCrypt.Net.BCrypt.HashPassword(text);
        }

        public override string ToString()
        {
            return _text.ToString();
        }

        public static implicit operator Password(string text)
        {
            return new Password(text);
        }

        public static implicit operator string(Password password)
        {
            return password._text;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return BCrypt.Net.BCrypt.Verify(obj.ToString(), _text);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _text.GetHashCode();
        }
    }
}
