using Microsoft.Extensions.Configuration;

namespace Teacher.Website.Integration.Tests.Infrastructure
{
    internal class ConfigurationFactory
    {
        public IConfiguration Create()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(PathHelper.GetFilesPath())
                    .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
        }
    }
}