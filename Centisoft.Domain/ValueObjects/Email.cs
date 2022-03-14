using Centisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Centisoft.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; private set; }

        /// <summary>
        /// Hiding the public constructor to prevent invalid Email objects to be created. Instead use the constructormethod
        /// </summary>
        /// <param name="value"></param>
        private Email(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Constructor method to create a new Email object. This constructor method now holds the validation rules.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Result<Email> Create(string email, bool isRequired = false)
        {
            email = (email ?? string.Empty).Trim();
            if (isRequired && string.IsNullOrEmpty(email))
            {
                return Result.Fail<Email>("The email must have a value");
            }
            if (email.Length >= 100)
            {
                return Result.Fail<Email>("The email must be less than 100 characters");
            }
            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
            {
                return Result.Fail<Email>("The email is invalid formatted");
            }
            return Result.Ok<Email>(new Email(email));
        }

        protected override bool EqualsCore(Email other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Supporting the ability to implicitly convert an Email into a string
        /// </summary>
        /// <param name="email"></param>
        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        /// <summary>
        /// Supporting the ability to explicitly convert a string into an Email
        /// </summary>
        /// <param name="email"></param>
        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }
    }
}
