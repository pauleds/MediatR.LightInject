using System.Threading;
using System.Threading.Tasks;

namespace MediatR.LightInject.Tests.Common
{
    public class OneWayHandlerWithBaseClass : AsyncRequestHandler<OneWay>
    {
        protected override Task Handle(OneWay request, CancellationToken cancellationToken)
        {
            Global.IsHandled = true;

            return Unit.Task;
        }
    }
}
