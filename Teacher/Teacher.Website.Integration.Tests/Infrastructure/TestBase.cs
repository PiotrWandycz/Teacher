using System;
using Teacher.Website.Integration.Tests.Infrastructure;

namespace Teacher.Website.Integration.Tests
{
    public abstract class TestBase
    {
        private readonly IServiceProvider _serviceProvider;

        public TestBase()
        {
            _serviceProvider = new DependencyResolver().GetServiceProvider();
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}