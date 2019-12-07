namespace Teacher.Website.Integration.Tests.Infrastructure
{
    internal class ConnectionStringFactory
    {
        public string ToDatabase()
        {
            var config = new ConfigurationFactory().Create();
            return config.GetSection("ConnectionStrings")["DatabaseConnection"];
        }

        public string ToServer()
        {
            var config = new ConfigurationFactory().Create();
            return config.GetSection("ConnectionStrings")["ServerConnection"];
        }
    }
}
