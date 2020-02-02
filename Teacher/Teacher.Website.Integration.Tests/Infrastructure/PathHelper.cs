using System.IO;

namespace Teacher.Website.Integration.Tests.Infrastructure
{
    internal static class PathHelper
    {
        public static string GetFilesPath()
        {
            var outputPath = Path.GetDirectoryName(typeof(TestBase).Assembly.Location);
            return Path.Combine(outputPath, "Infrastructure", "Files");
        }
    }
}