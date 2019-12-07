using System;

namespace Teacher.Website.Integration.Tests.Infrastructure
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