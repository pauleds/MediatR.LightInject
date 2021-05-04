using System.Threading;
using System.Threading.Tasks;

namespace MediatR.LightInject.Tests.Common
{
    public class Pong3NotificationHandler : INotificationHandler<PingNotification>
    {
        public Task Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Global.Messages.Add(nameof(Pong3NotificationHandler));

            return Task.CompletedTask;
        }
    }
}
