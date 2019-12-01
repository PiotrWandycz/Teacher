using System.IO;
using Microsoft.SqlServer.Dac;
using NUnit.Framework;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests
{
    [SetUpFixture]
    public class SetupTestsOnce
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            CreateTestDatabase();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }

        private void CreateTestDatabase()
        {
            var dacpacPath = Path.Combine(PathHelper.GetFilesPath(), "TeacherTests.dacpac");
            var dacpac = DacPackage.Load(dacpacPath);
            var options = new DacDeployOptions
            {
                CreateNewDatabase = true
            };
            new DacServices(new ConnectionStringFactory().Create()).Deploy(dacpac, "TeacherTests", false, options);
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