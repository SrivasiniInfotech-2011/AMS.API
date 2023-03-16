using AMS.API.Repositories.Tenants;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetTenant
    {
        public class Query : IRequest<Tenant>
        {
            public int TenantId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Tenant>
        {
            private readonly ITenantRepository tenantRepository;

            public Handler(ITenantRepository repository)
            {
                tenantRepository = repository;
            }
            public async Task<Tenant> Handle(Query request, CancellationToken cancellationToken)
            {
                return await tenantRepository.GetTenantById(request.TenantId);
            }
        }
    }
}
