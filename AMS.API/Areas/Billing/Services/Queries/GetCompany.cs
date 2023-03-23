using AMS.API.Areas.Billing.Repositories;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetCompany
    {
        public class Query : IRequest<Company>
        {
            public int? CompanyId { get; }
        }

        public class Handler : IRequestHandler<Query, Company>
        {
            private readonly ICompanyRepository companyRepository;

            public Handler(ICompanyRepository repository)
            {
                companyRepository = repository;
            }
            public async Task<Company> Handle(Query request, CancellationToken cancellationToken)
            {
                return await companyRepository.GetCompanyById(request.CompanyId.GetValueOrDefault());
            }
        }
    }
}
