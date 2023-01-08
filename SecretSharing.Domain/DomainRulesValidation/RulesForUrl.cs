using System.Text.RegularExpressions;

namespace SecretSharing.Domain.DomainRulesValidation
{
    public static class RulesForUrl
    {
        public static bool IsUrl(string guid)
        {
            return Regex.IsMatch(guid, @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
        }
    }
}
