namespace Teacher.Website.Integration.Tests.Infrastructure
{
    internal class ConnectionStringFactory
    {
        public string Create()
        {
            var config = new ConfigurationFactory().Create();
            return config.GetSection("ConnectionStrings")["DefaultConnection"];
        }
    }
}
