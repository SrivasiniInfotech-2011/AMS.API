using AMS.API.Repositories.Tenants;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetTenantByExpression
    {
        public class Query : IRequest<Tenant>
        {
            public Func<Tenant, bool> TenantExpressiom;
            public Query(Func<Tenant, bool> expression)
            {
                TenantExpressiom = expression;
            }
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
                return await tenantRepository.GetTenantByAnyField(request.TenantExpressiom);
            }
        }
    }
}
