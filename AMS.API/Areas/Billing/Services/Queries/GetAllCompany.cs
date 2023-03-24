using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AMS.API.Areas.Billing.Repositories;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetAllCompanys
    {
        public class Query : IRequest<List<Company>>
        {
            public int? CompanyId { get; }
            public Query(int? companyId = null)
            {
                CompanyId = companyId;
            }
        }

        public class Handler : IRequestHandler<Query, List<Company>>
        {
            private readonly ICompanyRepository companyRepository;

            public Handler(ICompanyRepository repository)
            {
                companyRepository = repository;
            }
            public async Task<List<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await companyRepository.GetAllCompanys();
            }
        }
    }
}
