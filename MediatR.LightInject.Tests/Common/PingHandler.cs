using System.Threading;
using System.Threading.Tasks;

namespace MediatR.LightInject.Tests.Common
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }
}
