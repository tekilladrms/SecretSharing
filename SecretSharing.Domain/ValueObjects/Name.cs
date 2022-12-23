using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Primitives;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SecretSharing.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; private set; } = string.Empty;

        //for EF
        private Name() { }

        private Name(string value) => Value = value;


        public static Name Create(string value)
        {
            if (value is null) throw new ArgumentNullDomainException(nameof(value));
            if (!IsValid(value)) throw new IncorrectParameterDomainException<string>(nameof(value));
            return new Name(value);
        }

        public static bool IsValid(string value)
        {
            string pattern = @"(?=^.{1,20}$)\w\D";
            var isMatch = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
            return isMatch;
        }

        public override string ToString() => Value;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }


    }
}