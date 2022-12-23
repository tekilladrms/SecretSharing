using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecretSharing.Domain.ValueObjects
{
    public class DocumentName : ValueObject
    {
        public string Value { get; private set; } = string.Empty;

        // for EF
        private DocumentName() {}

        private DocumentName(string value) => Value = value;

        public static DocumentName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullDomainException(nameof(value));
            if (!IsValid(value)) throw new IncorrectParameterDomainException<string>(nameof(value));
            return new DocumentName(value);
        }

        public static bool IsValid(string value)
        {
            // change pattern
            string pattern = @"(?=^.{0,20}$)\w\D";
            var isMatch = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);
            return isMatch;
        }

        public override string ToString() => Value;

        public override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
