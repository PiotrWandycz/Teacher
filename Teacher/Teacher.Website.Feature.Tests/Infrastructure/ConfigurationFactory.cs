using Microsoft.Extensions.Configuration;

namespace Teacher.Website.Feature.Tests.Infrastructure
{
    internal class ConfigurationFactory
    {
        public IConfiguration Create()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(PathHelper.GetFilesPath())
                    .AddJsonFile("appsettings.Test.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
        }
    }
}