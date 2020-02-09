using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace Teacher.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateLogger();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex, "Failed to start the app.");
            }
        }

        private static void CreateLogger()
        {
            var logPath = @"C:/temp/teacherLogs";
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            var configuration = new ConfigurationBuilder()
#if DEBUG
                .AddJsonFile("appsettings.Development.json")
#else
                .AddJsonFile("appsettings.json")
#endif
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Debug()
                .CreateLogger();

            Log.Debug("Logger created.");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}