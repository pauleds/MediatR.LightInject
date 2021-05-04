using System.Threading;
using System.Threading.Tasks;

namespace MediatR.LightInject.Tests.Common
{
    public class Pong1NotificationHandler : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Global.Messages.Add(nameof(Pong1NotificationHandler));

            return Task.CompletedTask;
        }
    }
}
