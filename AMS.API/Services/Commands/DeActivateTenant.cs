using AMS.API.Repositories.Tenants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateTenant
    {
        public class Command : IRequest
        {
            public Command(int tenantId)
            {
                TenantId = tenantId;
            }

            public int TenantId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ITenantRepository TenantRepository;

            public Handler(ITenantRepository tenantRepository)
            {
                this.TenantRepository = tenantRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await TenantRepository.DeActivateTenant(message.TenantId);

            }
        }
    }
}
