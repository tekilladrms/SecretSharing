using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SecretSharing.Application.Abstractions;

namespace SecretSharing.Persistence
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        }

    }
}
