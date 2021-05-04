using System;
using System.Reflection;
using System.Threading.Tasks;
using LightInject;
using MediatR.LightInject.Tests.Common;
using Shouldly;
using Xunit;

namespace MediatR.LightInject.Tests
{
    public class MediatorHandlerTests : IDisposable
    {
        public MediatorHandlerTests()
        {
            services = new ServiceContainer();

            ServiceRegistrar.AddMediatRClasses(services, new[] { Assembly.GetExecutingAssembly() });
            ServiceRegistrar.AddRequiredServices(services);

            mediator = services.GetInstance<IMediator>();
        }

        public void Dispose()
        {
            Global.Reset();
        }

        [Fact]
        public async Task Publish_WhenPingNotification_ShouldBeReceivedByAllSubscribedHandlers()
        {
            await mediator.Publish(new PingNotification());

            Global.Messages.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Send_WhenOneWay_ShouldBeHandled()
        {
            await mediator.Send(new OneWay());

            Global.IsHandled.ShouldBeTrue();
        }

        [Fact]
        public async Task Send_WhenPing_ShouldReceivePong()
        {
            var response = await mediator.Send(new Ping());

            response.ShouldBeEquivalentTo("Pong");
        }

        private readonly IMediator mediator;
        private readonly ServiceContainer services;
    }
}
