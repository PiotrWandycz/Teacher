using Microsoft.Extensions.Configuration;

namespace Teacher.Website.Infrastructure
{
    class ConnectionStringFactory : IConnectionStringFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ToDatabase()
        {
            return _configuration.GetConnectionString("DatabaseConnection");
        }
    }
}