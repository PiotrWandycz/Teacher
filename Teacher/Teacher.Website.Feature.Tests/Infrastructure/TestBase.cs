using System;
using Teacher.Website.Feature.Tests.Infrastructure;

namespace Teacher.Website.Feature.Tests
{
    public abstract class TestBase
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public TestBase()
        {
            ServiceProvider = new DependencyResolver().GetServiceProvider();
        }
    }
}