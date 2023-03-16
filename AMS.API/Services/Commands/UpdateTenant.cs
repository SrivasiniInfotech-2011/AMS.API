using AMS.API.Repositories.Tenants;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateTenant
    {
        public class Command : IRequest
        {
            public Command(Tenant tenant)
            {
                Tenant = tenant;
            }

            public Tenant Tenant { get; }

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
                await TenantRepository.UpdateTenant(message.Tenant);

            }
        }
    }
}
