using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LightInject;
using MediatR.LightInject.Tests.Common;
using Shouldly;
using Xunit;

namespace MediatR.LightInject.Tests
{
    public class ServiceRegistrarTests
    {
        public ServiceRegistrarTests()
        {
            services = new ServiceContainer();
            assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() };
        }

        [Fact]
        public void AddMediatRClasses_WhenCalled_ShouldIncludeAllHandlers()
        {
            ServiceRegistrar.AddMediatRClasses(services, assemblies);

            services.AvailableServices.Count().ShouldBe(5);
        }

        [Fact]
        public void AddRequiredServices_WhenCalled_ShouldContainExpectedInstances()
        {
            ServiceRegistrar.AddMediatRClasses(services, assemblies);
            ServiceRegistrar.AddRequiredServices(services);

            services.GetInstance<IMediator>().ShouldBeOfType<Mediator>();
            services.GetInstance<ISender>().ShouldBeOfType<Mediator>();
            services.GetInstance<IPublisher>().ShouldBeOfType<Mediator>();
            services.AvailableServices.Where(x => x.ServiceType == typeof(INotificationHandler<PingNotification>)).Count().ShouldBe(3);
        }

        private readonly IEnumerable<Assembly> assemblies;
        private readonly ServiceContainer services;
    }
}
