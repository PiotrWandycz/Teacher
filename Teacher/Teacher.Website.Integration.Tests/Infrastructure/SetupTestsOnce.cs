using com.rusanu.DBUtil;
using Dapper;
using NUnit.Framework;
using System.Data.SqlClient;
using System.IO;
using Teacher.Website.Integration.Tests.Infrastructure;

namespace Teacher.Website.Integration.Tests
{
    [SetUpFixture]
    public class SetupTestsOnce
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            CreateAndSeedTestDatabase();
        }

        private void CreateAndSeedTestDatabase()
        {
            var databaseCreateFilePath = Path.Combine(PathHelper.GetFilesPath(), "Teacher.Database_Create.sql");
            var script = File.ReadAllText(databaseCreateFilePath);
            script = script.Replace("DatabaseName \"Teacher.Database\"", "DatabaseName \"Teacher.Database.Tests\"");
            File.WriteAllText(databaseCreateFilePath, script);

            var databaseSeedFilePath = Path.Combine(PathHelper.GetFilesPath(), "Teacher.Database_PostDeploy.TestSeed.sql");
            var connectionString = new ConnectionStringFactory().ToServer();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var inst = new SqlCmd(connection);
                inst.ExecuteFile(databaseCreateFilePath);
                inst.ExecuteFile(databaseSeedFilePath);
                connection.Close();    
            }
        }

        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            DropDatabaseIfExists();
        }

        private void DropDatabaseIfExists()
        {
            var connectionString = new ConnectionStringFactory().ToServer();
            using (var connection = new SqlConnection(connectionString))
            {
                var killConnections = "ALTER DATABASE [Teacher.Database.Tests] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                var dropDatabase = "DROP DATABASE [Teacher.Database.Tests]";
                connection.Open();
                connection.Execute(killConnections);
                connection.Execute(dropDatabase);
                connection.Close();
            }
        }
    }

    [TestFixture]
    public class TestSetup
    {
        [Test]
        public void Run()
        {
        }
    }
}