using System.Text.RegularExpressions;

namespace SecretSharing.Domain.DomainRulesValidation
{
    public static class RulesForGuid
    {
        public static bool IsGuid(string guid)
        {
            return Regex.IsMatch(guid, @"[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?");
        }
    }
}
