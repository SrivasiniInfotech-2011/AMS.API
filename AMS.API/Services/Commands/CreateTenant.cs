using AMS.API.Repositories.Tenants;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateTenant
    {
        public class Command : IRequest<Tenant>
        {
            public Command(Tenant tenant)
            {
                Tenant = tenant;
            }

            public Tenant Tenant { get; }

        }
        public class Handler : IRequestHandler<Command,Tenant>
        {
            private readonly ITenantRepository TenantRepository;

            public Handler(ITenantRepository tenantRepository)
            {
                this.TenantRepository = tenantRepository;
            }

            public async Task<Tenant> Handle(Command message, CancellationToken cancellationToken)
            {
                return await TenantRepository.InsertTenant(message.Tenant);

            }
        }
    }
}
