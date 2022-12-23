using System.Data.SqlClient;

namespace SecretSharing.Application.Abstractions
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
