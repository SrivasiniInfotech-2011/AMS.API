using AMS.API.Repositories.Tenants;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetAllTenants
    {
        public class Query : IRequest<List<Tenant>>
        {
            public int? TenantId { get; }
            public Query(int? tenantId=null)
            {
                TenantId = tenantId;
            }
        }

        public class Handler : IRequestHandler<Query, List<Tenant>>
        {
            private readonly ITenantRepository tenantRepository;

            public Handler(ITenantRepository repository)
            {
                tenantRepository = repository;
            }
            public async Task<List<Tenant>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await tenantRepository.GetAllTenants();
            }
        }
    }
}
