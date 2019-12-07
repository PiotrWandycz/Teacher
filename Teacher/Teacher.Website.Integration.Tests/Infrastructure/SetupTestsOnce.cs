using com.rusanu.DBUtil;
using Dapper;
using NUnit.Framework;
using System.Data.SqlClient;
using System.IO;

namespace Teacher.Website.Integration.Tests.Infrastructure
{
    [SetUpFixture]
    public class SetupTestsOnce
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            CreateTestDatabase();
        }

        private void CreateTestDatabase()
        {
            var scriptPath = Path.Combine(PathHelper.GetFilesPath(), "Teacher.Database_Create.sql");
            var connectionString = new ConnectionStringFactory().ToServer();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var inst = new SqlCmd(connection);
                inst.ExecuteFile(scriptPath);
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
                var killConnections = "ALTER DATABASE [Teacher.Database] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                var dropDatabase = "DROP DATABASE [Teacher.Database]";
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