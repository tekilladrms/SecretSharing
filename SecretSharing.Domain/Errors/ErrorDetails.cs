using System.Text.Json;

namespace SecretSharing.Domain.Errors
{
    public class ErrorDetails
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
